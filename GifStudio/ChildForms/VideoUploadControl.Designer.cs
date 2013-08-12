namespace GifStudio.ChildForms
{
    partial class VideoUploadControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VideoUploadControl));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listBoxTags = new System.Windows.Forms.ListBox();
            this.textBoxTagAdder = new System.Windows.Forms.TextBox();
            this.buttonAddTag = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonPublish = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.linkLabelYouTubeTermsOfService = new System.Windows.Forms.LinkLabel();
            this.linkLabelSafety = new System.Windows.Forms.LinkLabel();
            this.buttonRemoveTag = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(254, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(160, 99);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Title:";
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(6, 22);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(198, 22);
            this.textBoxTitle.TabIndex = 2;
            this.textBoxTitle.Text = "MyMovie";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(6, 64);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(198, 22);
            this.textBoxDescription.TabIndex = 4;
            this.textBoxDescription.Text = "A movie I made.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Description:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tags:";
            // 
            // listBoxTags
            // 
            this.listBoxTags.FormattingEnabled = true;
            this.listBoxTags.Location = new System.Drawing.Point(6, 132);
            this.listBoxTags.Name = "listBoxTags";
            this.listBoxTags.Size = new System.Drawing.Size(198, 69);
            this.listBoxTags.TabIndex = 6;
            // 
            // textBoxTagAdder
            // 
            this.textBoxTagAdder.Location = new System.Drawing.Point(6, 105);
            this.textBoxTagAdder.Name = "textBoxTagAdder";
            this.textBoxTagAdder.Size = new System.Drawing.Size(118, 22);
            this.textBoxTagAdder.TabIndex = 7;
            // 
            // buttonAddTag
            // 
            this.buttonAddTag.Location = new System.Drawing.Point(130, 104);
            this.buttonAddTag.Name = "buttonAddTag";
            this.buttonAddTag.Size = new System.Drawing.Size(28, 23);
            this.buttonAddTag.TabIndex = 8;
            this.buttonAddTag.Text = "+";
            this.buttonAddTag.UseVisualStyleBackColor = true;
            this.buttonAddTag.Click += new System.EventHandler(this.buttonAddTag_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Category:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Comedy",
            "Education",
            "Entertainment",
            "Film & Animation",
            "Gaming",
            "Howto & Style",
            "Music",
            "News &; Politics",
            "Nonprofits & Activism",
            "People & Blogs",
            "Pets & Animals",
            "Science & Technology",
            "Sports",
            "Travel"});
            this.comboBox1.Location = new System.Drawing.Point(6, 220);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(198, 21);
            this.comboBox1.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 244);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Visibility:";
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Public",
            "Private"});
            this.comboBox2.Location = new System.Drawing.Point(6, 260);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(198, 21);
            this.comboBox2.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(210, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(243, 76);
            this.label6.TabIndex = 13;
            this.label6.Text = resources.GetString("label6.Text");
            // 
            // buttonPublish
            // 
            this.buttonPublish.Location = new System.Drawing.Point(307, 260);
            this.buttonPublish.Name = "buttonPublish";
            this.buttonPublish.Size = new System.Drawing.Size(75, 23);
            this.buttonPublish.TabIndex = 14;
            this.buttonPublish.Text = "Publish";
            this.buttonPublish.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(388, 260);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 15;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // linkLabelYouTubeTermsOfService
            // 
            this.linkLabelYouTubeTermsOfService.AutoSize = true;
            this.linkLabelYouTubeTermsOfService.Location = new System.Drawing.Point(264, 213);
            this.linkLabelYouTubeTermsOfService.Name = "linkLabelYouTubeTermsOfService";
            this.linkLabelYouTubeTermsOfService.Size = new System.Drawing.Size(135, 13);
            this.linkLabelYouTubeTermsOfService.TabIndex = 16;
            this.linkLabelYouTubeTermsOfService.TabStop = true;
            this.linkLabelYouTubeTermsOfService.Text = "YouTube Terms of Service";
            this.linkLabelYouTubeTermsOfService.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelYouTubeTermsOfService_LinkClicked);
            // 
            // linkLabelSafety
            // 
            this.linkLabelSafety.AutoSize = true;
            this.linkLabelSafety.Location = new System.Drawing.Point(280, 236);
            this.linkLabelSafety.Name = "linkLabelSafety";
            this.linkLabelSafety.Size = new System.Drawing.Size(102, 13);
            this.linkLabelSafety.TabIndex = 17;
            this.linkLabelSafety.TabStop = true;
            this.linkLabelSafety.Text = "Safety on YouTube";
            this.linkLabelSafety.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelSafety_LinkClicked);
            // 
            // buttonRemoveTag
            // 
            this.buttonRemoveTag.Location = new System.Drawing.Point(176, 104);
            this.buttonRemoveTag.Name = "buttonRemoveTag";
            this.buttonRemoveTag.Size = new System.Drawing.Size(28, 23);
            this.buttonRemoveTag.TabIndex = 18;
            this.buttonRemoveTag.Text = "-";
            this.buttonRemoveTag.UseVisualStyleBackColor = true;
            this.buttonRemoveTag.Click += new System.EventHandler(this.buttonRemoveTag_Click);
            // 
            // VideoUploadControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.buttonRemoveTag);
            this.Controls.Add(this.linkLabelSafety);
            this.Controls.Add(this.linkLabelYouTubeTermsOfService);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonPublish);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonAddTag);
            this.Controls.Add(this.textBoxTagAdder);
            this.Controls.Add(this.listBoxTags);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "VideoUploadControl";
            this.Size = new System.Drawing.Size(466, 286);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBoxTags;
        private System.Windows.Forms.TextBox textBoxTagAdder;
        private System.Windows.Forms.Button buttonAddTag;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonPublish;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.LinkLabel linkLabelYouTubeTermsOfService;
        private System.Windows.Forms.LinkLabel linkLabelSafety;
        private System.Windows.Forms.Button buttonRemoveTag;
    }
}
