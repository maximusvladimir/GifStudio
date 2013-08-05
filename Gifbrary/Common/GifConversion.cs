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
using SharpApng;
using Gifbrary.Utilities;

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
            //SharpApng.Apng ping = new Apng();
            AnimatedGifEncoder e = new AnimatedGifEncoder();
            e.Start(ExportData.DestinationFilePath);
            e.SetQuality((int)(20-(20 * ExportData.Quality)));
            e.SetDelay(1000 / ExportData.FPS);
            e.SetRepeat(Loop);
            if (ExportData.ChromaKey != null)
                e.SetTransparent((Color)ExportData.ChromaKey);
            //e.SetSize(Width, Height);
            SetupEncoder();
            if (kill)
                return;
            var ocd = new OrderedColorDithering();
            for (int i = 0; i < GetTotalFrames(); i++)
            {
                if (kill)
                    return;
                Bitmap b = GetFrame(i);
                //if (ExportData.Quality < 30)
                  //  b = ocd.Apply(b);
                e.AddFrame(b);
              //  ping.AddFrame((Bitmap)b, 10, 10);
                OnProgressChanged(i);
            }
            //ping.WriteApng(ExportData.DestinationFilePath.Replace(".gif",".apng"),true,true);
            e.Finish();
            IsDone = true;
            OnConversionFinished();
        }
    }
}
