using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.IO;

namespace SharpApng
{
    public class Frame : IDisposable
    {
        private int m_num;
        private int m_den;
        //private Bitmap m_bmp;

        public void Dispose()
        {
            //m_bmp.Dispose();
        }

        /// <summary>
        /// Creates a new Frame.
        /// </summary>
        /// <param name="bmp">The actual bitmap.</param>
        /// <param name="t">The bitmap path.</param>
        /// <param name="num">DelayNum</param>
        /// <param name="den">DelayDen</param>
        public Frame(Bitmap bmp, string t, int num, int den)
        {
            this.m_num = num;
            this.m_den = den;
            DISKPOS = t;
            System.Diagnostics.Debug.WriteLine(t);
            bmp.Save(t, ImageFormat.Png);
            //this.m_bmp = bmp;
        }

        public int DelayNum
        {
            get
            {
                return m_num;
            }
            set
            {
                m_num = value;
            }
        }

        public int DelayDen
        {
            get
            {
                return m_den;
            }
            set
            {
                m_den = value;
            }
        }

        /*public Bitmap Bitmap
        {
            get
            {
                return m_bmp;
            }
            set
            {
                m_bmp = value;
            }
        }*/

        public string DISKPOS
        {
            get;
            set;
        }
    }

    public class Apng : IDisposable
    {
        private List<Frame> m_frames = new List<Frame>();
        private static List<Apng> instances = new List<Apng>();
        private int counter = 0;
        public event EventHandler ProgressChanged;
        public Apng()
        {
            Disposed = false;
            MaxSize = new Size(1, 1);
            instances.Add(this);
        }

        public void OnProgress(float f)
        {
            if (ProgressChanged != null)
                ProgressChanged(this, EventArgs.Empty);
        }

        public float Progress
        {
            get;
            set;
        }

        public static void Shutdown()
        {
            if (instances == null)
                return;
            for (int c = 0; c < instances.Count; c++)
            {
                if (instances[c] != null && !instances[c].Disposed)
                {
                    instances[c].Dispose();
                }
            }
            instances.Clear();
            instances = null;
        }

        public bool Disposed
        {
            get;
            set;
        }

        public void Dispose()
        {
            foreach (Frame frame in m_frames)
                frame.Dispose();
            m_frames.Clear();
            Disposed = true;
            try
            {
                Directory.Delete(GetTempDir());
            }
            catch (Exception)
            {
            }
        }

        public Frame this[int index]
        {
            get
            {
                if (index < m_frames.Count) return m_frames[index];
                else return null;
            }
            set
            {
                if (index < m_frames.Count) m_frames[index] = value;
            }
        }

        private string _t = null;
        private string GetTempDir()
        {
            if (_t == null)
            {
                Random ran = new Random();
                int y = ran.Next();
                if (y < 0)
                    y = y * -1;
                _t = Path.Combine(Path.GetTempPath(),"GIFSTD" + y);
                Directory.CreateDirectory(_t);
            }
            return _t;
        }

       // public void AddFrame(Frame frame)
        //{
          //  m_frames.Add(frame);
        //}

        public void AddFrame(Bitmap bmp, int num, int den)
        {
            if (bmp.Width > MaxSize.Width || bmp.Height > MaxSize.Height)
            {
                MaxSize = new Size(bmp.Width, bmp.Height);
            }
            m_frames.Add(new Frame(bmp,Path.Combine(GetTempDir(),counter+".png"), num, den));
            counter++;
        }

        private Bitmap ExtendImage(Bitmap source, Size newSize)
        {
            Bitmap result = new Bitmap(newSize.Width, newSize.Height);
            using (Graphics g = Graphics.FromImage(result))
            {
                g.DrawImageUnscaled(source, 0, 0);
            }
            return result;
        }

        public Size MaxSize
        {
            get;
            set;
        }

