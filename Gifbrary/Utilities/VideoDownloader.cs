﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace Gifbrary.Utilities
{
    public class VideoDownloader
    {
        public event EventHandler ProgressChanged;
        public event EventHandler DownloadComplete;
        public VideoDownloader(string url, string title)
        {
            URL = url;
            Progress = 0.0f;
            Title = title;
            Extension = ".wmv";
            try
            {
                Uri yuri = new Uri(URL);
                Extension = Path.GetExtension(yuri.LocalPath);
            }
            catch (Exception)
            {
            }

            if (AppTemp == null)
            {
                AppTemp = Path.Combine(Path.GetTempPath(), "\\GifStudio\\Downloads\\");
                if (!Directory.Exists(AppTemp))
                {
                    try
                    {
                        Directory.CreateDirectory(AppTemp);
                    }
                    catch (Exception)
                    { }
                }
            }
        }

        public string Title
        {
            get;
            set;
        }

        public static string AppTemp
        {
            get;
            private set;
        }

        public string URL
        {
            get;
            set;
        }

        public float Progress
        {
            get;
            private set;
        }

        public string Extension
        {
            get;
            set;
        }

        public void Download()
        {
            VideoPath = Path.Combine(AppTemp, Title + Extension);
            WebClient clientStreamDownloadInstance = new WebClient();
            clientStreamDownloadInstance.DownloadProgressChanged += new DownloadProgressChangedEventHandler(clientStreamDownloadInstance_DownloadProgressChanged);
            clientStreamDownloadInstance.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(clientStreamDownloadInstance_DownloadFileCompleted);
            clientStreamDownloadInstance.DownloadFileAsync(new Uri(URL), VideoPath);
        }

        private void clientStreamDownloadInstance_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            OnDownloadComplete();
        }

        private void clientStreamDownloadInstance_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Progress = ((float)(e.BytesReceived)) / ((float)(e.TotalBytesToReceive));
            if (ProgressChanged != null)
                ProgressChanged(this, EventArgs.Empty);
        }

        public void OnDownloadComplete()
        {
            if (DownloadComplete != null)
                DownloadComplete(this, EventArgs.Empty);
        }

        public string VideoPath
        {
            get;
            set;
        }
    }
}