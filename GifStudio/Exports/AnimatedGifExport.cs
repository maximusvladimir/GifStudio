using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GifStudio
{
    public partial class AnimatedGifExport : Form
    {
        public AnimatedGifExport(string file, int w, int h)
        {
            SourceFilePath = file;
            InitializeComponent();
            textBoxPath.TextChanged += textBoxPath_TextChanged;
            Width = w;
            Height = h;
            textBoxCropH.Text = h + "";
            textBoxCropW.Text = w + "";
        }

        public int Width
        {
            get;
            set;
        }

        public int Height
        {
            get;
            set;
        }

        void textBoxPath_TextChanged(object sender, EventArgs e)
        {
            if (DestinationFilePath != null && !string.IsNullOrEmpty(DestinationFilePath))
                buttonSave.Enabled = true;
            else
                buttonSave.Enabled = false;
            DestinationFilePath = textBoxPath.Text;
        }

        public string SourceFilePath
        {
            get;
            set;
        }

        public string DestinationFilePath
        {
            get;
            set;
        }

        public int FPS
        {
            get;
            set;
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.AutoUpgradeEnabled = true;
            save.AddExtension = true;
            save.CheckPathExists = true;
            save.CheckFileExists = false;
            save.Filter = "Animated GIF file (*.gif)|*.gif";
            save.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            save.OverwritePrompt = true;
            save.RestoreDirectory = true;
            save.Title = "Find save destination.";
            save.ShowDialog();

            DestinationFilePath = save.FileName;
            textBoxPath.Text = DestinationFilePath;
            if (DestinationFilePath != null && !string.IsNullOrEmpty(DestinationFilePath))
                buttonSave.Enabled = true;
            else
                buttonSave.Enabled = false;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            labelQuality.Text = trackBar1.Value + "";
        }

        private void helpBoxQuality_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "Sets the quality of the GIF to be produced.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void helpBoxTrim_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "Changes the length and where the video starts.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void helpBoxFPS_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "Sets the number of images to be displayed in one second.\n30 is the default.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string t = textBox2.Text;
            if (t.IndexOf(" ") > -1)
                t = t.Replace(" ", "");
            if (t == "")
                return;
            int tfps = 0;
            try
            {
                tfps = int.Parse(textBox2.Text);
            }
            catch (Exception)
            {
                MessageBox.Show(this,"Must only contain integers (1-30).", "Error - Invalid input.",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

            if (tfps <= 0 || tfps > 30)
            {
                MessageBox.Show(this, "Must only contain integers (1-30).", "Error - Invalid input.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBoxTrim_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTrim.Checked)
            {
                trimLength.Enabled = true;
                trimStart.Enabled = true;
                labelTrim1.Enabled = true;
                labelTrim2.Enabled = true;
            }
            else
            {
                trimLength.Enabled = false;
                trimStart.Enabled = false;
                labelTrim1.Enabled = false;
                labelTrim2.Enabled = false;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void helpBoxCrop_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "Should the size of the GIF be increased or decreased from the original video size?", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void checkBoxCrop_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCrop.Checked)
            {
                labelCrop.Enabled = true;
                textBoxCropW.Enabled = true;
                textBoxCropH.Enabled = true;
            }
            else
            {
                labelCrop.Enabled = false;
                textBoxCropW.Enabled = false;
                textBoxCropH.Enabled = false;
            }
        }
    }
}
