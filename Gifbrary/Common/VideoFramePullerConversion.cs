using Interop.qedit;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace Gifbrary.Common
{
    public class VideoFramePullerConversion : Conversion
    {
        public VideoFramePullerConversion(Exportable export)
            : base(export)
        { }

        public override void SetupEncoder()
        {

        }

        public override int GetTotalFrames()
        {
            return 0;
        }

        public override System.Drawing.Image GetFrame(int i)
        {
            return null;
        }
    }
}
