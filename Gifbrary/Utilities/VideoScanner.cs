using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Gifbrary.Utilities
{
    /// <summary>
    /// Contains information about the video url extension and dimension
    /// </summary>
    public class YouTubeVideoQuality
    {
        /// <summary>
        /// Gets or Sets the file name
        /// </summary>
        public string VideoTitle { get; set; }
        /// <summary>
        /// Gets or Sets the file extention
        /// </summary>
        public string Extention { get; set; }
        /// <summary>
        /// Gets or Sets the file url
        /// </summary>
        public string DownloadUrl { get; set; }
        /// <summary>
        /// Gets or Sets the youtube video url
        /// </summary>
        public string VideoUrl { get; set; }
        /// <summary>
        /// Gets or Sets the youtube video size
        /// </summary>
        public long VideoSize { get; set; }
        /// <summary>
        /// Gets or Sets the youtube video dimension
        /// </summary>
        public Size Dimension { get; set; }
        /// <summary>
        /// Gets the youtube video length
        /// </summary>
        public long Length { get; set; }
        public override string ToString()
        {
            return Extention + " File " + Dimension.Width + "x" + Dimension.Height;
        }

        public int TagQuality
        {
            get;
            set;
        }

        public void ProcessQuality()
        {
            bool _Wide = true;
            switch (TagQuality)
            {
                case 5: SetQuality("flv", new Size(320, (_Wide ? 180 : 240))); break;
                case 6: SetQuality("flv", new Size(480, (_Wide ? 270 : 360))); break;
                case 17: SetQuality("3gp", new Size(176, (_Wide ? 99 : 144))); break;
                case 18: SetQuality("mp4", new Size(640, (_Wide ? 360 : 480))); break;
                case 22: SetQuality("mp4", new Size(1280, (_Wide ? 720 : 960))); break;
                case 34: SetQuality("flv", new Size(640, (_Wide ? 360 : 480))); break;
                case 35: SetQuality("flv", new Size(854, (_Wide ? 480 : 640))); break;
                case 36: SetQuality("3gp", new Size(320, (_Wide ? 180 : 240))); break;
                case 37: SetQuality("mp4", new Size(1920, (_Wide ? 1080 : 1440))); break;
                case 38: SetQuality("mp4", new Size(2048, (_Wide ? 1152 : 1536))); break;
                case 43: SetQuality("webm", new Size(640, (_Wide ? 360 : 480))); break;
                case 44: SetQuality("webm", new Size(854, (_Wide ? 480 : 640))); break;
                case 45: SetQuality("webm", new Size(1280, (_Wide ? 720 : 960))); break;
                case 46: SetQuality("webm", new Size(1920, (_Wide ? 1080 : 1440))); break;
                case 82: SetQuality("3D mp4", new Size(480, (_Wide ? 270 : 360))); break;
                case 83: SetQuality("3D mp4", new Size(640, (_Wide ? 360 : 480))); break;
                case 84: SetQuality("3D mp4", new Size(1280, (_Wide ? 720 : 960))); break;
                case 85: SetQuality("3D mp4", new Size(1920, (_Wide ? 1080 : 1440))); break;
                case 100: SetQuality("3D webm", new Size(640, (_Wide ? 360 : 480))); break;
                case 101: SetQuality("3D webm", new Size(640, (_Wide ? 360 : 480))); break;
                case 102: SetQuality("3D webm", new Size(1280, (_Wide ? 720 : 960))); break;
                case 120: SetQuality("live flv", new Size(1280, (_Wide ? 720 : 960))); break;
                default: SetQuality("itag-" + TagQuality, new Size(0, 0)); break;
            }
        }

        public void SetQuality(string Extention, Size Dimension)
        {
            this.Extention = Extention;
            this.Dimension = Dimension;
        }

        public void SetSize(long size)
        {
            this.VideoSize = size;
        }
    }
    public class VideoScanner : IDisposable
    {
        private WebBrowser _browser;
        public VideoScanner(string urltoscan)
        {
            URL = urltoscan;
            Ready = false;
            Title = "Unknown" + ((int)(new Random().NextDouble() * 10000));
            if (URL.IndexOf("youtube.com") > -1)
            {
                string web = DownloadWebPage(URL);
                List<string> s2 = ExtractUrls(web);
                string t3 = GetTitle(web);
                if (t3 != null)
                {
                    string y = "";
                    for (int c = 0; c < t3.Length; c++)
                    {
                        if (char.IsLetterOrDigit(t3[c]) || char.IsWhiteSpace(t3[c]))
                            y += t3[c];
                    }
                    if (!string.IsNullOrEmpty(y))
                        Title = y;
                }

                List<YouTubeVideoQuality> yvq = new List<YouTubeVideoQuality>();
                for (int a = 0; a < s2.Count; a++)
                {
                    YouTubeVideoQuality q = new YouTubeVideoQuality();
                    q.VideoUrl = URL;
                    q.VideoTitle = Title;
                    q.DownloadUrl = s2[a]; //+ "&title=" + t3;
                    bool IsWide = IsWideScreen(web);
                    string itag = GetTxtBtwn(q.DownloadUrl, "itag=", "&", 0);
                    int iTagValue = 0;
                    if (itag != "")
                    {
                        if (int.TryParse(itag, out iTagValue) == false)
                            iTagValue = 0;
                    }
                    q.TagQuality = iTagValue;
                    q.ProcessQuality();
                    yvq.Add(q);
                }
                int qua = 0;
                YouTubeVideoQuality qq = null;
                foreach (YouTubeVideoQuality qual in yvq)
                {
                    if (qua < qual.TagQuality)
                    {
                        qq = qual;
                        qua = qual.TagQuality;
                    }
                }
                VideoURL = qq.DownloadUrl;
                Ready = true;
            }
            else
            {
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
        }

        public static string[] GetQualityStrings(string url)
        {
            if (url.IndexOf("youtube.com") > -1)
            {
                string web = DownloadWebPage(url);
                List<string> s2 = ExtractUrls(web);
                List<string> tye = new List<string>();
                List<YouTubeVideoQuality> yvq = new List<YouTubeVideoQuality>();
                for (int a = 0; a < s2.Count; a++)
                {
                    YouTubeVideoQuality q = new YouTubeVideoQuality();
                    q.VideoUrl = url;
                    q.DownloadUrl = s2[a]; //+ "&title=" + t3;
                    try
                    {
                        q.Length = long.Parse(Regex.Match(web, "\"length_seconds\":(.+?),", RegexOptions.Singleline).Groups[1].ToString());
                    }
                    catch (Exception)
                    { }
                    bool IsWide = IsWideScreen(web);
                    GetSize(q);
                    string itag = GetTxtBtwn(q.DownloadUrl, "itag=", "&", 0);
                    int iTagValue = 0;
                    if (itag != "")
                    {
                        if (int.TryParse(itag, out iTagValue) == false)
                            iTagValue = 0;
                    }
                    q.TagQuality = iTagValue;
                    q.ProcessQuality();
                    string stye = q.Extention + " (" + q.Dimension.Width + "x" + q.Dimension.Height + ")";
                    if (q.VideoSize > 0)
                        stye += " (About " + (q.VideoSize / 1024 / 1024) + " mb)";
                    tye.Add(stye);
                }
                return tye.ToArray();
            }
            return null;
        }

        public static Boolean IsWideScreen(string html)
        {
            bool res = false;

            string match = Regex.Match(html, @"'IS_WIDESCREEN':\s+(.+?)\s+", RegexOptions.Singleline).Groups[1].ToString().ToLower().Trim();
            res = ((match == "true") || (match == "true,"));
            return res;
        }

        private static string GetTitle(string RssDoc)
        {
            string str14 = GetTxtBtwn(RssDoc, "'VIDEO_TITLE': '", "'", 0);
            if (str14 == "") str14 = GetTxtBtwn(RssDoc, "\"title\" content=\"", "\"", 0);
            if (str14 == "") str14 = GetTxtBtwn(RssDoc, "&title=", "&", 0);
            str14 = str14.Replace(@"\", "").Replace("'", "&#39;").Replace("\"", "&quot;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("+", " ");
            return str14;
        }

        private static bool GetSize(YouTubeVideoQuality q)
        {
            try
            {
                HttpWebRequest fileInfoRequest = (HttpWebRequest)HttpWebRequest.Create(q.DownloadUrl);
                HttpWebResponse fileInfoResponse = (HttpWebResponse)fileInfoRequest.GetResponse();
                long bytesLength = fileInfoResponse.ContentLength;
                fileInfoRequest.Abort();
                if (bytesLength != -1)
                {
                    q.SetSize(bytesLength);
                    return true;
                }
                else return false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public static string DownloadWebPage(string Url)
        {
            return DownloadWebPage(Url, null);
        }

        public static IWebProxy InitialProxy()
        {
            string address = address = getIEProxy();
            if (!string.IsNullOrEmpty(address))
            {
                WebProxy proxy = new WebProxy(address);
                proxy.Credentials = CredentialCache.DefaultNetworkCredentials;
                return proxy;
            }
            else return null;
        }

        private static string getIEProxy()
        {
            var p = WebRequest.DefaultWebProxy;
            if (p == null) return null;
            WebProxy webProxy = null;
            if (p is WebProxy) webProxy = p as WebProxy;
            else
            {
                Type t = p.GetType();
                var s = t.GetProperty("WebProxy", (BindingFlags)0xfff).GetValue(p, null);
                webProxy = s as WebProxy;
            }
            if (webProxy == null || webProxy.Address == null || string.IsNullOrEmpty(webProxy.Address.AbsolutePath))
                return null;
            return webProxy.Address.Host;
        }

        private static string DownloadWebPage(string Url, string stopLine)
        {
            try
            {
                HttpWebRequest WebRequestObject = (HttpWebRequest)HttpWebRequest.Create(Url);
                WebRequestObject.Proxy = InitialProxy();
                WebRequestObject.UserAgent = ".NET Framework/2.0";
                WebResponse Response = WebRequestObject.GetResponse();
                Stream WebStream = Response.GetResponseStream();
                StreamReader Reader = new StreamReader(WebStream);
                string PageContent = "", line;
                if (stopLine == null)
                    PageContent = Reader.ReadToEnd();
                else while (!Reader.EndOfStream)
                    {
                        line = Reader.ReadLine();
                        PageContent += line + Environment.NewLine;
                        if (line.Contains(stopLine)) break;
                    }
                Reader.Close();
                WebStream.Close();
                Response.Close();

                return PageContent;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static List<string> ExtractUrls(string html)
        {
            List<string> urls = new List<string>();
            string DataBlockStart = "\"url_encoded_fmt_stream_map\":\\s+\"(.+?)&";  // Marks start of Javascript Data Block

            html = Uri.UnescapeDataString(Regex.Match(html, DataBlockStart, RegexOptions.Singleline).Groups[1].ToString());

            string firstPatren = html.Substring(0, html.IndexOf('=') + 1);
            var matchs = Regex.Split(html, firstPatren);
            for (int i = 0; i < matchs.Length; i++)
                matchs[i] = firstPatren + matchs[i];
            foreach (var match in matchs)
            {
                if (!match.Contains("url=")) continue;

                string url = GetTxtBtwn(match, "url=", "\\u0026", 0);
                if (url == "") url = GetTxtBtwn(match, "url=", ",url", 0);
                if (url == "") url = GetTxtBtwn(match, "url=", "\",", 0);

                string sig = GetTxtBtwn(match, "sig=", "\\u0026", 0);
                if (sig == "") sig = GetTxtBtwn(match, "sig=", ",sig", 0);
                if (sig == "") sig = GetTxtBtwn(match, "sig=", "\",", 0);

                while ((url.EndsWith(",")) || (url.EndsWith(".")) || (url.EndsWith("\"")))
                    url = url.Remove(url.Length - 1, 1);

                while ((sig.EndsWith(",")) || (sig.EndsWith(".")) || (sig.EndsWith("\"")))
                    sig = sig.Remove(sig.Length - 1, 1);

                if (string.IsNullOrEmpty(url)) continue;
                if (!string.IsNullOrEmpty(sig))
                    url += "&signature=" + sig;
                urls.Add(url);
            }
            return urls;
        }


        public static string GetTxtBtwn(string input, string start, string end, int startIndex)
        {
            return GetTxtBtwn(input, start, end, startIndex, false);
        }

        public static string GetLastTxtBtwn(string input, string start, string end, int startIndex)
        {
            return GetTxtBtwn(input, start, end, startIndex, true);
        }

        private static string GetTxtBtwn(string input, string start, string end, int startIndex, bool UseLastIndexOf)
        {
            int index1 = UseLastIndexOf ? input.LastIndexOf(start, startIndex) :
                                          input.IndexOf(start, startIndex);
            if (index1 == -1) return "";
            index1 += start.Length;
            int index2 = input.IndexOf(end, index1);
            if (index2 == -1) return input.Substring(index1);
            return input.Substring(index1, index2 - index1);
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
