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

namespace Gifbrary.Common
{
    public class APngConversion : VideoFramePullerConversion2
    {
        public APngConversion(Exportable ext, int loop)
            : base(ext)
        {
            Loop = loop;
        }

        public int Loop
        {
            get;
            set;
        }

        public override void Convert()
        {
            Apng ping = new Apng();
            //e.SetSize(Width, Height);
            SetupEncoder();
            if (kill)
                return;
            for (int i = 0; i < GetTotalFrames(); i++)
            {
                if (kill)
                    return;
                Image b = GetFrame(i);
                ping.AddFrame((Bitmap)b, 10, 10);
                OnProgressChanged(i);
            }
            ping.WriteApng(ExportData.DestinationFilePath.Replace(".gif",".apng"),true,true);
            IsDone = true;
        }
    }
}
