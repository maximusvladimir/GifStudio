using Gifbrary.Common;
using Gifbrary.Reader;
using GifStudio.Exports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using GifStudio.ChildForms;

namespace GifStudio
{
    public partial class Studio : Form
    {

        public static void SetStatus(Form self, string status)
        {
            try
            {
                if (self.MdiParent != null)
                    ((Studio)self.MdiParent).StatusText = status;
                else if (self.Parent != null)
                    ((Studio)self.Parent).StatusText = status;
            }
            catch (Exception)
            {
            }
        }

        public static void SetProgress(Form self, int val)
        {
            try
            {
                if (self.MdiParent != null)
                    ((Studio)self.MdiParent).ProgressTool = val;
                else if (self.Parent != null)
                    ((Studio)self.Parent).ProgressTool = val;
                else
                    Gifbrary.App.SetProgress(val);
            }
            catch (Exception)
            {
            }
        }

        private ExportWindow export;
        public Studio()
        {
            InitializeComponent();
            //Gifbrary.App.HandleError(this.Handle, "Studio test crash #1", new Exception(), 4);
            //Gifbrary.App.HandleError(this.Handle, "Studio test crash #2", new Exception(), 5);

            StatusText = null;
            FormClosed += new FormClosedEventHandler(Studio_FormClosed);
        }

        public int ProgressTool
        {
            set
            {
                Action act = (Action)delegate()
                {
                    Gifbrary.App.SetProgress(value);
                };
                if (InvokeRequired)
                    Invoke(act);
                else
                    act.Invoke();
            }
        }

        void Studio_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.Shutdown();
        }

        /*private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }*/

        private delegate void StatusLabelInvoke(string status);
        private string _statustext = "";
        public string StatusText
        {
            get
            {
                return _statustext;
            }
            set
            {
                _statustext = value;
                if (string.IsNullOrEmpty(_statustext))
                    _statustext = "Ready.";
                if (InvokeRequired)
                {
                    Invoke((Action)delegate()
                    {
                        Status.Text = _statustext;
                    });
                }
                else
                {
                    Status.Text = _statustext;
                }
            }
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            openFileDialog.RestoreDirectory = true;
            openFileDialog.AutoUpgradeEnabled = true;
            openFileDialog.CheckFileExists = true;
            openFileDialog.Filter = "All supported media files (*.gif, *.mpg, *.wmv)|*.gif;*.mpg;*.wmv|All Files (*.*)|*.*";
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
                using (VideoChildForm vcf = (VideoChildForm)f)
                {
                    export = new AnimatedGifExport(vcf.FilePath, vcf.VideoControl.Player.NaturalVideoWidth, vcf.VideoControl.Player.NaturalVideoHeight);
                    export.ShowDialog(this);
                }
            }
        }

        public ToolStripLabel Status
        {
            get
            {
                return toolStripStatusLabel;
            }
        }

        private void dumpFramesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = ActiveMdiChild;
            if (f != null && f is VideoChildForm)
            {
                using (VideoChildForm vcf = (VideoChildForm)f)
                {
                    export = new FrameExport(vcf.FilePath, vcf.VideoControl.Player.NaturalVideoWidth, vcf.VideoControl.Player.NaturalVideoHeight);
                    export.ShowDialog(this);
                }
            }
        }

        private void toAnimatedPNGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void flashVideoDownloaderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FLVChildForm vidForm = new FLVChildForm();
            vidForm.MdiParent = this;
            vidForm.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (About about = new About())
            {
                about.ShowDialog(this);
            }
        }

        private void screenRecorderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ScreenRecorderChildForm srcf = new ScreenRecorderChildForm())
            {
                srcf.ShowDialog(this);
            }
        }

        private void gifCompressorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GifCompressor compressor = new GifCompressor();
            compressor.ShowDialog(this);
        }
    }
}
