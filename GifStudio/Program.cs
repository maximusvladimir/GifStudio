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
        static void Main()
        {
            int randy = 0;
            //unsafe
            {
                IntPtr ptr = System.Runtime.InteropServices.Marshal.AllocHGlobal(128);
                randy = (int)ptr;
                System.Runtime.InteropServices.Marshal.FreeHGlobal(ptr);
            }
            System.Diagnostics.Debug.WriteLine(randy);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            Gifbrary.Common.FFmpeg.Init();
            Application.Run(new Studio());

            SharpApng.Apng.Shutdown();
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
