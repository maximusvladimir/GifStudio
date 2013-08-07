using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Gifbrary;

namespace GifStudio
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
            if (args != null && args.Length >= 1)
            {
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
                Gifbrary.Common.FFmpeg.Init();
                Application.Run(new Studio());
            }

            Shutdown();
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.IsTerminating)
            {
                Exception ex = new Exception();
                if (e.ExceptionObject != null && e.ExceptionObject is Exception)
                    ex = (Exception)e.ExceptionObject;
                App.HandleError(IntPtr.Zero, "Sorry! The program has crashed and I couldn't save it. :(", ex, 9);
            }
            else
            {
                Exception ex = new Exception();
                if (e.ExceptionObject != null && e.ExceptionObject is Exception)
                    ex = (Exception)e.ExceptionObject;
                App.HandleError(IntPtr.Zero, "Something went terribly wrong. :(", ex, 8);
            }
            Shutdown();
        }

        public static void Shutdown()
        {
            App.Shutdown();
        }
    }
}
