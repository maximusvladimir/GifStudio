using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
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
            worker2 = new System.Threading.Thread(new System.Threading.ThreadStart(Thread2));

            logicTimer.Tick += logicTimer_Tick;
            logicTimer.Interval = 33;
            logicTimer.Enabled = true;
            logicTimer.Start();

            FormClosing += ScreenRecorderChildForm_FormClosing;
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
            }
        }

        private void Thread2()
        {
            while (running)
            {
            }
        }


        bool thread1fire = false;
        bool thread2fire = false;
        bool thread1accessable = true;
        bool thread2accessable = true;
        private void logicTimer_Tick(object sender, EventArgs e)
        {
            if (thread1accessable || thread2accessable)
            {
                if (thread1accessable)
                {

                }
            }
        }

        private void TakeScreenShot()
        {
            using (Bitmap bmpScreenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb))
            {
                using (Graphics gfxScreenshot = Graphics.FromImage(bmpScreenshot))
                {
                    gfxScreenshot.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0,
                        Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);
                    bmpScreenshot.Save(@"C:\Users\max\Pictures\screendump\img" + iterator++.ToString("D4"), ImageFormat.Png);
                }
            }
        }
    }
}
