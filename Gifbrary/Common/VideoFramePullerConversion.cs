using AviFile;
using DirectShowLib;
using DirectShowLib.DES;
using Gif.Components;
using Gifbrary.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Gifbrary.Common
{
    public class VideoFramePullerConversion : Conversion
    {
        FFmpeg ffmpeg;

        string rtmp = "";
        public VideoFramePullerConversion(Exportable ext)
            : base(ext)
        {
            string downloads = Path.Combine(App.AppDataPath, "Downloads\\");
            try
            {
                Directory.CreateDirectory(downloads);
            }
            catch (Exception ex)
            {
                //stem.Diagnostics.Debug.WriteLine(ex.Message);
            }
            rtmp = Path.Combine(App.AppDataPath, "Downloads\\" + Guid.NewGuid().ToString().Replace("{","").Replace("}",""));
            App.CleanupQueue.Add(rtmp);
            try
            {
                Directory.CreateDirectory(rtmp);
            }
            catch (Exception ex)
            {
                //stem.Diagnostics.Debug.WriteLine(ex.Message);
            }
            System.Diagnostics.Debug.WriteLine(rtmp);
            ffmpeg = new FFmpeg(ext.SourceFilePath, Path.Combine(rtmp, "%5d.png"));
            if (ext.FPS > 0)
                FPS = ext.FPS;
            else
                FPS = 30;
        }

        int totals = 0;
        string[] files;
        public override void SetupEncoder()
        {
            string tetb = "";
            string yerr = "";
            if (!string.IsNullOrEmpty(ExportData.TrimLength) && !string.IsNullOrEmpty(ExportData.TrimStart))
            {
                tetb = "-ss "+ExportData.TrimStart;
                yerr = " -t " + ExportData.TrimLength;
                tetb = tetb + yerr;
            }
            ffmpeg.PreParameters = tetb;
            if (ExportData.Height != 0 && ExportData.Width != 0)
                ffmpeg.Parameters = "-r " + FPS + " -f image2 -s " + ExportData.Width + "x" + ExportData.Height;
            else
                ffmpeg.Parameters = "-r " + FPS + " -f image2";
            ffmpeg.Convert();
            System.Diagnostics.Debug.WriteLine("Exiting context");
            try
            {
                files = Directory.GetFiles(rtmp);
                totals = files.Length;
            }
            catch (Exception)
            {
            }
        }

        public override int GetTotalFrames()
        {
            return totals;
        }

        public int FPS
        {
            get;
            set;
        }

        public override Bitmap GetFrame(int i)
        {
            return new Bitmap(files[i]);
        }
    }
}
