using Gif.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;

namespace Gifbrary.Common
{
    public abstract class Conversion : IDisposable
    {
        private Thread thread;
        protected bool kill = false;
        public event EventHandler ProgressChanged;
        public event EventHandler ConversionFinished;
        public Conversion(Exportable ext)
        {
            ExportData = ext;
            IsDone = false;
        }

        public void OnConversionFinished()
        {
            if (ConversionFinished != null)
            {
                ConversionFinished(this, EventArgs.Empty);
            }
        }

        public void OnProgressChanged(int i)
        {
            if (ProgressChanged != null)
            {
                ProgressChanged(((float)i) / ((float)GetTotalFrames()), EventArgs.Empty);
            }
        }

        public Exportable ExportData
        {
            get;
            set;
        }

        public bool IsDone
        {
            get;
            protected set;
        }

        public abstract void SetupEncoder();

        public abstract int GetTotalFrames();

        public abstract Bitmap GetFrame(int i);

        public virtual void Convert()
        {
            
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

        public virtual void Dispose()
        {
        }
    }
}
