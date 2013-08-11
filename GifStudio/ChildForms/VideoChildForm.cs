using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GifStudio
{
    public partial class VideoChildForm : Form
    {
        Timer scrubAnayliser;
        public VideoChildForm()
        {
            InitializeComponent();
            DoChildResize();
            Resize += VideoChildForm_Resize;
            //VideoControl.Player.Loop = true;
            scrubAnayliser = new Timer();
            scrubAnayliser.Enabled = true;
            scrubAnayliser.Interval = 150;
            scrubAnayliser.Tick += scrubAnayliser_Tick;
            scrubAnayliser.Start();

            trackBar1.MouseMove += trackBar1_MouseMove;
        }

        public AxWMPLib.AxWindowsMediaPlayer Player
        {
            get
            {
                return axWindowsMediaPlayer1;
            }
        }

        public string FilePath
        {
            get;
            set;
        }

        private void trackBar1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                trackBar1_Scroll(null, null);
        }
        public static int SecondsToMilliseconds(double value)
        {
            double v2 = (value / Math.Ceiling(value));
            string pav = v2.ToString();
            if (pav.IndexOf("0.") > -1)
                pav = pav.Replace("0.", "");
            int newval = 0;
            if (int.TryParse(pav, out newval))
            {
                return newval;
            }
            else
                return -1;
        }
        bool mediaOpened = false;
        private void scrubAnayliser_Tick(object sender, EventArgs e)
        {
            if (!mediaOpened)
                return;
            double dur = Player.currentMedia.duration;//0;//VideoControl.Player.NaturalDuration.TimeSpan.Ticks;
            double pos = Player.Ctlcontrols.currentPosition;//0;// VideoControl.Player.Position.Ticks;
            TimeSpan span = new TimeSpan(0, 0, 0, 0, SecondsToMilliseconds(pos));
            timeElapsed.Text = span.Hours.ToString("D2") + ":" + span.Minutes.ToString("D2") + 
                ":" + span.Seconds.ToString("D2");

            span = new TimeSpan(0,0,0,0,SecondsToMilliseconds(dur));
            timeDuration.Text = span.Hours.ToString("D2") + ":" + span.Minutes.ToString("D2") +
                ":" + span.Seconds.ToString("D2");

            if (dur != 0 && pos != 0)
            {
                int yu = (int)(pos * trackBar1.Maximum / dur);
                if (yu < 0)
                    yu = 0;
                if (yu > trackBar1.Maximum)
                    yu = trackBar1.Maximum;
                trackBar1.Value = yu;
            }
        }

        private void VideoChildForm_Resize(object sender, EventArgs e)
        {
            DoChildResize();
        }

        private void DoChildResize()
        {
            ///VideoControl.Width = Width;
            //VideoControl.Height = Height;
            //VideoControl.InvalidateVisual();
            //VideoControl.Player.Width = Width;
            //VideoControl.Player.Height = Height;
            //VideoControl.Player.InvalidateVisual();
            //Player.Width = Width;
            //Player.Height = Height;
            //Invalidate();
        }

        private void fullscreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        public void SetVideo(string filePath)
        {
            FilePath = filePath;
            Player.URL = filePath;
            System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(
                delegate()
                {
                    System.Threading.Thread.Sleep(1500);
                    Invoke((Action)delegate()
                    {
                        Player.Ctlcontrols.play();
                    });
                }));
            thread.Start();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            double dur = Player.currentMedia.duration;
            Player.Ctlcontrols.pause();
            Player.Ctlcontrols.currentPosition = (trackBar1.Value * dur) / trackBar1.Maximum*1000;
            Player.Ctlcontrols.play();
            buttonPlayPause.Text = "Play";
            playing = true;

        }

        private void checkLoop_CheckedChanged(object sender, EventArgs e)
        {
            /*VideoControl.Player. = checkLoop.Checked;
            if (checkLoop.Checked && !VideoControl.Player.IsPlaying)
            {
                VideoControl.Player.Play();
            }*/
        }
        bool playing = true;
        private void button1_Click(object sender, EventArgs e)
        {
            if (playing)
            {
                buttonPlayPause.Text = "Play";
                //VideoControl.Player.Pause();
                playing = false;
            }
            else
            {
                buttonPlayPause.Text = "Pause";
                //VideoControl.Player.Play();
                playing = true;
            }
        }
    }
}
