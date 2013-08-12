using Gifbrary;
using Gifbrary.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GifStudio.ChildForms
{
    public partial class GifCompressor : Form
    {
        ColorTableReplacer worker;
        public GifCompressor()
        {
            InitializeComponent();
        }

        private void buttonBrowseInput_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.AutoUpgradeEnabled = true;
            ofd.CheckFileExists = true;
            ofd.Filter = "Animated GIF file (*.gif)|*.gif";
            ofd.RestoreDirectory = true;
            ofd.SupportMultiDottedExtensions = true;
            ofd.Title = "Open the animated gif to compress";
            ofd.ShowDialog();

            textBoxInput.Text = ofd.FileName;
        }

        private void buttonBrowseOutput_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.AutoUpgradeEnabled = true;
            sfd.AddExtension = false;
            sfd.Filter = "Animated GIF file (*.gif)|*.gif";
            sfd.RestoreDirectory = true;
            sfd.SupportMultiDottedExtensions = true;
            sfd.Title = "Save the new animated gif";
            sfd.ShowDialog();

            textBoxOutput.Text = sfd.FileName;
        }

        private void buttonCompress_Click(object sender, EventArgs e)
        {
            /*if (!App.IsValidPath(textBoxInput.Text) || !App.IsValidPath(textBoxOutput.Text))
            {
                App.HandleHelp(Handle, global::GifStudio.Properties.Resources.STR_EXP_ERROR_BAD_PATH,
                    global::GifStudio.Properties.Resources.STR_EXP_ERROR_BAD_PATH_DETAILS,
                    global::GifStudio.Properties.Resources.STR_EXP_ERROR_BAD_PATH_TOPIC);
                return;
            }*/
            worker = new ColorTableReplacer(textBoxInput.Text, textBoxOutput.Text);
            worker.QualityColors = (uint)decimal.ToInt32(numericColors.Value);
            progressBar1.Style = ProgressBarStyle.Blocks;
            buttonCompress.Enabled = false;
            if (checkBoxGrayscale.Checked)
                worker.Grayscale = true;
            worker.ProgressChanged += worker_ProgressChanged;
            worker.Finished += worker_Finished;
            worker.StartAsync();
        }

        private void worker_Finished(object sender, EventArgs e)
        {
            Invoke((Action)delegate()
            {
                try
                {
                    int inbytes = File.ReadAllBytes(textBoxInput.Text).Length;
                    int outbytes = File.ReadAllBytes(textBoxOutput.Text).Length;
                    Studio.SetProgress(this, 100);
                    Studio.SetStatus(this, "Compression completed successfully. File reduced by " + ((inbytes - outbytes) / 1024) + " kb.");
                }
                catch (Exception)
                { }
                Close();
            });
        }

        private void worker_ProgressChanged(object sender, EventArgs e)
        {
            Invoke((Action)delegate()
            {
                progressBar1.Value = (int)(worker.Progress * progressBar1.Maximum);
                Studio.SetProgress(this, (int)(worker.Progress * 100));
                Studio.SetStatus(this, "Compressing GIF with " + worker.QualityColors + " colors. " + (worker.Progress * 100) + " % complete.");
            });
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Invoke((Action)delegate()
            {
                Studio.SetProgress(this, (int)(worker.Progress * 100));
                if (worker != null)
                {
                    worker.Kill();
                    buttonCompress.Enabled = true;
                    progressBar1.Style = ProgressBarStyle.Continuous;
                }
                else
                    Close();
            });
        }
    }
}
