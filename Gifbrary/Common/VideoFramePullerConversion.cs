﻿using AviFile;
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
            rtmp = Path.Combine(App.AppDataPath, "Downloads\\r" + (new Random().Next()));
            App.CleanupQueue.Add(rtmp);
            try
            {
                Directory.CreateDirectory(rtmp);
            }
            catch (Exception)
            {
            }
            System.Diagnostics.Debug.WriteLine(rtmp);
            ffmpeg = new FFmpeg(ext.SourceFilePath, Path.Combine(rtmp, "%5d.png"));
            FPS = 30;
        }

        int totals = 0;
        string[] files;
        public override void SetupEncoder()
        {
            if (ExportData.Height != 0 && ExportData.Width != 0)
                ffmpeg.Parameters = "-r " + FPS + " -f image2 -s " + ExportData.Width + "x" + ExportData.Height;
            else
                ffmpeg.Parameters = "-r " + FPS + " -f image2";
            ffmpeg.Convert();
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

        public override Image GetFrame(int i)
        {
            return new Bitmap(files[i]);
        }
    }
}
