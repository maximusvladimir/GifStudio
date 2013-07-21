﻿namespace GifStudio
{
    partial class FrameExport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrameExport));
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.helpBoxExample = new System.Windows.Forms.PictureBox();
            this.helpBoxFileType = new System.Windows.Forms.PictureBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.textBoxNameConvention = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.helpBoxExample)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.helpBoxFileType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
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
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Folder destination:";
            // 
            // textBoxPath
            // 
            this.textBoxPath.Location = new System.Drawing.Point(111, 14);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(382, 20);
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
            this.groupBox1.Controls.Add(this.helpBoxExample);
            this.groupBox1.Controls.Add(this.helpBoxFileType);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.textBoxNameConvention);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label4);
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
            this.groupBox1.Size = new System.Drawing.Size(562, 289);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // helpBoxExample
            // 
            this.helpBoxExample.Image = global::GifStudio.Properties.Resources.help;
            this.helpBoxExample.Location = new System.Drawing.Point(526, 245);
            this.helpBoxExample.Name = "helpBoxExample";
            this.helpBoxExample.Size = new System.Drawing.Size(16, 16);
            this.helpBoxExample.TabIndex = 28;
            this.helpBoxExample.TabStop = false;
            this.helpBoxExample.Click += new System.EventHandler(this.helpBoxExample_Click);
            // 
            // helpBoxFileType
            // 
            this.helpBoxFileType.Image = global::GifStudio.Properties.Resources.help;
            this.helpBoxFileType.Location = new System.Drawing.Point(526, 189);
            this.helpBoxFileType.Name = "helpBoxFileType";
            this.helpBoxFileType.Size = new System.Drawing.Size(16, 16);
            this.helpBoxFileType.TabIndex = 27;
            this.helpBoxFileType.TabStop = false;
            this.helpBoxFileType.Click += new System.EventHandler(this.helpBoxFileType_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(136, 241);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(39, 20);
            this.numericUpDown1.TabIndex = 26;
            this.numericUpDown1.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 243);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Number of leading zeros:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 265);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Example: img001.png";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(277, 217);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(56, 17);
            this.radioButton2.TabIndex = 23;
            this.radioButton2.Text = "Postfix";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(220, 217);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(51, 17);
            this.radioButton1.TabIndex = 22;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Prefix";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // textBoxNameConvention
            // 
            this.textBoxNameConvention.Location = new System.Drawing.Point(114, 216);
            this.textBoxNameConvention.Name = "textBoxNameConvention";
            this.textBoxNameConvention.Size = new System.Drawing.Size(100, 20);
            this.textBoxNameConvention.TabIndex = 21;
            this.textBoxNameConvention.TextChanged += new System.EventHandler(this.textBoxNameConvention_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 219);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Naming convention:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "PNG (W3C Portable Network Graphics)",
            "JPEG (Joint Photographic Experts Group)",
            "BMP (Bitmap)",
            "TIFF (Tagged Image File Format)",
            "WMF (Windows metafile)",
            "EXIF (Exchangeable Image File)",
            "GIF (Graphics Interchange Format) (Non-animated)"});
            this.comboBox1.Location = new System.Drawing.Point(55, 186);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(302, 21);
            this.comboBox1.TabIndex = 19;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "File type:";
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
            this.buttonSave.Location = new System.Drawing.Point(480, 335);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(94, 23);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Export";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(399, 335);
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
            this.progressBar1.Location = new System.Drawing.Point(8, 335);
            this.progressBar1.Maximum = 404;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(385, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 6;
            // 
            // FrameExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 379);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonBrowse);
            this.Controls.Add(this.textBoxPath);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(602, 407);
            this.MinimumSize = new System.Drawing.Size(602, 407);
            this.Name = "FrameExport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Save frames";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.helpBoxExample)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.helpBoxFileType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
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
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TextBox textBoxNameConvention;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox helpBoxExample;
        private System.Windows.Forms.PictureBox helpBoxFileType;
    }
}