using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GifStudio
{
    /// <summary>
    /// TODO: For every property getting or setting for Player, catch for "COM object that has been separated from its underlying RCW cannot be used."
    /// </summary>
    public partial class VideoChildForm : Form
    {
        Timer scrubAnayliser;
        
        public VideoChildForm()
        {
            InitializeComponent();
            DoChildResize();
            Resize += VideoChildForm_Resize;
            //VideoControl.Player.Loop = true;
            Player.enableContextMenu = false;
            Player.ContextMenuStrip = null;
            Player.uiMode = "none";
            Player.stretchToFit = true;
            Player.settings.enableErrorDialogs = false;
            Player.StatusChange += delegate(object sender, EventArgs args)
            {
                //System.Diagnostics.Debug.WriteLine(Player.status);
                /*
                
                
                Connecting...
                Connecting...
                Playing 'coyote caught on a fence': 258 K bits/second
                Playing 'coyote caught on a fence': 258 K bits/second
                 */
            };
            scrubAnayliser = new Timer();
            scrubAnayliser.Enabled = true;
            scrubAnayliser.Interval = 150;
            scrubAnayliser.Tick += scrubAnayliser_Tick;
            scrubAnayliser.Start();

            trackBar1.MouseMove += trackBar1_MouseMove;

            FormClosed += VideoChildForm_FormClosed;
        }

        void VideoChildForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            scrubAnayliser.Enabled = false;
            scrubAnayliser.Stop();
            try
            {
                if (!IsDisposed)
                    Dispose();
            }
            catch (Exception)
            { }
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
        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        bool internalFullscreen = false;
        FormWindowState prevState;
        Form oldParent;
        Size oldSize;
        public bool Fullscreen
        {
            get
            {
                return internalFullscreen;
            }
            set
            {
                internalFullscreen = value;
                if (internalFullscreen)
                {
                    oldParent = MdiParent;
                    oldSize = Size;
                    SetParent(Handle, IntPtr.Zero);
                    MdiParent = null;
                    Location = oldParent.Location;
                    TopMost = true;
                    FormBorderStyle = FormBorderStyle.None;
                    prevState = WindowState;
                    WindowState = FormWindowState.Maximized;
                }
                else
                {
                    TopMost = false;
                    WindowState = prevState;
                    FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                    MdiParent = oldParent;
                    //SetParent(Handle, oldParent.Handle);
                    MdiParent = oldParent;
                    Size = oldSize;
                }
            }
        }

        private void trackBar1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                trackBar1_Scroll(null, null);
        }

        public TimeSpan VideoDuration
        {
            get;
            set;
        }

        private void scrubAnayliser_Tick(object sender, EventArgs e)
        {
            if (VideoDuration == TimeSpan.Zero)
            {
                try
                {
                    string dyu = Player.currentMedia.durationString;
                    if (!string.IsNullOrEmpty(dyu))
                    {
                        int crs = 0;
                        if (dyu.IndexOf(":") > -1)
                        {
                            crs = dyu.Length - dyu.Replace(":", "").Length;
                        }
                        if (crs == 1)
                            dyu = "00:" + dyu;
                        VideoDuration = TimeSpan.Parse(dyu);
                    }
                }
                catch (Exception)
                { }
            }
            TimeSpan span = TimeSpan.Zero;
            try
            {
                string dyu = Player.Ctlcontrols.currentPositionString;
                if (!string.IsNullOrEmpty(dyu))
                {
                    int crs = 0;
                    if (dyu.IndexOf(":") > -1)
                    {
                        crs = dyu.Length - dyu.Replace(":", "").Length;
                    }
                    if (crs == 1)
                        dyu = "00:" + dyu;
                    span = TimeSpan.Parse(dyu);
                }
            }
            catch (Exception)
            { }
            timeElapsed.Text = span.Hours.ToString("D2") + ":" + span.Minutes.ToString("D2") + 
                ":" + span.Seconds.ToString("D2");

            TimeSpan dur = VideoDuration;
            timeDuration.Text = dur.Hours.ToString("D2") + ":" + dur.Minutes.ToString("D2") +
                ":" + dur.Seconds.ToString("D2");

            if (dur.TotalMilliseconds != 0 && span.TotalMilliseconds != 0)
            {
                int yu = (int)(span.TotalMilliseconds * trackBar1.Maximum / dur.TotalMilliseconds);
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
            Player.Width = Width;
            Player.Height = Height - (panel1.Height + 39);
            Invalidate(true);
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
                        PlayingState = PlayerState.Play;
                        try
                        {
                            string dyu = Player.currentMedia.durationString;
                            if (!string.IsNullOrEmpty(dyu))
                            {
                                int crs = 0;
                                if (dyu.IndexOf(":") > -1)
                                {
                                    crs = dyu.Length - dyu.Replace(":", "").Length;
                                }
                                if (crs == 1)
                                    dyu = "00:" + dyu;
                                VideoDuration = TimeSpan.Parse(dyu);
                            }
                        }
                        catch (Exception)
                        { }
                        Player.Width = Width;
                        Player.Height = Height - (panel1.Height + 39);
                    });
                }));
            thread.Start();
        }

        private void InternalPlayerState(PlayerState state)
        {
            if (state == PlayerState.Play)
                Player.Ctlcontrols.play();
            else if (state == PlayerState.Pause)
                Player.Ctlcontrols.pause();
        }

        PlayerState state;
        public PlayerState PlayingState
        {
            set
            {
                state = value;
                InternalPlayerState(state);
                if (state == PlayerState.Play)
                {
                    buttonPlayPause.Image = global::GifStudio.Properties.Resources._1376336478_gtk_media_pause;
                }
                else if (state == PlayerState.Pause)
                {
                    buttonPlayPause.Image = global::GifStudio.Properties.Resources._1376336525_gtk_media_play_ltr;
                }
            }
            get
            {
                return state;
            }
        }
        bool lastSdf = false;
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            try
            {
                double dur = Player.currentMedia.duration;
                InternalPlayerState(PlayerState.Pause);
                Player.Ctlcontrols.currentPosition = (trackBar1.Value * dur) / trackBar1.Maximum;
                PlayingState = PlayerState.Play;
                if (lastSdf)
                {
                    lastSdf = false;
                    Size = new Size(Size.Width - 1, Size.Height - 1);
                }
                else
                {
                    lastSdf = true;
                    Size = new Size(Size.Width + 1, Size.Height + 1);
                }
            }
            catch (Exception)
            { }

        }

        private void checkLoop_CheckedChanged(object sender, EventArgs e)
        {
            /*VideoControl.Player. = checkLoop.Checked;
            if (checkLoop.Checked && !VideoControl.Player.IsPlaying)
            {
                VideoControl.Player.Play();
            }*/
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (PlayingState == GifStudio.PlayerState.Play)
            {
                PlayingState = PlayerState.Pause;
            }
            else
            {
                PlayingState = PlayerState.Play;
            }
        }

        private void buttonFullscreen_Click(object sender, EventArgs e)
        {
            if (Fullscreen)
                buttonFullscreen.Image =  global::GifStudio.Properties.Resources.fullscreenicon;
            else
                buttonFullscreen.Image = global::GifStudio.Properties.Resources.fullscreeniconhide;
            Fullscreen = !Fullscreen;
        }
    }

    public enum PlayerState
    {
        Play,
        Pause,
        Error
    }
}
