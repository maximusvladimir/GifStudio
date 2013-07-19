using DirectShowLib;
using DirectShowLib.DES;
using Gif.Components;
using Gifbrary.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Gifbrary.Common
{
    public class GifConversion : VideoFramePullerConversion
    {
        public GifConversion(Exportable ext, int loop)
            :base(ext)
        {
            Loop = loop;
        }

        public int Loop
        {
            get;set;
        }

        public override void Convert()
        {
            AnimatedGifEncoder e = new AnimatedGifEncoder();
            e.Start(ExportData.DestinationFilePath);
            e.SetQuality(21 - ((ExportData.Quality * 20) / 100));
            e.SetDelay(1000 / ExportData.FPS);
            e.SetRepeat(Loop);
            if (ExportData.ChromaKey != null)
                e.SetTransparent((Color)ExportData.ChromaKey);
            //e.SetSize(Width, Height);
            SetupEncoder();
            if (kill)
                return;
            for (int i = 0; i < GetTotalFrames(); i++)
            {
                if (kill)
                    return;
                e.AddFrame(GetFrame(i));
                OnProgressChanged(i);
            }
            e.Finish();
            IsDone = true;
        }
    }
}
