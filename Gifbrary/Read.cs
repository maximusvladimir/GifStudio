using Gifbrary.Common;
using Gifbrary.Converter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Gifbrary.Reader
{
    public class Read
    {
        public static Formats GetFormat(string file)
        {
            string p = Path.GetExtension(file).ToLower();
            if (p == ".gif")
                return Formats.GIF;
            else if (p == ".wmv")
                return Formats.WMV;
            else if (p == ".avi")
                return Formats.AVI;
            else if (p == ".mp4")
                return Formats.MP4;
            else
                return Formats.None;
        }

        public static Conversion CreateConversion(Exportable data, int loop)
        {
            if (GetFormat(data.DestinationFilePath) == Formats.GIF && GetFormat(data.SourceFilePath) == Formats.WMV)
            {
                return new WMVtoGIF(data, loop);
            }
            if (GetFormat(data.DestinationFilePath) == Formats.GIF && GetFormat(data.SourceFilePath) == Formats.AVI)
            {
                return new WMVtoGIF(data, loop);
            }
            return null;
        }

        public static Conversion CreateConversion(Exportable data, System.Drawing.Imaging.ImageFormat format)
        {
            //if (GetFormat(data.SourceFilePath) == Formats.WMV)
                return new WMVtoFrames(data, format);
            //return null;
        }
    }
}
