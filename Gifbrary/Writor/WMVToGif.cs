using Gif.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Gifbrary.Writor
{
    public class WMVToGif
    {
        public WMVToGif(string output, string input, int width, int height, long start, long end, bool loop, int fps, int quality)
        {
            Output = output;
            Input = input;
            Width = width;
            Height = height;
            TrimStart = start;
            TrimLength = end;
            Loop = loop;
            FPS = fps;
            Quality = quality;
        }

        public string Output
        {
            get;
            set;
        }

        public string Input
        {
            get;
            set;
        }

        public int Width
        {
            get;
            set;
        }

        public int Height
        {
            get;
            set;
        }

        public long TrimStart
        {
            get;
            set;
        }

        public long TrimLength
        {
            get;
            set;
        }

        public int Quality
        {
            get;
            set;
        }

        public int FPS
        {
            get;
            set;
        }

        public bool Loop
        {
            get;
            set;
        }

        public void Convert()
        {
            AnimatedGifEncoder e = new AnimatedGifEncoder();
            e.Start(Output);
            e.SetQuality(modq);
            e.SetDelay(1000 / fps);
            e.SetRepeat(0);
            e.SetSize(w, h);
            for (int i = 0; i < 7; i++)
            {
                e.AddFrame(null);
            }
            e.Finish();
        }

        public void ConvertAsync()
        {
            Thread thread = new Thread(new ThreadStart(Convert));
            thread.Start();
            thread.Priority = ThreadPriority.Highest;
        }
    }
}
