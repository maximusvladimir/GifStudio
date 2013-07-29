using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace VideoCodecLib
{
    public class Converter
    {
        private static string ffmpeg_path = "";
        private static bool init = false;
        public static void Init()
        {
            init = true;
            string path = "";
            try
            {
                path = Path.Combine(Path.GetTempPath(), "\\GifStudio\\");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
            }
            catch(Exception)
            {
            }
            ffmpeg_path = Path.Combine(Path.Combine(Path.GetTempPath(), "\\GifStudio\\"), "ffmpeg.exe");
            if (!File.Exists(ffmpeg_path))
            {
                WebClient client = new WebClient();
                client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                string ffmpeglink = "http://k002.kiwi6.com/hotlink/2a665gwnh2/ffmpeg.exe";
                client.DownloadFile(ffmpeglink, ffmpeg_path);
            }
        }

        public event EventHandler ProgressMonitor;
        public Converter(string input, string output)
        {
            if (!init)
                Init();
            Input = input;
            Output = output;
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

        public ResultCode Convert()
        {
            string fileargs = "-i" + " " + Input + "  " + Output;
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = ffmpeg_path;
            p.StartInfo.Arguments = fileargs;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.OutputDataReceived += p_OutputDataReceived;
            p.Start();
            p.WaitForExit();

            return ResultCode.SUCCESS;
        }

        private void p_OutputDataReceived(object sender, System.Diagnostics.DataReceivedEventArgs e)
        {
            
        }
    }
}