        public void WriteApng(string path, bool firstFrameHidden, bool disposeAfter)
        {
           // Size maxSize = new Size();
            //foreach (Frame frame in m_frames)
            //{
              //  if (frame.Bitmap.Width > maxSize.Width) maxSize.Width = frame.Bitmap.Width;
               // if (frame.Bitmap.Height > maxSize.Height) maxSize.Height = frame.Bitmap.Height;
            //}
            for (int i = 0; i < m_frames.Count; i++)
            {
                Frame frame = m_frames[i];
                using (Bitmap b = new Bitmap(frame.DISKPOS))
                {
                    Bitmap b2 = null;
                    if (b.Width != MaxSize.Width || b.Height != MaxSize.Height)
                    {
                        using (b2 = ExtendImage(b, MaxSize))
                        {
                            ApngBasicWrapper.CreateFrameManaged(b2, frame.DelayNum, frame.DelayDen, i);
                        }
                    }
                    else
                        ApngBasicWrapper.CreateFrameManaged(b, frame.DelayNum, frame.DelayDen, i);
                }
                OnProgress(((float)i) / ((float)m_frames.Count));
            }
            ApngBasicWrapper.SaveApngManaged(path, m_frames.Count, MaxSize.Width, MaxSize.Height, firstFrameHidden);
            if (disposeAfter)
                Dispose();
        }
    }

    public static class ApngBasicWrapper
    {
        public const int PIXEL_DEPTH = 4;

        public static IntPtr MarshalString(string source)
        {
            byte[] toMarshal = Encoding.ASCII.GetBytes(source);
            int size = Marshal.SizeOf(source[0]) * source.Length;
            IntPtr pnt = Marshal.AllocHGlobal(size);
            Marshal.Copy(toMarshal, 0, pnt, source.Length);
            Marshal.Copy(new byte[] { 0 }, 0, new IntPtr(pnt.ToInt32() + size), 1);
            return pnt;
        }

        public static IntPtr MarshalByteArray(byte[] source)
        {
            int size = Marshal.SizeOf(source[0]) * source.Length;
            IntPtr pnt = Marshal.AllocHGlobal(size);
            Marshal.Copy(source, 0, pnt, source.Length);
            return pnt;
        }

        public static void ReleaseData(IntPtr ptr)
        {
            Marshal.FreeHGlobal(ptr);
        }

        public static unsafe byte[] TranslateImage(Bitmap image)
        {
            byte[] result = new byte[image.Width * image.Height * PIXEL_DEPTH];
            BitmapData data = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            byte* p = (byte*)data.Scan0;
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    result[(y * image.Width + x) * PIXEL_DEPTH] = p[x * PIXEL_DEPTH];
                    result[(y * image.Width + x) * PIXEL_DEPTH + 1] = p[x * PIXEL_DEPTH + 1];
                    result[(y * image.Width + x) * PIXEL_DEPTH + 2] = p[x * PIXEL_DEPTH + 2];
                    result[(y * image.Width + x) * PIXEL_DEPTH + 3] = p[x * PIXEL_DEPTH + 3];
                }
                p += data.Stride;
            }
            image.UnlockBits(data);
            return result;
        }

        public static void CreateFrameManaged(Bitmap source, int num, int den, int i)
        {
            IntPtr ptr = MarshalByteArray(TranslateImage(source));
            CreateFrame(ptr, num, den, i, source.Width * source.Height * PIXEL_DEPTH);
            ReleaseData(ptr);
        }

        public static void SaveApngManaged(string path, int frameCount, int width, int height, bool firstFrameHidden)
        {
            IntPtr pathPtr = MarshalString(path);
            byte firstFrame = firstFrameHidden ? (byte)1 : (byte)0;
            SaveAPNG(pathPtr, frameCount, width, height, PIXEL_DEPTH, firstFrame);
            ReleaseData(pathPtr);
        }

    #if APNG32
        private const string apngdll = "apng32.dll";
    #elif APNG64
        private const string apngdll = "apng64.dll";
    #elif APNGIA64
        private const string apngdll = "apngIA64.dll";
    #else
        #error APNG DLL undecided, please set it by defining APNG32\APNG64\APNGIA64 (according to your build type)
    #endif

        [DllImport(apngdll)]
        public static extern void CreateFrame(IntPtr pdata, int num, int den, int i, int len);

        [DllImport(apngdll)]
        public static extern void SaveAPNG(IntPtr path, int frameCount, int width, int height, int bytesPerPixel, byte firstFrameHidden);
    }
}