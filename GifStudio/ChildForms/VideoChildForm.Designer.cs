namespace GifStudio
{
    partial class VideoChildForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VideoChildForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.trackBar1 = new MediaSlider.MediaSlider();
            this.timeDuration = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonFullscreen = new System.Windows.Forms.Button();
            this.buttonPlayPause = new System.Windows.Forms.Button();
            this.timeElapsed = new System.Windows.Forms.Label();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.loopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.trackBar1);
            this.panel1.Controls.Add(this.timeDuration);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.timeElapsed);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 312);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(463, 39);
            this.panel1.TabIndex = 2;
            // 
            // trackBar1
            // 
            this.trackBar1.Animated = true;
            this.trackBar1.AnimationSize = 0.2F;
            this.trackBar1.AnimationSpeed = MediaSlider.MediaSlider.AnimateSpeed.Normal;
            this.trackBar1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.trackBar1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.trackBar1.BackColor = System.Drawing.Color.Transparent;
            this.trackBar1.BackGroundImage = null;
            this.trackBar1.ButtonAccentColor = System.Drawing.Color.SlateGray;
            this.trackBar1.ButtonBorderColor = System.Drawing.Color.Black;
            this.trackBar1.ButtonColor = System.Drawing.Color.SteelBlue;
            this.trackBar1.ButtonCornerRadius = ((uint)(6u));
            this.trackBar1.ButtonSize = new System.Drawing.Size(20, 10);
            this.trackBar1.ButtonStyle = MediaSlider.MediaSlider.ButtonType.RoundedRectInline;
            this.trackBar1.ContextMenuStrip = null;
            this.trackBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackBar1.LargeChange = 0;
            this.trackBar1.Location = new System.Drawing.Point(28, 0);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(0);
            this.trackBar1.Maximum = 500;
            this.trackBar1.Minimum = 0;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.trackBar1.ShowButtonOnHover = true;
            this.trackBar1.Size = new System.Drawing.Size(317, 39);
            this.trackBar1.SliderFlyOut = MediaSlider.MediaSlider.FlyOutStyle.None;
            this.trackBar1.SmallChange = 0;
            this.trackBar1.SmoothScrolling = false;
            this.trackBar1.TabIndex = 4;
            this.trackBar1.TickColor = System.Drawing.Color.DarkGray;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.TickType = MediaSlider.MediaSlider.TickMode.Standard;
            this.trackBar1.TrackBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.trackBar1.TrackDepth = 4;
            this.trackBar1.TrackFillColor = System.Drawing.Color.Transparent;
            this.trackBar1.TrackProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(101)))), ((int)(((byte)(188)))));
            this.trackBar1.TrackShadow = false;
            this.trackBar1.TrackShadowColor = System.Drawing.Color.DarkGray;
            this.trackBar1.TrackStyle = MediaSlider.MediaSlider.TrackType.Progress;
            this.trackBar1.Value = 0;
            // 
            // timeDuration
            // 
            this.timeDuration.AutoSize = true;
            this.timeDuration.Dock = System.Windows.Forms.DockStyle.Right;
            this.timeDuration.ForeColor = System.Drawing.Color.White;
            this.timeDuration.Location = new System.Drawing.Point(345, 0);
            this.timeDuration.Name = "timeDuration";
            this.timeDuration.Padding = new System.Windows.Forms.Padding(0, 11, 0, 0);
            this.timeDuration.Size = new System.Drawing.Size(28, 24);
            this.timeDuration.TabIndex = 3;
            this.timeDuration.Text = "0:00";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonFullscreen);
            this.panel2.Controls.Add(this.buttonPlayPause);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(373, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(90, 39);
            this.panel2.TabIndex = 2;
            // 
            // buttonFullscreen
            // 
            this.buttonFullscreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFullscreen.Image = global::GifStudio.Properties.Resources.fullscreenicon;
            this.buttonFullscreen.Location = new System.Drawing.Point(44, 0);
            this.buttonFullscreen.Name = "buttonFullscreen";
            this.buttonFullscreen.Size = new System.Drawing.Size(43, 39);
            this.buttonFullscreen.TabIndex = 1;
            this.buttonFullscreen.UseVisualStyleBackColor = true;
            this.buttonFullscreen.Click += new System.EventHandler(this.buttonFullscreen_Click);
            // 
            // buttonPlayPause
            // 
            this.buttonPlayPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPlayPause.Image = global::GifStudio.Properties.Resources._1376336478_gtk_media_pause;
            this.buttonPlayPause.Location = new System.Drawing.Point(0, 0);
            this.buttonPlayPause.Name = "buttonPlayPause";
            this.buttonPlayPause.Size = new System.Drawing.Size(43, 39);
            this.buttonPlayPause.TabIndex = 0;
            this.buttonPlayPause.UseVisualStyleBackColor = true;
            this.buttonPlayPause.Click += new System.EventHandler(this.button1_Click);
            // 
            // timeElapsed
            // 
            this.timeElapsed.AutoSize = true;
            this.timeElapsed.Dock = System.Windows.Forms.DockStyle.Left;
            this.timeElapsed.ForeColor = System.Drawing.Color.White;
            this.timeElapsed.Location = new System.Drawing.Point(0, 0);
            this.timeElapsed.Name = "timeElapsed";
            this.timeElapsed.Padding = new System.Windows.Forms.Padding(0, 11, 0, 0);
            this.timeElapsed.Size = new System.Drawing.Size(28, 24);
            this.timeElapsed.TabIndex = 1;
            this.timeElapsed.Text = "0:00";
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(0, 0);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(463, 312);
            this.axWindowsMediaPlayer1.TabIndex = 3;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loopToolStripMenuItem,
            this.toolStripSeparator1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(102, 32);
            // 
            // loopToolStripMenuItem
            // 
            this.loopToolStripMenuItem.Checked = true;
            this.loopToolStripMenuItem.CheckOnClick = true;
            this.loopToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.loopToolStripMenuItem.Name = "loopToolStripMenuItem";
            this.loopToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.loopToolStripMenuItem.Text = "Loop";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(98, 6);
            // 
            // VideoChildForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(463, 351);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VideoChildForm";
            this.Text = "VideoChildForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private MediaSlider.MediaSlider trackBar1;
        private System.Windows.Forms.Label timeDuration;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label timeElapsed;
        private System.Windows.Forms.Button buttonPlayPause;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem loopToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Button buttonFullscreen;
    }
}