using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace GifStudio.ChildForms
{
    public partial class ScreenRecorderChildForm : Form
    {
        Timer logicTimer = new Timer();
        int iterator = 0;
        System.Threading.Thread worker1;
        System.Threading.Thread worker2;
        public ScreenRecorderChildForm()
        {
            InitializeComponent();

            worker1 = new System.Threading.Thread(new System.Threading.ThreadStart(Thread1));
            worker1.Name = "ScreenshotThread0";
            worker2 = new System.Threading.Thread(new System.Threading.ThreadStart(Thread2));
            worker2.Name = "ScreenshotThread1";

            logicTimer.Tick += logicTimer_Tick;
            logicTimer.Interval = 33;
            logicTimer.Enabled = true;
            logicTimer.Start();

            FormClosing += ScreenRecorderChildForm_FormClosing;

            worker1.Start();
            worker2.Start();
        }

        void ScreenRecorderChildForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            running = false;
        }


        bool running = true;
        private void Thread1()
        {
            while (running)
            {
                while (!thread1fire)
                { }
                try
                {
                    TakeScreenShot();
                }
                catch (Exception)
                { }
                thread1accessable = true;
            }
        }

        private void Thread2()
        {
            while (running)
            {
                while (!thread2fire)
                { }
                try
                {
                    TakeScreenShot();
                }
                catch (Exception)
                { }
                thread2accessable = true;
            }
        }


        bool thread1fire = false;
        bool thread2fire = false;
        bool thread1accessable = true;
        bool thread2accessable = true;
        private void logicTimer_Tick(object sender, EventArgs e)
        {
            //if (thread1accessable || thread2accessable)
            {
                if (thread1accessable)
                {
                    thread1fire = true;
                }
                else if (thread2accessable)
                {
                    thread2fire = true;
                }
            }
        }

        private void TakeScreenShot()
        {
            using (Bitmap bmpScreenshot = CaptureScreen(true))
            {
                bmpScreenshot.Save(@"C:\Users\max\Pictures\screendump\img" + iterator++.ToString("D5") + ".png", ImageFormat.Png);
            }
        }


        [StructLayout(LayoutKind.Sequential)]
        struct CURSORINFO
        {
            public Int32 cbSize;
            public Int32 flags;
            public IntPtr hCursor;
            public POINTAPI ptScreenPos;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct POINTAPI
        {
            public int x;
            public int y;
        }

        [DllImport("user32.dll")]
        static extern bool GetCursorInfo(out CURSORINFO pci);

        [DllImport("user32.dll")]
        static extern bool DrawIcon(IntPtr hDC, int X, int Y, IntPtr hIcon);

        const Int32 CURSOR_SHOWING = 0x00000001;

        public static Bitmap CaptureScreen(bool CaptureMouse)
        {
            Bitmap result = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format24bppRgb);

            try
            {
                using (Graphics g = Graphics.FromImage(result))
                {
                    g.CopyFromScreen(0, 0, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);

                    if (CaptureMouse)
                    {
                        CURSORINFO pci;
                        pci.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(typeof(CURSORINFO));

                        if (GetCursorInfo(out pci))
                        {
                            if (pci.flags == CURSOR_SHOWING)
                            {
                                DrawIcon(g.GetHdc(), pci.ptScreenPos.x, pci.ptScreenPos.y, pci.hCursor);
                                g.ReleaseHdc();
                            }
                        }
                    }
                }
            }
            catch
            {
                result = null;
            }

            return result;
        }
    }
}
