﻿using Gifbrary.Common;
using Gifbrary.Reader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace GifStudio
{
    public partial class Studio : Form
    {
        private int childFormNumber = 0;

        public Studio()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            openFileDialog.RestoreDirectory = true;
            openFileDialog.AutoUpgradeEnabled = true;
            openFileDialog.CheckFileExists = true;
            openFileDialog.Filter = "All supported media files (*.gif, *.avi, *.wmv)|*.gif;*.avi;*.wmv|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
                string file = Path.GetFileName(FileName);
                Formats f = Read.GetFormat(FileName);
                if (f == Formats.None)
                    MessageBox.Show("File " + file + " is not a valid media format supported by this program.", "Improper file selected.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (f == Formats.GIF)
                {
                    AnimatedGifChildForm gifForm = new AnimatedGifChildForm();
                    gifForm.MdiParent = this;
                    gifForm.Text = file;
                    gifForm.Show();
                    gifForm.SetGif(FileName);
                }
                else
                {
                    VideoChildForm vidForm = new VideoChildForm();
                    vidForm.MdiParent = this;
                    vidForm.Text = file;
                    vidForm.Show();
                    vidForm.SetVideo(FileName);
                }
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void toWMVToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toAnimatedGIFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = ActiveMdiChild;
            if (f != null && f is VideoChildForm)
            {
                VideoChildForm vcf = (VideoChildForm)f;
                AnimatedGifExport export = new AnimatedGifExport(vcf.FilePath,vcf.VideoControl.Player.NaturalVideoWidth,vcf.VideoControl.Player.NaturalVideoHeight);
                export.ShowDialog();
            }
        }
    }
}
