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
        InterceptMouse mouser;
        NativeMouseEventArgs mouseEvents = null;
        public ScreenRecorderChildForm()
        {
            InitializeComponent();

            mouser = new InterceptMouse();
            mouser.Click += mouser_Click;

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

        void mouser_Click(object sender, NativeMouseEventArgs e)
        {
            mouseEvents = e;
            enteredMouseAction = 0;
        }

        void ScreenRecorderChildForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            running = false;
        }

        public void Dispose()
        {
            base.Dispose();
            running = false;
            mouser.Dispose();
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
        int enteredMouseAction = 0;
        private void TakeScreenShot()
        {
            using (Bitmap bmpScreenshot = CaptureScreen(true))
            {
                if (mouseEvents != null)
                {
                    enteredMouseAction+=2;
                    using (Graphics g = Graphics.FromImage(bmpScreenshot))
                    {
                        Point nativePoint = mouseEvents.Point;
                       // Point nativePoint1 = InterceptMouse.GetCursorPosition();
                        //Point nativePoint2 = InterceptMouse.GetCursorPosition();
                        //Point nativePoint = new Point(nativePoint1.X, nativePoint2.Y);
                        int uy = enteredMouseAction * 2;
                        Color cm;
                        if (mouseEvents.MouseButton == System.Windows.Forms.MouseButtons.Left)
                            cm = Color.FromArgb(50+(enteredMouseAction*200/40),255,0,0);
                        else
                            cm = Color.FromArgb(50 + (enteredMouseAction * 200 / 40), 255, 255, 0);
                        g.FillEllipse(new SolidBrush(cm), mouseEvents.Point.X - enteredMouseAction, nativePoint.Y - enteredMouseAction, uy, uy);
                    }
                    if (enteredMouseAction > 20)
                    {
                        mouseEvents = null;
                        enteredMouseAction = 0;
                    }
                }
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

    public class NativeMouseEventArgs : EventArgs
    {
        public NativeMouseEventArgs()
        {
        }

        public Point Point
        {
            get;
            set;
        }

        public MouseButtons MouseButton
        {
            get;
            set;
        }
    }
    public class InterceptMouse : IDisposable
    {
        private LowLevelMouseProc _proc;
        private IntPtr _hookID = IntPtr.Zero;
        public event EventHandler<NativeMouseEventArgs> Click;
        public InterceptMouse()
        {
            _proc = HookCallback;
            _hookID = SetHook(_proc);
        }

        protected void OnClick(NativeMouseEventArgs nmea)
        {
            if (Click != null)
            {
                Click(this, nmea);
            }
        }

        private IntPtr SetHook(LowLevelMouseProc proc)
        {
            using (System.Diagnostics.Process curProcess = System.Diagnostics.Process.GetCurrentProcess())
            using (System.Diagnostics.ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_MOUSE_LL, proc,
                    GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);

        private IntPtr HookCallback(
            int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0) //&&
            // MouseMessages.WM_LBUTTONDOWN == (MouseMessages)wParam)
            {
                MSLLHOOKSTRUCT hookStruct = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));
                NativeMouseEventArgs nam = new NativeMouseEventArgs();
                nam.Point = new Point(hookStruct.pt.X, hookStruct.pt.Y);
                MouseMessages msgs = (MouseMessages)wParam;
                bool ready = true;
                if (msgs == MouseMessages.WM_LBUTTONDOWN)
                    nam.MouseButton = MouseButtons.Left;
                else if (msgs == MouseMessages.WM_RBUTTONDOWN)
                    nam.MouseButton = MouseButtons.Right;
                else
                    ready = false;
                if (ready)
                {
                    OnClick(nam);
                }
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        private const int WH_MOUSE_LL = 14;

        private enum MouseMessages
        {
            WM_LBUTTONDOWN = 0x0201,
            WM_LBUTTONUP = 0x0202,
            WM_MOUSEMOVE = 0x0200,
            WM_MOUSEWHEEL = 0x020A,
            WM_RBUTTONDOWN = 0x0204,
            WM_RBUTTONUP = 0x0205
        }

        /*[StructLayout(LayoutKind.Sequential)]
        private struct POINT
        {
            public int x;
            public int y;
        }*/

        [StructLayout(LayoutKind.Sequential)]
        private struct MSLLHOOKSTRUCT
        {
            public POINT pt;
            public uint mouseData;
            public uint flags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook,
            LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
            IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        public void Dispose()
        {
            UnhookWindowsHookEx(_hookID);
        }

        /// <summary>
        /// Struct representing a point.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;

            public static implicit operator Point(POINT point)
            {
                return new Point(point.X, point.Y);
            }
        }

        /// <summary>
        /// Retrieves the cursor's position, in screen coordinates.
        /// </summary>
        /// <see>See MSDN documentation for further information.</see>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetCursorPos(out POINT lpPoint);

        public static Point GetCursorPosition()
        {
            POINT lpPoint;
            GetCursorPos(out lpPoint);
            //bool success = User32.GetCursorPos(out lpPoint);
            // if (!success)
           // return new Point(lpPoint.X
            return lpPoint;
        }
    }
}