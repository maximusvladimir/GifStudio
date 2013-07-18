using DirectShowLib;
using DirectShowLib.DES;
using Gifbrary.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Gifbrary.Converter
{
    public class WMVtoGIF : GifConversion
    {
        public WMVtoGIF(Exportable ext, int loop)
            : base(ext,loop)
        {

        }
    }
}
