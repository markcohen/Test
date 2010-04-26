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
                    MessageBox.Show("Unable to get error information", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                finally
                {
                    Application.Exit();
                }
            }

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
                var ex = (Exception) e.ExceptionObject;
                string errorMsg = FormatExceptionMessage(ex);

                // Since we can't prevent the app from terminating, log this to the event log.
                if (!EventLog.SourceExists("ThreadException"))
                {
                    EventLog.CreateEventSource("ThreadException", "Application");
                }

                // Create an EventLog instance and assign its source.
                new EventLog { Source = "ThreadException" }.WriteEntry(errorMsg);
            }
            catch (Exception exc)
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

        // Creates the error message and displays it.
        private static DialogResult ShowThreadExceptionDialog(string title, Exception e)
        {
            return MessageBox.Show(FormatExceptionMessage(e), title, MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);
        }

        private static string FormatExceptionMessage(Exception e)
        {
            string errorMsg = string.Format(
                "The following application error occurred:\n\n{0}\n\nStack Trace:\n{1}{2}", 
                e.Message, e.GetType().Name, e.StackTrace);

            return errorMsg;
        }
    }
}