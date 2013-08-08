namespace GifStudio.ChildForms
{
    partial class YoutubeVideoUploaderChildForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YoutubeVideoUploaderChildForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelLogin = new System.Windows.Forms.Panel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.labelFailReason = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.labelUsername = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBoxAnimation = new System.Windows.Forms.PictureBox();
            this.panelLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAnimation)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Red;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(466, 10);
            this.panel1.TabIndex = 0;
            // 
            // panelLogin
            // 
            this.panelLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelLogin.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLogin.Controls.Add(this.linkLabel2);
            this.panelLogin.Controls.Add(this.linkLabel1);
            this.panelLogin.Controls.Add(this.buttonLogin);
            this.panelLogin.Controls.Add(this.labelFailReason);
            this.panelLogin.Controls.Add(this.labelPassword);
            this.panelLogin.Controls.Add(this.textBoxPassword);
            this.panelLogin.Controls.Add(this.textBoxUsername);
            this.panelLogin.Controls.Add(this.labelUsername);
            this.panelLogin.Location = new System.Drawing.Point(111, 40);
            this.panelLogin.Margin = new System.Windows.Forms.Padding(400);
            this.panelLogin.MaximumSize = new System.Drawing.Size(245, 245);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(245, 225);
            this.panelLogin.TabIndex = 1;
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel2.Location = new System.Drawing.Point(78, 172);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(86, 15);
            this.linkLabel2.TabIndex = 8;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Need account?";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(37, 147);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(169, 15);
            this.linkLabel1.TabIndex = 7;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Forgot username or password?";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // buttonLogin
            // 
            this.buttonLogin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonLogin.Location = new System.Drawing.Point(74, 115);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(95, 23);
            this.buttonLogin.TabIndex = 6;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // labelFailReason
            // 
            this.labelFailReason.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFailReason.Location = new System.Drawing.Point(3, 191);
            this.labelFailReason.Name = "labelFailReason";
            this.labelFailReason.Size = new System.Drawing.Size(237, 30);
            this.labelFailReason.TabIndex = 5;
            this.labelFailReason.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPassword.Location = new System.Drawing.Point(69, 61);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(105, 15);
            this.labelPassword.TabIndex = 4;
            this.labelPassword.Text = "Youtube Password";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPassword.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPassword.Location = new System.Drawing.Point(49, 83);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(144, 23);
            this.textBoxPassword.TabIndex = 3;
            this.textBoxPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxUsername.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUsername.Location = new System.Drawing.Point(49, 29);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(144, 25);
            this.textBoxUsername.TabIndex = 1;
            this.textBoxUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsername.Location = new System.Drawing.Point(67, 6);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(108, 15);
            this.labelUsername.TabIndex = 0;
            this.labelUsername.Text = "Youtube Username";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Red;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 295);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(466, 10);
            this.panel3.TabIndex = 1;
            // 
            // pictureBoxAnimation
            // 
            this.pictureBoxAnimation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxAnimation.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxAnimation.Name = "pictureBoxAnimation";
            this.pictureBoxAnimation.Size = new System.Drawing.Size(466, 305);
            this.pictureBoxAnimation.TabIndex = 2;
            this.pictureBoxAnimation.TabStop = false;
            // 
            // YoutubeVideoUploaderChildForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(466, 305);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panelLogin);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBoxAnimation);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "YoutubeVideoUploaderChildForm";
            this.ShowInTaskbar = false;
            this.Text = "Upload video to YouTube";
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAnimation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelLogin;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Label labelFailReason;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.PictureBox pictureBoxAnimation;
    }
}