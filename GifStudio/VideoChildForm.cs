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
        }

        void scrubAnayliser_Tick(object sender, EventArgs e)
        {
            long pos = VideoControl.Player.MediaPosition;
            long dur = VideoControl.Player.MediaDuration;
            TimeSpan span = new TimeSpan(pos);
            timeElapsed.Text = span.Minutes + ":" + span.Seconds;

            span = new TimeSpan(dur);
            timeDuration.Text = span.Minutes + ":" + span.Seconds;

            if (dur != 0 && pos != 0)
            {
                trackBar1.Value = (int)(pos * 100 / dur);
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
    }
}
