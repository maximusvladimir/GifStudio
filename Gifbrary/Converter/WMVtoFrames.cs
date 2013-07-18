using Gifbrary.Common;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;

namespace Gifbrary.Converter
{
    public class WMVtoFrames : FrameDumpConversion
    {
        public WMVtoFrames(Exportable ext, ImageFormat format) : base(ext,format)
        {
        }
    }
}
