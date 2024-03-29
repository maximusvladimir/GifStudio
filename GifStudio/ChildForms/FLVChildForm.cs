﻿using System;
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
using Gifbrary.Common;

namespace GifStudio.ChildForms
{
    public partial class FLVChildForm : Form
    {
        private VideoDownloader _downloader;
        public FLVChildForm()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            if (App.HistoryReady)
            {
                boxURL.AutoCompleteSource = AutoCompleteSource.CustomSource;
                foreach (string str in App.HistoryUrls)
                {
                    boxURL.AutoCompleteCustomSource.Add(str);
                }
            }
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

        VideoScanner scanner;

        private void button3_Click(object sender, EventArgs e)
        {
            firstRun = true;
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
            {
                App.HandleHelp(this.Handle, global::GifStudio.Properties.Resources.STR_EXP_FLV_DWL_ALERT_INVALIDURL,
                    null, global::GifStudio.Properties.Resources.STR_EXP_FLV_DWL_ALERT_INVALIDURL_TOPIC);
                return;
            }

            string nu = null;
            string title = null;
            string ext = null;
            if (!_url.EndsWith(".mp4") && !_url.EndsWith(".wmv") && !_url.EndsWith(".flv") &&
                !_url.EndsWith(".avi"))
            {
               // try
              //  {
                    scanner = new VideoScanner(_url);
              // }
                //catch (Exception ex)
                //{
                //    if (ex.Message.IndexOf("The remote name could not be resolved") > -1)
                //    {
                //        App.HandleError(IntPtr.Zero, "Unable to contact server. Your internet connection may be down.", ex, 18);
                //        return;
                 //   }
                //    else
                //        throw;
                //}
                if (scanner.NoVideo)
                {
                    App.HandleHelp(Handle, global::GifStudio.Properties.Resources.STR_EXP_FLV_DWL_ALERT_NOVIDEO,
                        global::GifStudio.Properties.Resources.STR_EXP_FLV_DWL_ALERT_NOVIDEO_DETAILS,
                        global::GifStudio.Properties.Resources.STR_EXP_FLV_DWL_ALERT_NOVIDEO_TOPIC);
                    return;
                }
                if (quality != null && quality.Length > 0 && comboBox1.SelectedIndex < quality.Length)
                {
                    nu = quality[comboBox1.SelectedIndex].DownloadUrl;
                    string y = quality[comboBox1.SelectedIndex].Extention;
                    y = y.ToLower();
                    if (y.IndexOf("3d") > -1)
                        y = y.Replace("3d", "");
                    if (y.IndexOf(" ") > -1)
                        y = y.Replace(" ", "");
                    ext = y;
                }
                else
                    nu = scanner.VideoURL;
                title = scanner.Title;
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

            progressBar1.Style = ProgressBarStyle.Blocks;
            button3.Enabled = false;

            _downloader = new VideoDownloader(nu, title, ext);
            _downloader.Scanner = scanner;
            _downloader.DownloadComplete += new EventHandler(_downloader_DownloadComplete);
            _downloader.ProgressChanged += new EventHandler(_downloader_ProgressChanged);
            try
            {
                _downloader.Download();
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("The remote name could not be resolved") > -1)
                {
                    App.HandleError(IntPtr.Zero, "Unable to contact server. Your internet connection may be down.", ex, 18);
                    progressBar1.Style = ProgressBarStyle.Continuous;
                    button3.Enabled = true;
                    return;
                }
                else if (ex.Message.IndexOf("404") > -1)
                {
                    App.HandleError(IntPtr.Zero, "Unknown address. Check your spelling and try again.", ex, 20);
                    progressBar1.Style = ProgressBarStyle.Continuous;
                    button3.Enabled = true;
                    return;
                }
            }
        }

        private void _downloader_ProgressChanged(object sender, EventArgs e)
        {
            progressBar1.Value = (int)((progressBar1.Maximum/2) * _downloader.Progress);
            try
            {
                Studio.SetStatus(this,"Downloading video " + (_downloader.Progress * 50) + " %");
                Studio.SetProgress(this, (int)((progressBar1.Maximum/2) * _downloader.Progress));
            }
            catch (Exception)
            {
            }
        }

