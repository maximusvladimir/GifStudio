﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;

namespace Gifbrary.Common
{
    public class FrameDumpConversion : VideoFramePullerConversion2
    {
        public FrameDumpConversion(Exportable ext, ImageFormat format) : base(ext)
        {
            Format = format;
        }

        public ImageFormat Format
        {
            get;
            set;
        }
        private static ImageCodecInfo FindEncoder(ImageFormat format)
        {
            foreach (ImageCodecInfo imageCodecInfo in ImageCodecInfo.GetImageEncoders())
            {
                if (imageCodecInfo.FormatID.Equals(format.Guid))
                    return imageCodecInfo;
            }
            return (ImageCodecInfo)null;
        }
        public override void Convert()
        {
            System.Threading.Thread.Sleep(2750);
            SetupEncoder();
            try
            {
                if (!Directory.Exists(ExportData.DestinationFilePath))
                {
                    Directory.CreateDirectory(ExportData.DestinationFilePath);
                }
            }
            catch (Exception)
            {
            }
            int sleeptime = (int)(Math.Sqrt((ExportData.Width * ExportData.Height))/8);
            var fc = new ImageFormatConverter();
            var strf = fc.ConvertToString(Format).ToLower();
            EncoderParameters pars = new EncoderParameters(1);
            pars.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, (byte)ExportData.Quality);
            ImageCodecInfo encoder = FindEncoder(Format) ?? FindEncoder(ImageFormat.Png);
            for (int c = 0; c < GetTotalFrames(); c++)
            {
                if (kill)
                    return;
                string file = ExportData.DestinationFilePath;
                if (ExportData.NamingConventionZeros != 0)
                {
                    if (ExportData.NamingConventionPrefix)
                        file = Path.Combine(file, ExportData.NamingConvetion + c.ToString("D" + ExportData.NamingConventionZeros) + "." + strf);
                    else
                        file = Path.Combine(file, c.ToString("D" + ExportData.NamingConventionZeros) + ExportData.NamingConvetion + "." + strf);
                }
                else
                {
                    if (ExportData.NamingConventionPrefix)
                        file = Path.Combine(file, ExportData.NamingConvetion + c + "." + strf);
                    else
                        file = Path.Combine(file, c + ExportData.NamingConvetion + "." + strf);
                }
                GetFrame(c).Save(file, encoder, pars);
                System.Threading.Thread.Sleep(sleeptime);
                OnProgressChanged(c);
            }
            IsDone = true;
            OnConversionFinished();
        }
    }
}
