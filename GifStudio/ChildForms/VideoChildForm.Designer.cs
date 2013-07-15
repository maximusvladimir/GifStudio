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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VideoChildForm));
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.videoFeedback1 = new GifStudio.VideoFeedback();
            this.panel1 = new System.Windows.Forms.Panel();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.timeDuration = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.timeElapsed = new System.Windows.Forms.Label();
            this.checkLoop = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // elementHost1
            // 
            this.elementHost1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementHost1.Location = new System.Drawing.Point(0, 0);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(463, 312);
            this.elementHost1.TabIndex = 1;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.videoFeedback1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.trackBar1);
            this.panel1.Controls.Add(this.timeDuration);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.timeElapsed);
            this.panel1.Controls.Add(this.checkLoop);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 312);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(463, 39);
            this.panel1.TabIndex = 2;
            // 
            // trackBar1
            // 
            this.trackBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackBar1.Location = new System.Drawing.Point(93, 0);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(229, 39);
            this.trackBar1.TabIndex = 4;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // timeDuration
            // 
            this.timeDuration.AutoSize = true;
            this.timeDuration.Dock = System.Windows.Forms.DockStyle.Right;
            this.timeDuration.Location = new System.Drawing.Point(322, 0);
            this.timeDuration.Name = "timeDuration";
            this.timeDuration.Padding = new System.Windows.Forms.Padding(0, 11, 0, 0);
            this.timeDuration.Size = new System.Drawing.Size(28, 24);
            this.timeDuration.TabIndex = 3;
            this.timeDuration.Text = "0:00";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(350, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(113, 39);
            this.panel2.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Pause";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timeElapsed
            // 
            this.timeElapsed.AutoSize = true;
            this.timeElapsed.Dock = System.Windows.Forms.DockStyle.Left;
            this.timeElapsed.Location = new System.Drawing.Point(65, 0);
            this.timeElapsed.Name = "timeElapsed";
            this.timeElapsed.Padding = new System.Windows.Forms.Padding(0, 11, 0, 0);
            this.timeElapsed.Size = new System.Drawing.Size(28, 24);
            this.timeElapsed.TabIndex = 1;
            this.timeElapsed.Text = "0:00";
            // 
            // checkLoop
            // 
            this.checkLoop.AutoSize = true;
            this.checkLoop.Checked = true;
            this.checkLoop.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkLoop.Dock = System.Windows.Forms.DockStyle.Left;
            this.checkLoop.Location = new System.Drawing.Point(0, 0);
            this.checkLoop.Name = "checkLoop";
            this.checkLoop.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.checkLoop.Size = new System.Drawing.Size(65, 39);
            this.checkLoop.TabIndex = 0;
            this.checkLoop.Text = "Loop?";
            this.checkLoop.UseVisualStyleBackColor = true;
            this.checkLoop.CheckedChanged += new System.EventHandler(this.checkLoop_CheckedChanged);
            // 
            // VideoChildForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 351);
            this.Controls.Add(this.elementHost1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VideoChildForm";
            this.Text = "VideoChildForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private VideoFeedback videoFeedback1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkLoop;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label timeDuration;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label timeElapsed;
        private System.Windows.Forms.Button button1;

    }
}