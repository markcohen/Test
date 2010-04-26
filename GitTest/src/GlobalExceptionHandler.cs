using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace GitTest
{
    public static class GlobalExceptionHandler
    {

        public static void UiThreadExceptionHandler(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            DialogResult result = DialogResult.Cancel;
            try
            {
                result = ShowThreadExceptionDialog("Windows Forms Error", e.Exception);
            }
            catch
            {
                try
                {
                    MessageBox.Show("Fatal Windows Forms Error", "Fatal Windows Forms Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                finally
                {
                    Application.Exit();
                }
            }

            // Exits the program when the user clicks Abort.
            if (result == DialogResult.Abort)
            {
                Application.Exit();
            }
        }

        // This exception cannot be kept from terminating the application
        public static void NonUiThreadExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                var ex = (Exception)e.ExceptionObject;
                string errorMsg = "The following fatal application error occurred:\n\n";
                errorMsg = errorMsg + ex.Message + "\n\nStack Trace:\n" + ex.StackTrace;

                // Since we can't prevent the app from terminating, log this to the event log.
                if (!EventLog.SourceExists("ThreadException"))
                {
                    EventLog.CreateEventSource("ThreadException", "Application");
                }

                // Create an EventLog instance and assign its source.
                var myLog = new EventLog {Source = "ThreadException"};
                myLog.WriteEntry(errorMsg);
            }
            catch (Exception exc)
            {
                try
                {
                    MessageBox.Show("Could not write the error to the event log. Reason:\n\n" + exc.Message, 
                        "Fatal Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                finally
                {
                    Application.Exit();
                }
            }
        }

        // Creates the error message and displays it.
        private static DialogResult ShowThreadExceptionDialog(string title, Exception e)
        {
            string errorMsg = "The following application error occurred:\n\n";
            errorMsg = errorMsg + e.Message + "\n\nStack Trace:\n" + e.GetType().Name + e.StackTrace;

            return MessageBox.Show(errorMsg, title, MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);
        }
    }
}