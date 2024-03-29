﻿using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

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
    public class VideoScanner
    {
        public VideoScanner(string urltoscan)
        {
            URL = urltoscan;
            Ready = false;
            Title = "Unknown" + ((int)(new Random().NextDouble() * 10000));
            if (URL.IndexOf("youtube.com") > -1 || URL.IndexOf("youtu.be") > -1)
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
                if (qq == null && yvq != null && yvq.Count > 0)
                    qq = yvq[0];
                if (qq == null)
                    throw new Exception("Scanner couldn't get video");
                SpecialReferrer = "http://www.ytimg.com";
                VideoURL = qq.DownloadUrl;
                Ready = true;
            }
            else if (URL.IndexOf("vimeo.com") > -1)
            {
                HttpWebRequest req = CreateRequest(URL);
                req.AllowAutoRedirect = false;
                req.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:12.0) Gecko/20100101 Firefox/12.0";
                req.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                req.Headers[HttpRequestHeader.AcceptLanguage] = "ru,en;q=0.8,en-us;q=0.5,uk;q=0.3";
                req.Headers[HttpRequestHeader.AcceptEncoding] = "gzip, deflate";
                req.KeepAlive = true;
                req.Timeout = 20000;
                req.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                string location = "";
                using (HttpWebResponse response = GetResponse(req))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        string pageData = new StreamReader(response.GetResponseStream()).ReadToEnd();
                        try
                        {
                            Title = GetTxtBtwn(pageData, "<meta property=\"og:title\" content=\"", "\">", 0);
                        }
                        catch (Exception)
                        {
                        }
                        string clipId = null;
                        if (Regex.Match(pageData, @"clip_id=(\d+)", RegexOptions.Singleline).Success)
                        {
                            clipId = Regex.Match(pageData, @"clip_id=(\d+)", RegexOptions.Singleline).Groups[1].ToString();
                        }
                        else if (Regex.Match(pageData, @"(\d+)", RegexOptions.Singleline).Success)
                        {
                            clipId = Regex.Match(pageData, @"(\d+)", RegexOptions.Singleline).Groups[1].ToString();
                        }

                        string sig = Regex.Match(pageData, "\"signature\":\"(.+?)\"", RegexOptions.Singleline).Groups[1].ToString();
                        string timestamp = Regex.Match(pageData, "\"timestamp\":(\\d+)", RegexOptions.Singleline).Groups[1].ToString();

                        string videoUrl = string.Format("http://player.vimeo.com/play_redirect?clip_id={0}&sig={1}&time={2}&quality=hd&codecs=H264,VP8,VP6&type=moogaloop_local&embed_location=", clipId, sig, timestamp);
                        try
                        {
                            req = CreateRequest(videoUrl);
                            req.AllowAutoRedirect = false;
                            req.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:12.0) Gecko/20100101 Firefox/12.0";
                            req.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                            req.Headers[HttpRequestHeader.AcceptLanguage] = "ru,en;q=0.8,en-us;q=0.5,uk;q=0.3";
                            req.Headers[HttpRequestHeader.AcceptEncoding] = "gzip, deflate";
                            req.KeepAlive = true;
                            req.Referer = "http://a.vimeocdn.com/p/flash/moogaloop/5.2.55/moogaloop.swf?v=1.0.0";
                            req.Timeout = 20000;
                            req.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                            using (HttpWebResponse response2 = GetResponse(req))
                            {
                                if (response2.StatusCode == HttpStatusCode.Found)
                                {
                                    location = response2.Headers[HttpResponseHeader.Location];
                                }
                            }
                        }
                        catch (Exception)
                        {
                            videoUrl = string.Format("http://player.vimeo.com/play_redirect?clip_id={0}&sig={1}&time={2}&codecs=H264,VP8,VP6&type=moogaloop_local&embed_location=", clipId, sig, timestamp);
                            req = CreateRequest(videoUrl);
                            req.AllowAutoRedirect = false;
                            req.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:12.0) Gecko/20100101 Firefox/12.0";
                            req.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                            req.Headers[HttpRequestHeader.AcceptLanguage] = "ru,en;q=0.8,en-us;q=0.5,uk;q=0.3";
                            req.Headers[HttpRequestHeader.AcceptEncoding] = "gzip, deflate";
                            req.KeepAlive = true;
                            req.Referer = "http://a.vimeocdn.com/p/flash/moogaloop/5.2.55/moogaloop.swf?v=1.0.0";
                            req.Timeout = 20000;
                            req.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                            using (HttpWebResponse response2 = GetResponse(req))
                            {
                                if (response2.StatusCode == HttpStatusCode.Found)
                                {
                                    location = response2.Headers[HttpResponseHeader.Location];
                                }
                            }
                        }
                    }
                }
                VideoURL = location;
                Ready = true;
            }
            else
            {
                List<string> vids = new List<string>();
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(DownloadWebPage(URL));
                string t = null;
                if (doc.DocumentNode.ChildNodes["title"] != null)
                    t = doc.DocumentNode.ChildNodes["title"].InnerText;
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


                HtmlNodeCollection coll = doc.DocumentNode.SelectNodes("video");
                string source = "";
                if (coll != null)
                    for (int c = 0; c < coll.Count; c++)
                    {
                        source = coll[c].GetAttributeValue("src", null);
                        if (string.IsNullOrEmpty(source))
                        {
                            HtmlNodeCollection scoll = coll[c].SelectNodes("source");
                            if (scoll != null)
                                for (int d = 0; d < scoll.Count; d++)
                                {
                                    string s34 = scoll[c].GetAttributeValue("src", null);
                                    if (!string.IsNullOrEmpty(s34))
                                    {
                                        source = s34;
                                        break;
                                    }
                                }
                        }
                    }
                if (string.IsNullOrEmpty(source))
                    NoVideo = true;
                try
                {
                    Uri yuri = new Uri(source);
                }
                catch (Exception)
                {
                    Uri fg;
                    Uri.TryCreate(new Uri(URL), source, out fg);
                    source = fg.ToString();
                }
                System.Diagnostics.Debug.WriteLine(source);
                VideoURL = source;
                
                Ready = true;
            }
        }

        public bool NoVideo
        {
            get;
            set;
        }

        private Dictionary<int, CookieContainer> m_cookieContainer = new Dictionary<int, CookieContainer>();

        private CookieContainer GetCookieContainerPerThread()
        {
            int managedThreadId = System.Threading.Thread.CurrentThread.ManagedThreadId;
            lock (typeof(VideoScanner))
            {
                if (!this.m_cookieContainer.ContainsKey(managedThreadId))
                {
                    CookieContainer container = new CookieContainer();
                    this.m_cookieContainer.Add(managedThreadId, container);
                }
            }
            return this.m_cookieContainer[managedThreadId];
        }

        public HttpWebRequest CreateRequest(string url)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.CookieContainer = this.GetCookieContainerPerThread();
            //this.InitProxy(req);
            return req;
        }

        public HttpWebResponse GetResponse(HttpWebRequest req)
        {
            HttpWebResponse response = (HttpWebResponse)req.GetResponse();
            this.GetCookieContainerPerThread().Add(response.Cookies);
            return response;
        }

        public static string[] GetQualityStrings(string url, ref YouTubeVideoQuality[] quals)
        {
            quals = null;
            string web = "";
            web = DownloadWebPage(url);
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
                if (q.Extention.IndexOf("tag") > -1)
                    continue;
                string stye = q.Extention + " (" + q.Dimension.Width + "x" + q.Dimension.Height + ")";
                if (q.VideoSize > 0)
                    stye += " (About " + (q.VideoSize / 1024 / 1024) + " mb)";
                tye.Add(stye);
                yvq.Add(q);
            }
            quals = yvq.ToArray();
            return tye.ToArray();
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
                WebRequestObject.UserAgent = App.UserAgent;
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
            catch (Exception ex)
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

        public string SpecialReferrer
        {
            get;
            set;
        }
    }
}
