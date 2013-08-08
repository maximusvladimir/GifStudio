using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GifStudio.ChildForms
{
    public partial class YoutubeVideoUploaderChildForm : Form
    {
        Timer backgroundAnimator;
        Random randy;
        Bitmap background;
        public YoutubeVideoUploaderChildForm()
        {
            InitializeComponent();

            randy = new Random();

            background = new Bitmap(Width, Height);
            backgroundAnimator = new Timer();
            backgroundAnimator.Interval = 20;
            double phaser = 0.0;
            backgroundAnimator.Tick += delegate(object sender, EventArgs e)
            {
                using (Graphics g = Graphics.FromImage(background))
                {
                    phaser += 0.04;
                    int randomadd = (int)(Math.Sin(phaser) * 30);
                    for (int x = -1; x < Width / 5; x++)
                    {
                        for (int y = -1; y < Height/5; y++)
                        {
                            int intensity = randy.Next(0, 150) + randomadd;
                            if (intensity > 255)
                                intensity = 255;
                            if (intensity < 0)
                                intensity = 0;
                            using (SolidBrush b = new SolidBrush(Color.FromArgb(100,intensity, intensity, intensity)))
                            {
                                if (randy.NextDouble() < 0.5)
                                    g.FillEllipse(b, x * 5, y * 5, 6,6);
                                else
                                    g.FillRectangle(b, x * 5, y * 5, 6,6);
                            }
                        }
                    }
                }
                pictureBoxAnimation.Image = background;
                pictureBoxAnimation.Invalidate();
            };
            backgroundAnimator.Stop();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            DoLoginFailedAnimation("Bad password.");
        }

        public void DoNoInternetAnimation()
        {
            backgroundAnimator.Enabled = true;
            backgroundAnimator.Start();
        }

        public void DoLoginFailedAnimation(string reason)
        {
            double delta = 1.0;
            int ticker = 0;
            Point original = panelLogin.Location;
            Timer animator = new Timer();
            int interop = 0;
            animator.Interval = 30;
            labelFailReason.Text = reason;
            animator.Tick += delegate(object animatorSender, EventArgs animatorE)
            {
                delta += 0.15;
                double xc = Math.Sin(delta) * 3;
                double yc = Math.Cos(delta + 0.2) * 3;
                if (randy.NextDouble() > 0.5)
                    xc = xc * -1;
                if (randy.NextDouble() > 0.5)
                    yc = yc * -1;
                interop = (ticker * 255) / 710;
                if (interop > 255)
                    interop = 255;
                if (interop < 0)
                    interop = 0;
                labelFailReason.ForeColor = Color.FromArgb(interop, 0, 0);
                panelLogin.Location = new Point((int)(original.X + xc), (int)(original.Y + yc));
                if ((ticker += 30) >= 710)
                {
                    animator.Stop();
                    panelLogin.Location = original;
                }
            };
            animator.Enabled = true;
            animator.Start();
        }

        public void DoLoginSuccessAnimation()
        {
            double delta = 1.0;
            Timer animator = new Timer();
            animator.Interval = 30;
            animator.Tick += delegate(object animatorSender, EventArgs animatorE)
            {
                delta += Math.Pow(delta, 0.3) * 0.35;
                panelLogin.Location = new Point((int)(panelLogin.Location.X - delta), panelLogin.Location.Y);
                if (panelLogin.Location.X < (-panelLogin.Width) - 100)
                {
                    animator.Stop();
                }
            };
            animator.Enabled = true;
            animator.Start();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://www.youtube.com/account_recovery");
            }
            catch (Exception)
            { }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://accounts.google.com/SignUp?service=youtube");
            }
            catch (Exception)
            { }
        }
    }
}
