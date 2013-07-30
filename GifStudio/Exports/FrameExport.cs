using Gifbrary.Common;
using Gifbrary.Converter;
using Gifbrary.Reader;
using GifStudio.Exports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GifStudio
{
    public partial class FrameExport : ExportWindow
    {
        public FrameExport(string file, int w, int h)
        {
            ExportData = new Exportable();
            ExportData.SourceFilePath = file;
            InitializeComponent();
            textBoxPath.TextChanged += textBoxPath_TextChanged;
            textBoxCropH.Text = h + "";
            textBoxCropW.Text = w + "";

            ExportData.Quality = 50;
            ExportData.FPS = 30;
            comboBox1.SelectedIndex = 0;
            ExportData.NamingConventionPrefix = true;
            ExportData.NamingConventionZeros = 3;
            ExportData.NamingConvetion = "img";
            textBoxNameConvention.Text = "img";

            Format = ImageFormat.Png;
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
            MessageBox.Show(this, "Sets the quality of the images to be produced.\nThe higher quality the image is, the longer it will take to produce and the larger the file will be.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            UpdateConventions();
            if (!isAlphaNumeric(ExportData.NamingConvetion))
            {
                MessageBox.Show("The naming convention MUST only use characters A-Z, a-z, or 0-9.", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (Directory.Exists(ExportData.DestinationFilePath) && Directory.GetFiles(ExportData.DestinationFilePath).Length > 0)
                {
                    DialogResult res = MessageBox.Show("Notice: There are already some files in the folder " +
                        ExportData.DestinationFilePath + ". You are most likely about to put a whole lot of files in that folder. Continue?", "Warning",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    if (res == System.Windows.Forms.DialogResult.Cancel)
                        return;
                }
            }
            catch (Exception)
            {
            }
            progressBar1.Style = ProgressBarStyle.Blocks;
            buttonSave.Text = "Exporting";
            buttonSave.Enabled = false;
            using (Converter = Read.CreateConversion(ExportData,Format))
            {
                Converter.SetupEncoder();
                Converter.ConvertAsync();
                Converter.ProgressChanged += con_ProgressChanged;
                Converter.ConversionFinished += new EventHandler(Converter_ConversionFinished);
            }
        }

        private void Converter_ConversionFinished(object sender, EventArgs e)
        {
            Studio.SetStatus(this,"Sucessfully finished exporting frames to " + ExportData.DestinationFilePath + ".");
            try
            {
                Invoke((Action)delegate()
                {
                    Close();
                });
            }
            catch (Exception)
            { }
        }

        public static Boolean isAlphaNumeric(string strToCheck)
        {
            Regex rg = new Regex(@"^[a-zA-Z0-9\s]*$");
            return rg.IsMatch(strToCheck);
        }
        private void UpdateProgressSafe()
        {
            this.progressBar1.Value = (int)(CountProgress * progressBar1.Maximum);
        }
        private delegate void UpdateProgressDelegate();
        void con_ProgressChanged(object sender, EventArgs e)
        {
            CountProgress = (float)sender;
            try
            {
                progressBar1.Invoke(new UpdateProgressDelegate(UpdateProgressSafe));
            }
            catch (Exception)
            {
            }
            try
            {
                FileInfo inf = new FileInfo(ExportData.DestinationFilePath);
                inf.Refresh();
                long s = (long)(inf.Length * CountProgress);
                Studio.SetStatus(this,(100 * CountProgress) +
                    "% complete. Estimated final file size: " + (s / 1024 / 1024.0f) + " MB.");
            }
            catch (Exception)
            {
            }
        }

        private void textBoxNameConvention_TextChanged(object sender, EventArgs e)
        {
            UpdateConventions();
        }

        public ImageFormat Format
        {
            get;
            set;
        }

        private void UpdateConventions()
        {
            var fc = new ImageFormatConverter();
            var strf = fc.ConvertToString(Format).ToLower();
            ExportData.NamingConvetion = textBoxNameConvention.Text;
            ExportData.NamingConventionPrefix = radioButton1.Checked;
            ExportData.NamingConventionZeros = (int)numericUpDown1.Value;
            if (ExportData.NamingConventionZeros != 0)
            {
                if (!radioButton1.Checked)
                    label6.Text = "Example: " + 1.ToString("D" + ExportData.NamingConventionZeros) + ExportData.NamingConvetion + "." + strf;
                else
                    label6.Text = "Example: " + ExportData.NamingConvetion + 1.ToString("D" + ExportData.NamingConventionZeros) + "." + strf;
            }
            else
            {
                if (!radioButton1.Checked)
                    label6.Text = "Example: " + 1 + ExportData.NamingConvetion + "." + strf;
                else
                    label6.Text = "Example: " + ExportData.NamingConvetion + 1 + "." + strf;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
                Format = ImageFormat.Png;
            else if (comboBox1.SelectedIndex == 1)
                Format = ImageFormat.Jpeg;
            else if (comboBox1.SelectedIndex == 2)
                Format = ImageFormat.Bmp;
            else if (comboBox1.SelectedIndex == 3)
                Format = ImageFormat.Tiff;
            else if (comboBox1.SelectedIndex == 4)
                Format = ImageFormat.Wmf;
            else if (comboBox1.SelectedIndex == 5)
                Format = ImageFormat.Exif;
            else if (comboBox1.SelectedIndex == 6)
                Format = ImageFormat.Gif;
            else
                Format = ImageFormat.Png;
            UpdateConventions();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            UpdateConventions();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            UpdateConventions();
        }

        private void helpBoxFileType_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this,"The file type is the type of image that you wish to save. Different image formats have different weaknesses and advantages."+
             "\nFor example, the BMP format is known for being consuming significant amounts of space, with little color loss. The GIF format is know "+
             "for the little space it uses, but the fact that it only supports 256 colors.\n\nIf you don't know which you should pick, it is recommended"+
             " to pick the PNG format.", "Help", MessageBoxButtons.OK,
            MessageBoxIcon.Information);
        }

        private void helpBoxExample_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this,"When you export an image sequence you have the option here to select how you wish the files to be named.\nIt is "+
                "recommended that you use several leading digits, and a file name.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
