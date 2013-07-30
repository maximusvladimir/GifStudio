namespace GifStudio.ChildForms
{
    partial class FLVChildForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FLVChildForm));
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.boxURL = new System.Windows.Forms.TextBox();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.buttonPaste = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.prxyNumericPort = new System.Windows.Forms.NumericUpDown();
            this.prxyLabelPort = new System.Windows.Forms.Label();
            this.prxyTextBoxAddress = new System.Windows.Forms.TextBox();
            this.checkBoxUseProxy = new System.Windows.Forms.CheckBox();
            this.prxyLabelAddress = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prxyNumericPort)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "URL to scan:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(9, 19);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(152, 17);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "Download &first video found";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // boxURL
            // 
            this.boxURL.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.boxURL.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.AllUrl;
            this.boxURL.Location = new System.Drawing.Point(88, 6);
            this.boxURL.Name = "boxURL";
            this.boxURL.Size = new System.Drawing.Size(225, 20);
            this.boxURL.TabIndex = 1;
            this.boxURL.TextChanged += new System.EventHandler(this.boxURL_TextChanged);
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(319, 4);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(113, 23);
            this.buttonBrowse.TabIndex = 2;
            this.buttonBrowse.Text = "Open Browser";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // buttonPaste
            // 
            this.buttonPaste.Location = new System.Drawing.Point(438, 4);
            this.buttonPaste.Name = "buttonPaste";
            this.buttonPaste.Size = new System.Drawing.Size(112, 23);
            this.buttonPaste.TabIndex = 3;
            this.buttonPaste.Text = "Paste Clipboard";
            this.buttonPaste.UseVisualStyleBackColor = true;
            this.buttonPaste.Click += new System.EventHandler(this.buttonPaste_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 91);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Enabled = false;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Best avaliable",
            "High",
            "Medium",
            "Low"});
            this.comboBox1.Location = new System.Drawing.Point(9, 62);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(244, 21);
            this.comboBox1.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Download quality (If avaliable):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(378, 91);
            this.label2.TabIndex = 6;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(438, 185);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(112, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "Download";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(438, 156);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(112, 23);
            this.button4.TabIndex = 8;
            this.button4.Text = "Cancel";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(438, 127);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(112, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 9;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.prxyNumericPort);
            this.groupBox2.Controls.Add(this.prxyLabelPort);
            this.groupBox2.Controls.Add(this.prxyTextBoxAddress);
            this.groupBox2.Controls.Add(this.checkBoxUseProxy);
            this.groupBox2.Controls.Add(this.prxyLabelAddress);
            this.groupBox2.Location = new System.Drawing.Point(277, 33);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(273, 90);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Proxy";
            // 
            // prxyNumericPort
            // 
            this.prxyNumericPort.Enabled = false;
            this.prxyNumericPort.Location = new System.Drawing.Point(85, 61);
            this.prxyNumericPort.Maximum = new decimal(new int[] {
            35000,
            0,
            0,
            0});
            this.prxyNumericPort.Name = "prxyNumericPort";
            this.prxyNumericPort.Size = new System.Drawing.Size(182, 20);
            this.prxyNumericPort.TabIndex = 4;
            this.prxyNumericPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.prxyNumericPort.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            // 
            // prxyLabelPort
            // 
            this.prxyLabelPort.AutoSize = true;
            this.prxyLabelPort.Enabled = false;
            this.prxyLabelPort.Location = new System.Drawing.Point(31, 61);
            this.prxyLabelPort.Name = "prxyLabelPort";
            this.prxyLabelPort.Size = new System.Drawing.Size(29, 13);
            this.prxyLabelPort.TabIndex = 3;
            this.prxyLabelPort.Text = "Port:";
            // 
            // prxyTextBoxAddress
            // 
            this.prxyTextBoxAddress.Enabled = false;
            this.prxyTextBoxAddress.Location = new System.Drawing.Point(85, 35);
            this.prxyTextBoxAddress.Name = "prxyTextBoxAddress";
            this.prxyTextBoxAddress.Size = new System.Drawing.Size(181, 20);
            this.prxyTextBoxAddress.TabIndex = 2;
            // 
            // checkBoxUseProxy
            // 
            this.checkBoxUseProxy.AutoSize = true;
            this.checkBoxUseProxy.Location = new System.Drawing.Point(6, 18);
            this.checkBoxUseProxy.Name = "checkBoxUseProxy";
            this.checkBoxUseProxy.Size = new System.Drawing.Size(73, 17);
            this.checkBoxUseProxy.TabIndex = 1;
            this.checkBoxUseProxy.Text = "&Use proxy";
            this.checkBoxUseProxy.UseVisualStyleBackColor = true;
            this.checkBoxUseProxy.CheckedChanged += new System.EventHandler(this.checkBoxUseProxy_CheckedChanged);
            // 
            // prxyLabelAddress
            // 
            this.prxyLabelAddress.AutoSize = true;
            this.prxyLabelAddress.Enabled = false;
            this.prxyLabelAddress.Location = new System.Drawing.Point(31, 38);
            this.prxyLabelAddress.Name = "prxyLabelAddress";
            this.prxyLabelAddress.Size = new System.Drawing.Size(48, 13);
            this.prxyLabelAddress.TabIndex = 0;
            this.prxyLabelAddress.Text = "Address:";
            // 
            // FLVChildForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 233);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonPaste);
            this.Controls.Add(this.buttonBrowse);
            this.Controls.Add(this.boxURL);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FLVChildForm";
            this.Text = "FLVChildForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prxyNumericPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox boxURL;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Button buttonPaste;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown prxyNumericPort;
        private System.Windows.Forms.Label prxyLabelPort;
        private System.Windows.Forms.TextBox prxyTextBoxAddress;
        private System.Windows.Forms.CheckBox checkBoxUseProxy;
        private System.Windows.Forms.Label prxyLabelAddress;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label5;
    }
}