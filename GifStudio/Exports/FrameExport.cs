using Gifbrary.Common;
using Gifbrary.Converter;
using Gifbrary.Reader;
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
    public partial class FrameExport : Form
    {
        public FrameExport(string file, int w, int h)
        {
            ExportData = new Exportable();
            ExportData.SourceFilePath = file;
            InitializeComponent();
            textBoxPath.TextChanged += textBoxPath_TextChanged;
            Width = w;
            Height = h;
            textBoxCropH.Text = h + "";
            textBoxCropW.Text = w + "";

            ExportData.Quality = 50;
            ExportData.FPS = 30;
        }

        public Exportable ExportData
        {
            get;
            set;
        }

        void textBoxPath_TextChanged(object sender, EventArgs e)
        {
            if (ExportData.DestinationFilePath != null && !string.IsNullOrEmpty(ExportData.DestinationFilePath))
                buttonSave.Enabled = true;
            else
                buttonSave.Enabled = false;
            ExportData.DestinationFilePath = textBoxPath.Text;
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog save = new FolderBrowserDialog();
            save.Description = "Select a directory to export the frames to.";
            save.ShowNewFolderButton = true;
            save.ShowDialog();

            ExportData.DestinationFilePath = save.SelectedPath;
            textBoxPath.Text = ExportData.DestinationFilePath;
            if (ExportData.DestinationFilePath != null && !string.IsNullOrEmpty(ExportData.DestinationFilePath))
                buttonSave.Enabled = true;
            else
                buttonSave.Enabled = false;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            labelQuality.Text = trackBar1.Value + "";
            ExportData.Quality = trackBar1.Value;
        }

        private void helpBoxQuality_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "Sets the quality of the GIF to be produced.\nThe higher quality the image is, the longer it will take to produce and the larger the file will be.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void helpBoxTrim_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "Changes the length and where the video starts.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void helpBoxFPS_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "Sets the number of images to be displayed in one second.\n30 is the default.\n\nHaving a higher FPS will result in the file being larger.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public Conversion con
        {
            get;
            set;
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

        private void buttonSave_Click(object sender, EventArgs e)
        {
            long ts = 0;
            long tl = 0;
            try
            {
                ExportData.TrimStart = long.Parse(trimStart.Text);
                ExportData.TrimLength = long.Parse(trimLength.Text);
            }
            catch (Exception)
            {}
            try
            {
                ExportData.Width = int.Parse(textBoxCropW.Text);
                ExportData.Height = int.Parse(textBoxCropH.Text);
            }
            catch (Exception)
            {
            }
            if (checkBoxCrop.Checked && ExportData.Width <= 0 || ExportData.Height <= 0)
            {
                MessageBox.Show("The desired image must have a width and height greater than zero, and have numbers only.", "Input error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            progressBar1.Style = ProgressBarStyle.Blocks;
            using (con = Read.CreateConversion(ExportData,0))
            {
                con.SetupEncoder();
                con.ConvertAsync();
                con.ProgressChanged += con_ProgressChanged;
            }
        }

        private void UpdateProgressSafe()
        {
            this.progressBar1.Value = c_pr;
        }
        private delegate void UpdateProgressDelegate();
        public int c_pr = 0;
        void con_ProgressChanged(object sender, EventArgs e)
        {
            c_pr = (int)sender;
            try
            {
                progressBar1.Invoke(new UpdateProgressDelegate(UpdateProgressSafe));
            }
            catch (Exception)
            {
            }
        }
    }
}
