using Gifbrary.Common;
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
            string p = Path.GetExtension(file);
            if (p == ".gif")
                return Formats.GIF;
            else if (p == ".wmv")
                return Formats.WMV;
            else if (p == ".avi")
                return Formats.AVI;
            else
                return Formats.None;
        }
    }
}
