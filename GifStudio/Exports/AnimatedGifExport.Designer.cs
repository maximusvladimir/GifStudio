namespace GifStudio
{
    partial class AnimatedGifExport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnimatedGifExport));
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonColorPicker = new System.Windows.Forms.Button();
            this.checkBoxTransparency = new System.Windows.Forms.CheckBox();
            this.checkBoxLoop = new System.Windows.Forms.CheckBox();
            this.helpBoxCrop = new System.Windows.Forms.PictureBox();
            this.textBoxCropH = new System.Windows.Forms.TextBox();
            this.labelCrop = new System.Windows.Forms.Label();
            this.textBoxCropW = new System.Windows.Forms.TextBox();
            this.checkBoxCrop = new System.Windows.Forms.CheckBox();
            this.trimLength = new System.Windows.Forms.MaskedTextBox();
            this.labelTrim2 = new System.Windows.Forms.Label();
            this.trimStart = new System.Windows.Forms.MaskedTextBox();
            this.helpBoxFPS = new System.Windows.Forms.PictureBox();
            this.helpBoxTrim = new System.Windows.Forms.PictureBox();
            this.helpBoxQuality = new System.Windows.Forms.PictureBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labelTrim1 = new System.Windows.Forms.Label();
            this.checkBoxTrim = new System.Windows.Forms.CheckBox();
            this.labelQuality = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.helpBoxCrop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.helpBoxFPS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.helpBoxTrim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.helpBoxQuality)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Save destination:";
            // 
            // textBoxPath
            // 
            this.textBoxPath.Location = new System.Drawing.Point(107, 14);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(386, 20);
            this.textBoxPath.TabIndex = 1;
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(499, 12);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowse.TabIndex = 2;
            this.buttonBrowse.Text = "Browse";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonColorPicker);
            this.groupBox1.Controls.Add(this.checkBoxTransparency);
            this.groupBox1.Controls.Add(this.checkBoxLoop);
            this.groupBox1.Controls.Add(this.helpBoxCrop);
            this.groupBox1.Controls.Add(this.textBoxCropH);
            this.groupBox1.Controls.Add(this.labelCrop);
            this.groupBox1.Controls.Add(this.textBoxCropW);
            this.groupBox1.Controls.Add(this.checkBoxCrop);
            this.groupBox1.Controls.Add(this.trimLength);
            this.groupBox1.Controls.Add(this.labelTrim2);
            this.groupBox1.Controls.Add(this.trimStart);
            this.groupBox1.Controls.Add(this.helpBoxFPS);
            this.groupBox1.Controls.Add(this.helpBoxTrim);
            this.groupBox1.Controls.Add(this.helpBoxQuality);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.labelTrim1);
            this.groupBox1.Controls.Add(this.checkBoxTrim);
            this.groupBox1.Controls.Add(this.labelQuality);
            this.groupBox1.Controls.Add(this.trackBar1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(562, 252);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // buttonColorPicker
            // 
            this.buttonColorPicker.BackColor = System.Drawing.Color.Fuchsia;
            this.buttonColorPicker.Enabled = false;
            this.buttonColorPicker.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonColorPicker.Location = new System.Drawing.Point(113, 206);
            this.buttonColorPicker.Name = "buttonColorPicker";
            this.buttonColorPicker.Size = new System.Drawing.Size(30, 23);
            this.buttonColorPicker.TabIndex = 20;
            this.buttonColorPicker.UseVisualStyleBackColor = false;
            this.buttonColorPicker.Click += new System.EventHandler(this.buttonColorPicker_Click);
            // 
            // checkBoxTransparency
            // 
            this.checkBoxTransparency.AutoSize = true;
            this.checkBoxTransparency.Location = new System.Drawing.Point(9, 210);
            this.checkBoxTransparency.Name = "checkBoxTransparency";
            this.checkBoxTransparency.Size = new System.Drawing.Size(97, 17);
            this.checkBoxTransparency.TabIndex = 19;
            this.checkBoxTransparency.Text = "Transparency?";
            this.checkBoxTransparency.UseVisualStyleBackColor = true;
            this.checkBoxTransparency.CheckedChanged += new System.EventHandler(this.checkBoxTransparency_CheckedChanged);
            // 
            // checkBoxLoop
            // 
            this.checkBoxLoop.AutoSize = true;
            this.checkBoxLoop.Checked = true;
            this.checkBoxLoop.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxLoop.Location = new System.Drawing.Point(9, 182);
            this.checkBoxLoop.Name = "checkBoxLoop";
            this.checkBoxLoop.Size = new System.Drawing.Size(98, 17);
            this.checkBoxLoop.TabIndex = 18;
            this.checkBoxLoop.Text = "Loop animation";
            this.checkBoxLoop.UseVisualStyleBackColor = true;
            // 
            // helpBoxCrop
            // 
            this.helpBoxCrop.Image = global::GifStudio.Properties.Resources.help;
            this.helpBoxCrop.Location = new System.Drawing.Point(526, 133);
            this.helpBoxCrop.Name = "helpBoxCrop";
            this.helpBoxCrop.Size = new System.Drawing.Size(16, 16);
            this.helpBoxCrop.TabIndex = 17;
            this.helpBoxCrop.TabStop = false;
            this.helpBoxCrop.Click += new System.EventHandler(this.helpBoxCrop_Click);
            // 
            // textBoxCropH
            // 
            this.textBoxCropH.Enabled = false;
            this.textBoxCropH.Location = new System.Drawing.Point(115, 156);
            this.textBoxCropH.Name = "textBoxCropH";
            this.textBoxCropH.Size = new System.Drawing.Size(60, 20);
            this.textBoxCropH.TabIndex = 16;
            // 
            // labelCrop
            // 
            this.labelCrop.AutoSize = true;
            this.labelCrop.Enabled = false;
            this.labelCrop.Location = new System.Drawing.Point(95, 159);
            this.labelCrop.Name = "labelCrop";
            this.labelCrop.Size = new System.Drawing.Size(14, 13);
            this.labelCrop.TabIndex = 15;
            this.labelCrop.Text = "X";
            // 
            // textBoxCropW
            // 
            this.textBoxCropW.Enabled = false;
            this.textBoxCropW.Location = new System.Drawing.Point(26, 156);
            this.textBoxCropW.Name = "textBoxCropW";
            this.textBoxCropW.Size = new System.Drawing.Size(63, 20);
            this.textBoxCropW.TabIndex = 14;
            // 
            // checkBoxCrop
            // 
            this.checkBoxCrop.AutoSize = true;
            this.checkBoxCrop.Location = new System.Drawing.Point(9, 133);
            this.checkBoxCrop.Name = "checkBoxCrop";
            this.checkBoxCrop.Size = new System.Drawing.Size(61, 17);
            this.checkBoxCrop.TabIndex = 13;
            this.checkBoxCrop.Text = "Resize:";
            this.checkBoxCrop.UseVisualStyleBackColor = true;
            this.checkBoxCrop.CheckedChanged += new System.EventHandler(this.checkBoxCrop_CheckedChanged);
            // 
            // trimLength
            // 
            this.trimLength.Enabled = false;
            this.trimLength.Location = new System.Drawing.Point(199, 74);
            this.trimLength.Mask = "00:00:00";
            this.trimLength.Name = "trimLength";
            this.trimLength.Size = new System.Drawing.Size(61, 20);
            this.trimLength.TabIndex = 12;
            this.trimLength.Text = "000001";
            // 
            // labelTrim2
            // 
            this.labelTrim2.AutoSize = true;
            this.labelTrim2.Enabled = false;
            this.labelTrim2.Location = new System.Drawing.Point(150, 77);
            this.labelTrim2.Name = "labelTrim2";
            this.labelTrim2.Size = new System.Drawing.Size(43, 13);
            this.labelTrim2.TabIndex = 11;
            this.labelTrim2.Text = "Length:";
            // 
            // trimStart
            // 
            this.trimStart.Enabled = false;
            this.trimStart.Location = new System.Drawing.Point(82, 74);
            this.trimStart.Mask = "00:00:00";
            this.trimStart.Name = "trimStart";
            this.trimStart.Size = new System.Drawing.Size(61, 20);
            this.trimStart.TabIndex = 10;
            this.trimStart.Text = "000000";
            // 
            // helpBoxFPS
            // 
            this.helpBoxFPS.Image = global::GifStudio.Properties.Resources.help;
            this.helpBoxFPS.Location = new System.Drawing.Point(526, 103);
            this.helpBoxFPS.Name = "helpBoxFPS";
            this.helpBoxFPS.Size = new System.Drawing.Size(16, 16);
            this.helpBoxFPS.TabIndex = 9;
            this.helpBoxFPS.TabStop = false;
            this.helpBoxFPS.Click += new System.EventHandler(this.helpBoxFPS_Click);
            // 
            // helpBoxTrim
            // 
            this.helpBoxTrim.Image = global::GifStudio.Properties.Resources.help;
            this.helpBoxTrim.Location = new System.Drawing.Point(526, 58);
            this.helpBoxTrim.Name = "helpBoxTrim";
            this.helpBoxTrim.Size = new System.Drawing.Size(16, 16);
            this.helpBoxTrim.TabIndex = 8;
            this.helpBoxTrim.TabStop = false;
            this.helpBoxTrim.Click += new System.EventHandler(this.helpBoxTrim_Click);
            // 
            // helpBoxQuality
            // 
            this.helpBoxQuality.Image = global::GifStudio.Properties.Resources.help;
            this.helpBoxQuality.Location = new System.Drawing.Point(526, 22);
            this.helpBoxQuality.Name = "helpBoxQuality";
            this.helpBoxQuality.Size = new System.Drawing.Size(16, 16);
            this.helpBoxQuality.TabIndex = 7;
            this.helpBoxQuality.TabStop = false;
            this.helpBoxQuality.Click += new System.EventHandler(this.helpBoxQuality_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(91, 103);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(52, 20);
            this.textBox2.TabIndex = 6;
            this.textBox2.Text = "30";
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Targetted FPS:";
            // 
            // labelTrim1
            // 
            this.labelTrim1.AutoSize = true;
            this.labelTrim1.Enabled = false;
            this.labelTrim1.Location = new System.Drawing.Point(23, 77);
            this.labelTrim1.Name = "labelTrim1";
            this.labelTrim1.Size = new System.Drawing.Size(53, 13);
            this.labelTrim1.TabIndex = 4;
            this.labelTrim1.Text = "Trim start:";
            // 
            // checkBoxTrim
            // 
            this.checkBoxTrim.AutoSize = true;
            this.checkBoxTrim.Enabled = false;
            this.checkBoxTrim.Location = new System.Drawing.Point(9, 57);
            this.checkBoxTrim.Name = "checkBoxTrim";
            this.checkBoxTrim.Size = new System.Drawing.Size(49, 17);
            this.checkBoxTrim.TabIndex = 3;
            this.checkBoxTrim.Text = "Trim:";
            this.checkBoxTrim.UseVisualStyleBackColor = true;
            this.checkBoxTrim.CheckedChanged += new System.EventHandler(this.checkBoxTrim_CheckedChanged);
            // 
            // labelQuality
            // 
            this.labelQuality.AutoSize = true;
            this.labelQuality.Cursor = System.Windows.Forms.Cursors.Default;
            this.labelQuality.Location = new System.Drawing.Point(476, 24);
            this.labelQuality.Name = "labelQuality";
            this.labelQuality.Size = new System.Drawing.Size(19, 13);
            this.labelQuality.TabIndex = 2;
            this.labelQuality.Text = "50";
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 10;
            this.trackBar1.Location = new System.Drawing.Point(55, 16);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(415, 45);
            this.trackBar1.TabIndex = 1;
            this.trackBar1.Value = 50;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Quality:";
            // 
            // buttonSave
            // 
            this.buttonSave.Enabled = false;
            this.buttonSave.Location = new System.Drawing.Point(479, 298);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(95, 23);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Export";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(395, 298);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Enabled = false;
            this.progressBar1.Location = new System.Drawing.Point(8, 298);
            this.progressBar1.Maximum = 404;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(381, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 6;
            this.progressBar1.Value = 50;
            // 
            // AnimatedGifExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 343);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonBrowse);
            this.Controls.Add(this.textBoxPath);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(602, 371);
            this.MinimumSize = new System.Drawing.Size(602, 371);
            this.Name = "AnimatedGifExport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Save as Animated Gif";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.helpBoxCrop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.helpBoxFPS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.helpBoxTrim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.helpBoxQuality)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label labelQuality;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelTrim1;
        private System.Windows.Forms.CheckBox checkBoxTrim;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox helpBoxQuality;
        private System.Windows.Forms.PictureBox helpBoxFPS;
        private System.Windows.Forms.PictureBox helpBoxTrim;
        private System.Windows.Forms.MaskedTextBox trimLength;
        private System.Windows.Forms.Label labelTrim2;
        private System.Windows.Forms.MaskedTextBox trimStart;
        private System.Windows.Forms.TextBox textBoxCropH;
        private System.Windows.Forms.Label labelCrop;
        private System.Windows.Forms.TextBox textBoxCropW;
        private System.Windows.Forms.CheckBox checkBoxCrop;
        private System.Windows.Forms.PictureBox helpBoxCrop;
        private System.Windows.Forms.CheckBox checkBoxLoop;
        private System.Windows.Forms.Button buttonColorPicker;
        private System.Windows.Forms.CheckBox checkBoxTransparency;
    }
}