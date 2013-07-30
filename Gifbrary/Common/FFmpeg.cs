using SharpCompress.Archive;
using SharpCompress.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace Gifbrary.Common
{
    public class FFmpeg
    {
        private static bool isInited = false;
        public static readonly string FFmpegPath = Path.Combine(App.AppDataPath, "ffmpeg.exe");
        public static void Init()
        {
            string dest = FFmpegPath;
            
            if (!File.Exists(dest))
            {
                string dis = Path.Combine(App.AppDataPath, "ffmpeg.7z");
                byte[] bytecode = global::Gifbrary.Properties.Resources.ffmpeg;
                File.WriteAllBytes(dis, bytecode);
                bytecode = null;
                using (var archive = ArchiveFactory.Open(dis))
                {
                    foreach (var entry in archive.Entries)
                    {
                        if (!entry.IsDirectory)
                        {
                            entry.WriteToDirectory(
                                App.AppDataPath, ExtractOptions.ExtractFullPath | ExtractOptions.Overwrite);
                        }
                    }
                }
                try
                {
                    File.Delete(dis);
                }
                catch (Exception)
                {
                }
            }
            isInited = true;
        }

        public event EventHandler ProgressChanged;
        public FFmpeg(string input, string output)
        {
            Input = input;
            Output = output;
        }

        public void ConvertAsync()
        {
            Thread thread = new Thread(new ThreadStart(Convert));
            thread.Priority = ThreadPriority.Highest;
            thread.Start();
            thread.Priority = ThreadPriority.Highest;
        }

        public float Progress
        {
            get;
            set;
        }

        public void Convert()
        {
            string fileargs = "-i" + " \"" + Input + "\"  \"" + Output + "\"";
            System.Diagnostics.Debug.WriteLine(fileargs);
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = FFmpegPath;
            p.StartInfo.Arguments = fileargs;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.OutputDataReceived += p_OutputDataReceived;
            p.Start();
            p.WaitForExit();
        }

        private void p_OutputDataReceived(object sender, System.Diagnostics.DataReceivedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(e.Data);
        }

        public string Input
        {
            get;
            set;
        }

        public string Output
        {
            get;
            set;
        }
    }
}
