using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Gifbrary.Utilities
{
    public class VideoScanner : IDisposable
    {
        private WebBrowser _browser;
        public VideoScanner(string urltoscan)
        {
            URL = urltoscan;
            Ready = false;
            Title = "Unknown" + ((int)(new Random().NextDouble() * 10000));
            try
            {
                _browser = new WebBrowser();
            }
            catch (Exception ex)
            {
                App.HandleError(IntPtr.Zero,
                    "Internet Explorer must be installed and runnable through COM to use the Video Downloader. Sorry.", ex, 23);
            }
            _browser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(_browser_DocumentCompleted);
            _browser.Navigate(URL);
        }

        private void _browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            List<string> vids = new List<string>();

            string t = _browser.Document.Title;
            if (t != null)
            {
                string y = "";
                for (int c = 0; c < t.Length; c++)
                {
                    if (char.IsLetterOrDigit(t[c]) || char.IsWhiteSpace(t[c]))
                        y += t[c];
                }
                if (!string.IsNullOrEmpty(y))
                    Title = y;
            }

            HtmlElementCollection collection = _browser.Document.GetElementsByTagName("object");
            for (int c = 0; c < collection.Count; c++)
            {
                HtmlElement el = collection[c];
                
            }

            collection = _browser.Document.GetElementsByTagName("video");
            for (int c = 0; c < collection.Count; c++)
            {
                HtmlElement el = collection[c];

            }
            Ready = true;
        }

        public string Title
        {
            get;
            set;
        }

        public bool Ready
        {
            get;
            set;
        }

        public string URL
        {
            get;
            set;
        }

        public string VideoURL
        {
            get;
            set;
        }
        
        public void Dispose()
        {
            if (_browser != null)
            {
                _browser.Dispose();
            }
        }
    }
}
