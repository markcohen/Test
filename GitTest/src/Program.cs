﻿using System;
using System.Windows.Forms;
using GitTest.Forms;

namespace GitTest
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Add global application exception handlers
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += GlobalExceptionHandler.UiThreadExceptionHandler;
            AppDomain.CurrentDomain.UnhandledException += GlobalExceptionHandler.NonUiThreadExceptionHandler;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