        string tempVidPath = "";
        private void _downloader_DownloadComplete(object sender, EventArgs e)
        {
            tempVidPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), System.IO.Path.GetFileNameWithoutExtension(_downloader.VideoPath) + ".mpg");
            try
            {
                if (System.IO.File.Exists(tempVidPath))
                    System.IO.File.Delete(tempVidPath);
            }
            catch (Exception)
            { }
            App.CleanupQueue.Add(tempVidPath);
            App.CleanupQueue.Add(_downloader.VideoPath);
            if (System.IO.Path.GetExtension(_downloader.VideoPath).ToLower() == ".wmv")
            {
                try
                {
                    System.IO.File.Copy(_downloader.VideoPath, tempVidPath, true);
                }
                catch (Exception)
                {
                }
                VideoChildForm vidForm = new VideoChildForm();
                vidForm.MdiParent = MdiParent;
                vidForm.Text = System.IO.Path.GetFileName(tempVidPath);
                vidForm.Show();
                vidForm.SetVideo(tempVidPath);
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
            else
            {
                FFmpeg mpeg = new FFmpeg(_downloader.VideoPath, tempVidPath);
                mpeg.ProgressChanged += mpeg_ProgressChanged;
                mpeg.Completed += mpeg_Completed;
                mpeg.Parameters = "-vcodec mpeg2video -pix_fmt yuv420p -me_method epzs -r 29.97 -g 15 -b 2500k -bt 300k -threads 0";//-preset medium -vcodec libx264 -vcodec msmpeg4v3
                mpeg.ConvertAsync();
            }
            /*VideoChildForm vidForm = new VideoChildForm();
            vidForm.MdiParent = MdiParent;
            vidForm.Text = System.IO.Path.GetFileName(temp);
            vidForm.Show();
            vidForm.SetVideo(_downloader.VideoPath);*/
        }
        bool firstRun = true;
        private void mpeg_Completed(object sender, EventArgs e)
        {
            /*if (firstRun)
            {
                FFmpeg mpeg = new FFmpeg(_downloader.VideoPath, tempVidPath.Replace(".mpg",".wmv"));
                mpeg.ProgressChanged += mpeg_ProgressChanged;
                mpeg.Completed += mpeg_Completed;
                mpeg.Parameters = "-threads 0";//-preset medium -vcodec libx264 -vcodec msmpeg4v3
                mpeg.ConvertAsync();
                firstRun = false;
                return;
            }*/
            string swap = ((FFmpeg)sender).Output;
            Invoke((Action)delegate()
            {
                VideoChildForm vidForm = new VideoChildForm();
                try
                {
                    System.IO.File.Delete(((FFmpeg)sender).Input);
                }
                catch (Exception)
                {
                }
                vidForm.MdiParent = MdiParent;
                vidForm.Text = System.IO.Path.GetFileName(swap);
                vidForm.Show();
                vidForm.SetVideo(swap);
            });

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

        private void mpeg_ProgressChanged(object sender, EventArgs e)
        {
            FFmpeg send = (FFmpeg)sender;
            try
            {
                if (firstRun)
                {
                    Invoke((Action)delegate()
                    {
                        float vf = (((send.Progress /** 0.5f*/) * (progressBar1.Maximum / 2.0f)) + (progressBar1.Maximum / 2.0f));
                        progressBar1.Value = (int)vf;
                        Studio.SetStatus(this, "Processing video " + vf + " %");
                        Studio.SetProgress(this, (int)vf);
                    });
                }
               /* else
                {
                    Invoke((Action)delegate()
                    {
                        float vf = ((((send.Progress * 0.5f)+0.5f) * (progressBar1.Maximum / 2.0f)) + (progressBar1.Maximum / 2.0f));
                        progressBar1.Value = (int)vf;
                        Studio.SetStatus(this, "Processing video " + vf + " %");
                        Studio.SetProgress(this, (int)vf);
                    });
                }*/
            }
            catch (Exception)
            {
            }
        }

        private void checkBoxUseProxy_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxUseProxy.Checked)
            {
                prxyLabelAddress.Enabled = true;
                prxyTextBoxAddress.Enabled = true;
                prxyNumericPort.Enabled = true;
                prxyLabelPort.Enabled = true;
            }
            else
            {
                prxyLabelAddress.Enabled = false;
                prxyTextBoxAddress.Enabled = false;
                prxyNumericPort.Enabled = false;
                prxyLabelPort.Enabled = false;
            }
        }
        private YouTubeVideoQuality[] quality;
        private bool killQualityScan = false;
        private void boxURL_TextChanged(object sender, EventArgs e)
        {
            killQualityScan = true;
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
                return;
            }

            if (_url.StartsWith("ftp:") || _url.StartsWith("udp:") || createFail || _url.StartsWith("file:"))
                return;

            if (!_url.EndsWith(".mp4") && !_url.EndsWith(".wmv") && !_url.EndsWith(".flv") &&
                !_url.EndsWith(".avi") && (_url.IndexOf("youtube.com/wat") > -1 || _url.IndexOf("youtu.be/wat") > -1))
            {
                button3.Enabled = false;
                System.Threading.Thread worker = new System.Threading.Thread(
                    new System.Threading.ThreadStart(delegate()
                        {
                            bool found = false;
                            killQualityScan = false;
                            while (!found)
                            {
                                if (killQualityScan)
                                    found = true;
                                else
                                {
                                    string[] st = null;
                                    try
                                    {
                                        Studio.SetStatus(this, "Detecting quality settings. Please wait a second.");
                                        st = VideoScanner.GetQualityStrings(_url, ref quality);
                                    }
                                    catch (Exception ex)
                                    {
                                        if (ex.Message.IndexOf("The remote name could not be resolved") > -1)
                                        {
                                            App.HandleError(IntPtr.Zero, "Unable to contact server. Your internet connection may be down.", ex, 18);
                                            Invoke((Action)delegate()
                                            {
                                                progressBar1.Style = ProgressBarStyle.Continuous;
                                                button3.Enabled = true;
                                            });
                                            return;
                                        }
                                        else if (ex.Message.IndexOf("404") > -1)
                                            return;
                                        else
                                            throw;
                                    }
                                    try
                                    {
                                        bool giveBreak = false;
                                        Invoke((Action)delegate()
                                        {
                                            if (st != null && st.Length > 0)
                                            {
                                                comboBox1.Items.Clear();
                                                comboBox1.Items.AddRange(st);
                                                comboBox1.SelectedIndex = 0;
                                                comboBox1.Enabled = true;
                                                Studio.SetStatus(this, "Ready.");
                                                found = true;
                                                giveBreak = true;
                                            }
                                        });
                                        if (giveBreak)
                                            break;
                                        if (!killQualityScan && !found)
                                            System.Threading.Thread.Sleep(1500);
                                    }
                                    catch (Exception) { }
                                }
                            }
                            System.Threading.Thread.Sleep(300);
                            worker = null;
                            Invoke((Action)delegate()
                            {
                                button3.Enabled = true;
                            });
                        }));
                worker.Priority = System.Threading.ThreadPriority.Highest;
                worker.Start();
                worker.Priority = System.Threading.ThreadPriority.Highest;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
            try
            {
                Studio.SetStatus(this,"Ready.");
            }
            catch (Exception)
            {
            }
        }
    }
}
