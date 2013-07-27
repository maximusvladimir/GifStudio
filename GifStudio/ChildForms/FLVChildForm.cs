using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Gifbrary.Utilities;
using Gifbrary;

namespace GifStudio.ChildForms
{
    public partial class FLVChildForm : Form
    {
        private VideoDownloader _downloader;
        public FLVChildForm()
        {
            InitializeComponent();
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.google.ru");
        }

        private void buttonPaste_Click(object sender, EventArgs e)
        {
            string nativeString = "";
            try
            {
                nativeString = Clipboard.GetText(TextDataFormat.Text);
            }
            catch (Exception)
            {
                try
                {
                    nativeString = Clipboard.GetText(TextDataFormat.Text);
                }
                catch (Exception)
                {
                    System.Threading.Thread.Sleep(250);
                    try
                    {
                        nativeString = Clipboard.GetText(TextDataFormat.Text);
                    }
                    catch (Exception)
                    {
                        System.Threading.Thread.Sleep(750);
                        try
                        {
                            nativeString = Clipboard.GetText(TextDataFormat.Text);
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
            }
            if (!string.IsNullOrEmpty(nativeString))
                boxURL.Text = nativeString;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string _url = boxURL.Text;
            if (string.IsNullOrEmpty(_url))
                return;

            bool createFail = false;

            try
            {
                Uri ur = new Uri(_url);
            }
            catch (Exception)
            {
                createFail = true;
            }

            if (_url.StartsWith("ftp:") || _url.StartsWith("udp:") || createFail || _url.StartsWith("file:"))
                App.HandleHelp(this.Handle, global::GifStudio.Properties.Resources.STR_EXP_FLV_DWL_ALERT_INVALIDURL,
                    null, global::GifStudio.Properties.Resources.STR_EXP_FLV_DWL_ALERT_INVALIDURL_TOPIC);

            string nu = null;
            string title = null;
            if (!_url.EndsWith(".mp4") && !_url.EndsWith(".wmv") && !_url.EndsWith(".flv") &&
                !_url.EndsWith(".avi"))
            {
                using (VideoScanner scanner = new VideoScanner(_url))
                {
                    while (!scanner.Ready)
                    { }
                    nu = scanner.VideoURL;
                    title = scanner.Title;
                }
            }
            else
            {
                nu = string.Copy(_url);
                try
                {
                    Uri u = new Uri(_url);
                    if (u.IsFile)
                        title = System.IO.Path.GetFileName(u.LocalPath);
                }
                catch (Exception)
                {
                }
            }
            _url = null;

            _downloader = new VideoDownloader(nu, title);
            _downloader.DownloadComplete += new EventHandler(_downloader_DownloadComplete);
            _downloader.ProgressChanged += new EventHandler(_downloader_ProgressChanged);
            _downloader.Download();
        }

        private void _downloader_ProgressChanged(object sender, EventArgs e)
        {
            progressBar1.Value = (int)(progressBar1.Maximum * _downloader.Progress);
        }

        private void _downloader_DownloadComplete(object sender, EventArgs e)
        {
            VideoChildForm vidForm = new VideoChildForm();
            vidForm.MdiParent = MdiParent;
            vidForm.Text = System.IO.Path.GetFileName(_downloader.VideoPath);
            vidForm.Show();
            vidForm.SetVideo(_downloader.VideoPath);
        }
    }
}
