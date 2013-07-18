using Gif.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;

namespace Gifbrary.Common
{
    public abstract class Conversion
    {
        private Thread thread;
        private bool kill = false;
        public event EventHandler ProgressChanged;
        public Conversion(string output, string input, int width, int height, long start, long end, int loop, int fps, int quality)
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
            IsDone = false;
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

        public int Loop
        {
            get;
            set;
        }

        public bool IsDone
        {
            get;
            private set;
        }

        public abstract void SetupEncoder();

        public abstract int GetTotalFrames();

        public abstract Image GetFrame(int i);

        public void Convert()
        {
            AnimatedGifEncoder e = new AnimatedGifEncoder();
            e.Start(Output);
            e.SetQuality(21 - ((Quality * 20) / 100));
            e.SetDelay(1000 / FPS);
            e.SetRepeat(Loop);
            e.SetSize(Width, Height);
            SetupEncoder();
            if (kill)
                return;
            for (int i = 0; i < GetTotalFrames(); i++)
            {
                if (kill)
                    return;
                e.AddFrame(GetFrame(i));
                if (ProgressChanged != null)
                {
                    ProgressChanged((i * 100) / GetTotalFrames(), EventArgs.Empty);
                }
            }
            e.Finish();
            IsDone = true;
        }

        private int Progress
        {
            set;
            get;
        }

        public void Kill()
        {
            kill = true;
        }

        public void ConvertAsync()
        {
            thread = new Thread(new ThreadStart(Convert));
            thread.Start();
            thread.Priority = ThreadPriority.Highest;
        }
    }
}
