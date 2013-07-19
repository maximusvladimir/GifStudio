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
            VideoControl.Player.Loop = true;
            scrubAnayliser = new Timer();
            scrubAnayliser.Enabled = true;
            scrubAnayliser.Interval = 150;
            scrubAnayliser.Tick += scrubAnayliser_Tick;
            scrubAnayliser.Start();

            trackBar1.MouseMove += trackBar1_MouseMove;
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

        private void scrubAnayliser_Tick(object sender, EventArgs e)
        {
            long pos = VideoControl.Player.MediaPosition;
            long dur = VideoControl.Player.MediaDuration;
            TimeSpan span = new TimeSpan(pos);
            timeElapsed.Text = span.Hours.ToString("D2") + ":" + span.Minutes.ToString("D2") + 
                ":" + span.Seconds.ToString("D2");

            span = new TimeSpan(dur);
            timeDuration.Text = span.Hours.ToString("D2") + ":" + span.Minutes.ToString("D2") +
                ":" + span.Seconds.ToString("D2");

            if (dur != 0 && pos != 0)
            {
                trackBar1.Value = (int)(pos * 500 / dur);
            }
        }

        private void VideoChildForm_Resize(object sender, EventArgs e)
        {
            DoChildResize();
        }

        private void DoChildResize()
        {
            VideoControl.Width = Width;
            VideoControl.Height = Height;
            //VideoControl.Margin = new System.Windows.Thickness(0, 0, Height - menuStrip1.Height, Width);
            VideoControl.InvalidateVisual();
            VideoControl.Player.Width = Width;
            VideoControl.Player.Height = Height;
            //VideoControl.Player.Margin = new System.Windows.Thickness(0, 0, Height - menuStrip1.Height, Width);
            VideoControl.Player.InvalidateVisual();
        }

        private void fullscreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        public void SetVideo(string filePath)
        {
            FilePath = filePath;
            VideoControl.Player.Source = new Uri(filePath);
            VideoControl.Player.Play();
        }

        public VideoFeedback VideoControl
        {
            get
            {
                return (VideoFeedback)elementHost1.Child;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            long dur = VideoControl.Player.MediaDuration;
            VideoControl.Player.MediaPosition = ((trackBar1.Value * dur) / 500);
            VideoControl.Player.Play();
            button1.Text = "Play";
        }

        private void checkLoop_CheckedChanged(object sender, EventArgs e)
        {
            VideoControl.Player.Loop = checkLoop.Checked;
            if (checkLoop.Checked && !VideoControl.Player.IsPlaying)
            {
                VideoControl.Player.Play();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (VideoControl.Player.IsPlaying)
            {
                button1.Text = "Play";
                VideoControl.Player.Pause();
            }
            else
            {
                button1.Text = "Pause";
                VideoControl.Player.Play();
            }
        }
    }
}
