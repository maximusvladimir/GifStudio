﻿using Gifbrary.Utilities;
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

        public static long GetVideoDuration(string vidFile)
        {
            FFmpeg ffmpegWorker = new FFmpeg(vidFile, "");
            ffmpegWorker.Convert();
            return ffmpegWorker.TotalTicks;
        }

        /*public static void UnloadSourceFolder(string file)
        {
            string dis = Path.Combine(Path.GetTempPath(), "fsakami" + (new Random().Next()) + ".tar.gz");
            byte[] bytecode = global::Gifbrary.Properties.Resources.ffmpeg_master_tar;
            File.WriteAllBytes(dis, bytecode);
            bytecode = null;
            System.Diagnostics.Debug.WriteLine(file);
            var archive = ArchiveFactory.Open(dis);
            foreach (var entry in archive.Entries)
            {
                if (!entry.IsDirectory)
                {
                    Console.WriteLine(entry.FilePath);
                    entry.WriteToDirectory(file, ExtractOptions.ExtractFullPath | ExtractOptions.Overwrite);
                }
            }
            try
            {
                File.Delete(dis);
            }
            catch (Exception)
            {
            }
        }*/

        public static void UnloadSource7z(string file)
        {
            File.WriteAllBytes(file, global::Gifbrary.Properties.Resources.ffmpeg_master_tar);
        }

        public event EventHandler ProgressChanged;
        public event EventHandler Completed;
        public FFmpeg(string input, string output)
        {
            Input = input;
            Output = output;
            Parameters = "";
            PreParameters = "";
        }

        public void ConvertAsync()
        {
            Thread thread = new Thread(new ThreadStart(Convert));
            thread.Priority = ThreadPriority.Highest;
            thread.Start();
            thread.Priority = ThreadPriority.Highest;
        }

        public string Parameters
        {
            get;
            set;
        }

        public float Progress
        {
            get;
            set;
        }

        public string PreParameters
        {
            get;
            set;
        }

        public void Convert()
        {
            string fileargs = "";
            fileargs = PreParameters + " -i" + " \"" + Input + "\" " + Parameters + " -metadata handler_name=\"GifStudio\" \"" + Output + "\"";
            System.Diagnostics.Debug.WriteLine(fileargs);
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            App.CleanupQueue.Add(p);
            p.StartInfo.FileName = FFmpegPath;
            p.StartInfo.Arguments = fileargs;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.ErrorDataReceived += delegate(object sender, System.Diagnostics.DataReceivedEventArgs e)
            {
                Parse(e.Data);
            };
            p.OutputDataReceived += delegate(object sender, System.Diagnostics.DataReceivedEventArgs e)
            {
                Parse(e.Data);
            };
            p.EnableRaisingEvents = true;
            p.Start();
            p.BeginOutputReadLine();
            p.BeginErrorReadLine();
            p.WaitForExit();
            if (Completed != null)
                Completed(this, EventArgs.Empty);
            /*p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.Start();
            string data = "";
            while ((data = p.StandardOutput.ReadLine()) != null)
            {
                System.Diagnostics.Debug.WriteLine(data);
            }
            p.WaitForExit();*/
        }

        private void Parse(string output)
        {
            if (output != null)
            {
                System.Diagnostics.Debug.WriteLine(output);
                if (output.IndexOf("Duration: ") > -1)
                {
                    string btw = null;
                    try
                    {
                        btw = VideoScanner.GetTxtBtwn(output, "Duration: ", ",", 0);
                    }
                    catch (Exception)
                    { }
                    if (btw != null)
                    {
                        TotalTicks = TimeSpan.Parse(btw).Ticks;
                    }
                }
                else if (output.IndexOf("frame=") > -1)
                {
                    string btw = null;
                    try
                    {
                        btw = VideoScanner.GetTxtBtwn(output, "time=", " ", 0);
                    }
                    catch (Exception)
                    {

                    }
                    if (btw != null)
                    {
                        long tic = 0;
                        try
                        {
                            tic = TimeSpan.Parse(btw).Ticks;
                        }
                        catch (Exception)
                        { }
                        if (TotalTicks != 0)
                        {
                            float p = ((float)tic) / ((float)TotalTicks);
                            if (p > 1)
                                p = 1;
                            if (p < 0)
                                p = 0;
                            Progress = p;
                            if (ProgressChanged != null)
                            {
                                ProgressChanged(this, EventArgs.Empty);
                            }
                        }
                    }
                }
            }
        }

        public long TotalTicks
        {
            get;
            set;
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
