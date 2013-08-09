using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GifStudio.ChildForms
{
    public partial class VideoUploadControl : UserControl
    {
        public VideoUploadControl()
        {
            InitializeComponent();
            Paint += VideoUploadControl_Paint;
        }

        void VideoUploadControl_Paint(object sender, PaintEventArgs e)
        {
            if (Opacity == 100)
                return;
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(Opacity * 255 / 100, Color.White)), 0, 0, Width, Height);
            }
        }

        public int Opacity
        {
            get;
            set;
        }

        private void buttonAddTag_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxTagAdder.Text))
                return;
            string process = textBoxTagAdder.Text;
            string nt = "";
            for (int c = 0; c < process.Length; c++)
            {
                if (char.IsLetterOrDigit(process[c]))
                    nt += process[c];
            }
            if (!string.IsNullOrEmpty(nt))
                return;
            listBoxTags.Items.Add(nt);
            textBoxTagAdder.Text = "";
        }

        private void buttonRemoveTag_Click(object sender, EventArgs e)
        {
            if (listBoxTags.SelectedIndex >= 0 && listBoxTags.SelectedIndex < listBoxTags.Items.Count)
            {
                listBoxTags.Items.RemoveAt(listBoxTags.SelectedIndex);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            
        }

        private void linkLabelYouTubeTermsOfService_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://www.youtube.com/t/terms");
            }
            catch (Exception)
            { }
        }

        private void linkLabelSafety_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://www.youtube.com/yt/policyandsafety/");
            }
            catch (Exception)
            { }
        }
    }
}
