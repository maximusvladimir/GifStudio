using Gifbrary.Common;
using Gifbrary.Converter;
using Gifbrary.Reader;
using GifStudio.Exports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Gifbrary;

namespace GifStudio
{
    public partial class AnimatedGifExport : ExportWindow
    {
        long maxspan = 0;
        public AnimatedGifExport(string file, int w, int h)
        {
            ExportData = new Exportable();
            ExportData.SourceFilePath = file;
            InitializeComponent();
            textBoxPath.TextChanged += textBoxPath_TextChanged;
            textBoxCropH.Text = h + "";
            textBoxCropW.Text = w + "";

            ChromaKey = Color.Fuchsia;
            ExportData.Quality = 0.5f;
            ExportData.FPS = 30;
            maxspan = new TimeSpan(FFmpeg.GetVideoDuration(file)).Ticks;
            trimLength.Text = new TimeSpan(maxspan).ToString();
            trimLength.TextChanged += trimLength_TextChanged;
        }

        void trimLength_TextChanged(object sender, EventArgs e)
        {
            try
            {
                long t = TimeSpan.Parse(trimLength.Text).Ticks;
                if (t > maxspan)
                    App.HandleError(Handle, "Trim length must be less than the video length.", null, 26);
            }
            catch (Exception)
            {
            }
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

            try
            {
                if (File.Exists(save.FileName))
                {
                    File.Delete(save.FileName);
                }
            }
            catch (Exception)
            { }

            ExportData.DestinationFilePath = save.FileName;
            textBoxPath.Text = ExportData.DestinationFilePath;
            if (ExportData.DestinationFilePath != null && !string.IsNullOrEmpty(ExportData.DestinationFilePath))
                buttonSave.Enabled = true;
            else
                buttonSave.Enabled = false;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            labelQuality.Text = trackBar1.Value + "";
            ExportData.Quality = ((float)trackBar1.Value)/((float)trackBar1.Maximum);
        }

        private void helpBoxQuality_Click(object sender, EventArgs e)
        {
            App.HandleHelp(this.Handle, global::GifStudio.Properties.Resources.STR_EXP_ANI_GIF_HELP_QUALITY,
            global::GifStudio.Properties.Resources.STR_EXP_ANI_GIF_HELP_QUALITY_DETAILS,
            global::GifStudio.Properties.Resources.STR_EXP_ANI_GIF_HELP_QUALITY_TOPIC);
            //MessageBox.Show(this, "Sets the quality of the GIF to be produced.\nThe higher quality the image is, the longer it will take to produce and the larger the file will be.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void helpBoxTrim_Click(object sender, EventArgs e)
        {
            App.HandleHelp(this.Handle, global::GifStudio.Properties.Resources.STR_EXP_ANI_GIF_HELP_TRIM,
            global::GifStudio.Properties.Resources.STR_EXP_ANI_GIF_HELP_TRIM_DETAILS,
            global::GifStudio.Properties.Resources.STR_EXP_ANI_GIF_HELP_TRIM_TOPIC);
            //MessageBox.Show(this, "Changes the length and where the video starts.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void helpBoxFPS_Click(object sender, EventArgs e)
        {
            App.HandleHelp(this.Handle, global::GifStudio.Properties.Resources.STR_EXP_ANI_GIF_HELP_FPS,
            global::GifStudio.Properties.Resources.STR_EXP_ANI_GIF_HELP_FPS_DETAILS,
            global::GifStudio.Properties.Resources.STR_EXP_ANI_GIF_HELP_FPS_TOPIC);
            //MessageBox.Show(this, "Sets the number of images to be displayed in one second.\n30 is the default.\n\nHaving a higher FPS will result in the file being larger.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            ExportData.FPS = tfps;
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
            App.HandleHelp(this.Handle, global::GifStudio.Properties.Resources.STR_EXP_ANI_GIF_HELP_RESIZE,
            global::GifStudio.Properties.Resources.STR_EXP_ANI_GIF_HELP_RESIZE_DETAILS,
            global::GifStudio.Properties.Resources.STR_EXP_ANI_GIF_HELP_RESIZE_TOPIC);
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
            if (checkBoxTrim.Checked)
            {
                TimeSpan ts = TimeSpan.Parse(trimStart.Text);
                TimeSpan tl = TimeSpan.Parse(trimLength.Text);
                TimeSpan nl = ts + tl;
                string coref = tl.ToString();
                System.Diagnostics.Debug.WriteLine(coref);
                ExportData.TrimStart = ts.ToString();
                ExportData.TrimLength = coref;
                //ExportData.TrimStart = trimStart.Text;
                //ExportData.TrimLength = trimLength.Text;
            }
            //System.Diagnostics.Debug.WriteLine(ExportData.TrimLength);
            int l = 0;
            if (!checkBoxLoop.Checked)
                l = 1;
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
                return;
            }
            if (!App.IsValidPath(ExportData.DestinationFilePath))
            {
                App.HandleHelp(Handle, global::GifStudio.Properties.Resources.STR_EXP_ERROR_BAD_PATH,
                    global::GifStudio.Properties.Resources.STR_EXP_ERROR_BAD_PATH_DETAILS,
                    global::GifStudio.Properties.Resources.STR_EXP_ERROR_BAD_PATH_TOPIC);
                return;
            }
            progressBar1.Style = ProgressBarStyle.Blocks;
            buttonSave.Text = "Exporting";
            buttonSave.Enabled = false;
            if (checkBoxTransparency.Checked)
                ExportData.ChromaKey = ChromaKey;
            else
                ExportData.ChromaKey = null;
            using (Converter = Read.CreateConversion(ExportData,l))
            {
                Converter.SetupEncoder();
                Converter.ConvertAsync();
                Converter.ProgressChanged += con_ProgressChanged;
                Converter.ConversionFinished += new EventHandler(Converter_ConversionFinished);
            }
        }

        void Converter_ConversionFinished(object sender, EventArgs e)
        {
            Studio.SetStatus(this,
                "Finished converting " + Path.GetFileName(ExportData.SourceFilePath) + ".");
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
            Studio.SetStatus(this,(100 * CountProgress) + "% complete.");
            Studio.SetProgress(this, (int)(100 * CountProgress));
        }

        private void checkBoxTransparency_CheckedChanged(object sender, EventArgs e)
        {
            buttonColorPicker.Enabled = checkBoxTransparency.Checked;
        }

        public Color ChromaKey
        {
            get;
            set;
        }

        private void buttonColorPicker_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.AllowFullOpen = true;
            cd.AnyColor = true;
            cd.Color = buttonColorPicker.BackColor;
            cd.FullOpen = true;
            cd.ShowDialog();

            if (cd.Color != null)
                buttonColorPicker.BackColor = cd.Color;

            ChromaKey = buttonColorPicker.BackColor;
        }
    }
}
