using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace Gifbrary.Utilities
{
    public class VideoDownloader
    {
        public event EventHandler ProgressChanged;
        public event EventHandler DownloadComplete;
        public VideoDownloader(string url, string title)
        {
            URL = url;
        }

        public string Title
        {
            get;
            set;
        }

        private string AppTemp
        {
            get;
            set;
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

        public void Download()
        {
            WebClient clientStreamDownloadInstance = new WebClient();
            clientStreamDownloadInstance.DownloadFileAsync(new Uri(URL), 
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
