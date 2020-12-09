﻿using BSClient.Utility;
using DevExpress.CodeParser.Diagnostics;
using System;
using System.Windows.Forms;

namespace BSClient
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.ThreadException += Application_ThreadException; ;
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            Login login = new Login();
            if (login.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new MainForm());
            }
            else
            {
                Application.Exit();
            }


        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Console.WriteLine("SS Aplication Error:  " + e.Exception.Message);
            MessageBoxHelper.ShowErrorMessage("Đã có lỗi xảy ra. Vui lòng liên hệ với người quản trị hoặc nhà phát triển ứng dụng.");
        }
    }
}
