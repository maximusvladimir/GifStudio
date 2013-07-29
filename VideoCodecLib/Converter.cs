using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoCodecLib
{
    public class Converter
    {
        private static string ffmpeg_path = "";
        public static event EventHandler ProgressMonitor;
        public static void Init()
        {
            byte[] bytecode = global::VideoCodecLib.Properties.Resources.ffmpeg;
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
            File.WriteAllBytes(ffmpeg_path, bytecode);
        }

        public static void Shutdown()
        {
            try
            {
                File.Delete(ffmpeg_path);
            }
            catch (Exception)
            {
            }
        }

        public static ResultCode Convert(string input, string output)
        {
            string fileargs = "-i" + " " + input + "  " + output;
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

        private static void p_OutputDataReceived(object sender, System.Diagnostics.DataReceivedEventArgs e)
        {
            
        }
    }
}
