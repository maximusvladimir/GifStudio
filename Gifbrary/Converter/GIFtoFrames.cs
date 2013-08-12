using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gifbrary.Common;
using Gifbrary;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Gifbrary.Converter
{
    public class GIFtoFrames : Conversion
    {
        Bitmap bitmap;
        FrameDimension dim;
        int totals = 0;
        public GIFtoFrames(Exportable ext, ImageFormat form)
            : base(ext)
        {
            Format = form;
        }

        public override void SetupEncoder()
        {
            bitmap = new Bitmap(ExportData.SourceFilePath);
            dim = new FrameDimension(bitmap.FrameDimensionsList[0]);
            totals = bitmap.GetFrameCount(dim);
        }

        public override int GetTotalFrames()
        {
            return totals;
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
            int sleeptime = (int)(Math.Sqrt((ExportData.Width * ExportData.Height)) / 8);
            var fc = new ImageFormatConverter();
            var strf = fc.ConvertToString(Format).ToLower();
            EncoderParameters pars = new EncoderParameters(1);
            pars.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, (long)(100 - ((ExportData.Quality * 99) + 1)));
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

        public override Bitmap GetFrame(int i)
        {
            //System.Diagnostics.Debug.WriteLine("i=" + i + "frames=" + GetTotalFrames() + "DIM=" + dim.Guid);
            bitmap.SelectActiveFrame(dim, i);
            return new Bitmap(bitmap);
        }

        public override void Dispose()
        {
            base.Dispose();
            bitmap.Dispose();
        }
    }
}
