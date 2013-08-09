using Gifbrary;
using Google.GData.Client;
using Google.GData.YouTube;
using Google.YouTube;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
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
                    for (int x = -1; x < Width / 3; x++)
                    {
                        for (int y = -1; y < Height/3; y++)
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
            if (string.IsNullOrEmpty(textBoxUsername.Text) || string.IsNullOrEmpty(textBoxPassword.Text))
            {
                labelFailReason.Text = "Please enter a username and password.";
                return;
            }
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += delegate(object worksender, DoWorkEventArgs args)
            {
                Ping pinger = new Ping();
                try
                {
                    PingReply reply = pinger.Send("www.youtube.com", 7000);
                    if (reply.Status != IPStatus.Success)
                    {
                        Invoke((Action)delegate()
                        {
                            DoNoInternetAnimation();
                        });
                        Invoke((Action)delegate()
                        {
                            Cursor = Cursors.Default;
                        });
                        return;
                    }
                }
                catch (Exception)
                {
                    Invoke((Action)delegate()
                    {
                        DoNoInternetAnimation();
                    });
                    Invoke((Action)delegate()
                    {
                        Cursor = Cursors.Default;
                    });
                    return;
                }
                int res = -52226;

                YouTubeRequestSettings settings = new YouTubeRequestSettings("GifStudio", App.SERFJ, textBoxUsername.Text, textBoxPassword.Text);
                YouTubeRequest request = new YouTubeRequest(settings);
                YouTubeQuery query = new YouTubeQuery(YouTubeQuery.FavoritesVideo);
                Feed<Video> feed = request.Get<Video>(query);
                try
                {
                    res = feed.TotalResults;
                }
                catch (Exception ex)
                {
                    if (ex.Message.ToLower().IndexOf("invalid") > -1)
                    {
                        Invoke((Action)delegate()
                        {
                            DoLoginFailedAnimation("Bad username or password. Check your speelling and try again.");
                        });
                        Invoke((Action)delegate()
                        {
                            Cursor = Cursors.Default;
                        });
                        return;
                    }
                    else if (ex is GDataRequestException)
                    {
                        res = 0;
                    }
                    else
                        throw ex;
                }
                if (res != -52226)
                    Invoke((Action)delegate()
                            {
                                Console.WriteLine(res + "totals");
                                DoLoginSuccessAnimation();
                            });
                Invoke((Action)delegate()
                {
                    Cursor = Cursors.Default;
                });
            };
            Cursor = Cursors.WaitCursor;
            worker.RunWorkerAsync();
        }

        public void DoNoInternetAnimation()
        {
            backgroundAnimator.Enabled = true;
            backgroundAnimator.Start();
            labelFailReason.Text = "Could not contact YouTube.";
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

                    Timer animator2 = new Timer();
                    animator2.Interval = 30;
                    delta = 1.0;
                    int iColor = 0;
                    animator2.Tick += delegate(object animatorSender2, EventArgs animatorE2)
                    {
                        delta += Math.Pow(delta, 0.3) * 0.35;
                        videoUploadControl1.Location = new Point((int)(videoUploadControl1.Location.X - delta), videoUploadControl1.Location.Y);
                        iColor += 1;
                        if (iColor > 100)
                            iColor = 100;
                        videoUploadControl1.Opacity = iColor;
                        videoUploadControl1.Invalidate();
                        if (videoUploadControl1.Location.X <= 0)
                        {
                            videoUploadControl1.Location = new Point(0, videoUploadControl1.Location.Y);
                            animator2.Stop();
                        }
                    };
                    animator2.Enabled = true;
                    animator2.Start();

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
