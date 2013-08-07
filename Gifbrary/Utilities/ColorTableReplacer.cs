using Gif.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;

namespace Gifbrary.Utilities
{
    public class ColorTableReplacer
    {
        private string output = "";
        private string intput = "";
        public event EventHandler ProgressChanged;
        public event EventHandler Finished;
        public ColorTableReplacer(string file, string output)
        {
            intput = file;
            this.output = output;
            randomProvider = new Random();
            Grayscale = false;
        }
        public uint QualityColors
        {
            get;
            set;
        }
        public void OnProgressChanged()
        {
            if (ProgressChanged != null)
            {
                ProgressChanged(this, EventArgs.Empty);
            }
        }
        public void OnFinished()
        {
            if (Finished != null)
                Finished(this, EventArgs.Empty);
        }
        public float Progress
        {
            get;
            set;
        }
        bool kill = false;
        public void Kill()
        {
            kill = true;
        }
        public bool Grayscale
        {
            get;
            set;
        }
        public void StartAsync()
        {
            System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(delegate()
                {
                    Start();
                }));
            thread.Start();
        }
        public void Start()
        {
            Bitmap gif = new Bitmap(intput);
            AnimatedGifEncoder e = new AnimatedGifEncoder();
            e.Start(output);
            byte[] repeats = gif.GetPropertyItem(0x5101).Value;
            if (repeats != null && repeats.Length >= 1)
                e.SetRepeat(repeats[0]);
            else
                e.SetRepeat(0);
            byte[] times = gif.GetPropertyItem(0x5100).Value;
            int dur = BitConverter.ToInt32(times, 0);
            e.SetDelay(dur);
            e.SetTransparent(Color.FromArgb(0, 0, 0, 0));
            FrameDimension dimension = new FrameDimension(gif.FrameDimensionsList[0]);
            int frames = gif.GetFrameCount(dimension);
            for (int c = 0; c < frames; c++)
            {
                if (kill)
                {
                    try
                    {
                        e.Finish();
                    }
                    catch (Exception)
                    { }
                    return;
                }
                gif.SelectActiveFrame(dimension, c);
                using (Bitmap copy = new Bitmap(gif))
                {
                    if (kill)
                    {
                        try
                        {
                            e.Finish();
                        }
                        catch (Exception)
                        { }
                        return;
                    }
                    using (Bitmap nn = SaveGIFWithNewColorTable(copy, QualityColors, true))
                    {
                        e.AddFrame(nn);
                    }
                    if (kill)
                    {
                        try
                        {
                            e.Finish();
                        }
                        catch (Exception)
                        { }
                        return;
                    }
                }
                Progress = ((float)c) / ((float)frames);
                OnProgressChanged();
            }
            gif.Dispose();
            e.Finish();
            OnFinished();
        }
        protected ColorPalette GetColorPalette(uint nColors)
        {
            PixelFormat bitscolordepth = PixelFormat.Format1bppIndexed;
            ColorPalette palette;
            Bitmap bitmap;
            if (nColors > 2)
                bitscolordepth = PixelFormat.Format4bppIndexed;
            if (nColors > 16)
                bitscolordepth = PixelFormat.Format8bppIndexed;
            bitmap = new Bitmap(1, 1, bitscolordepth);
            palette = bitmap.Palette;
            bitmap.Dispose();
            return palette;
        }
        Random randomProvider;
        private Bitmap SaveGIFWithNewColorTable(Bitmap image,uint nColors,bool fTransparent)
        {
            if (nColors > 256)
                nColors = 256;
            if (nColors < 2)
                nColors = 2;
            int Width = image.Width;
            int Height = image.Height;
            Bitmap bitmap = new Bitmap(Width,
                                    Height,
                                    PixelFormat.Format8bppIndexed);
            ColorPalette pal = GetColorPalette(nColors+1);
            if (!Grayscale)
            {
                Dictionary<Color, int> occurences = new Dictionary<Color, int>();
                int darks = 0;
                int halfColors = (int)(nColors / 2);
                for (int x = 0; x < Width; x += 5)
                {
                    for (int y = 0; y < Height; y += 5)
                    {
                        Color c = image.GetPixel(x, y);
                        if (c.R < 35 && c.G < 35 && c.B < 35)
                        {
                            if (darks > halfColors)
                                continue;
                            else
                                darks++;
                        }
                        if (occurences.ContainsKey(c))
                            occurences[c]++;
                        else
                            occurences.Add(c, 1);
                    }
                }
                var sortedDict = (from entry in occurences orderby entry.Value descending select entry).ToDictionary(pair => pair.Key, pair => pair.Value);
                var newDict = sortedDict.Keys.ToArray<Color>();
                pal.Entries[0] = Color.FromArgb(0, 0, 0, 0);
                for (int c = 1; c < nColors + 1; c++)
                {
                    if (c > newDict.Length - 1)
                        break;
                    pal.Entries[c] = newDict[c];
                }
            }
            else
            {
                for (uint i = 0; i < nColors; i++)
                {
                    uint Alpha = 0xFF;
                    uint Intensity = i * 0xFF / (nColors - 1);
                    if (i == 0 && fTransparent)
                        Alpha = 0;
                    pal.Entries[i] = Color.FromArgb((int)Alpha,
                                                    (int)Intensity,
                                                    (int)Intensity,
                                                    (int)Intensity);
                }
            }
            bitmap.Palette = pal;
            Bitmap BmpCopy = new Bitmap(Width,
                                    Height,
                                    PixelFormat.Format32bppArgb);
            {
                Graphics g = Graphics.FromImage(BmpCopy);
                g.PageUnit = GraphicsUnit.Pixel;
                g.DrawImage(image, 0, 0, Width, Height);
                g.Dispose();
            }
            BitmapData bitmapData;
            Rectangle rect = new Rectangle(0, 0, Width, Height);

            bitmapData = bitmap.LockBits(
                rect,
                ImageLockMode.WriteOnly,
                PixelFormat.Format8bppIndexed);

            IntPtr pixels = bitmapData.Scan0;

            unsafe
            {
                byte* pBits;
                if (bitmapData.Stride > 0)
                    pBits = (byte*)pixels.ToPointer();
                else
                    pBits = (byte*)pixels.ToPointer() + bitmapData.Stride * (Height - 1);
                uint stride = (uint)Math.Abs(bitmapData.Stride);

                for (uint row = 0; row < Height; ++row)
                {
                    for (uint col = 0; col < Width; ++col)
                    {
                        Color pixel;
                        byte* p8bppPixel = pBits + row * stride + col;
                        pixel = BmpCopy.GetPixel((int)col, (int)row);
                        double luminance = (pixel.R * 0.299) +
                            (pixel.G * 0.587) +
                            (pixel.B * 0.114);
                        *p8bppPixel = (byte)(luminance * (nColors - 1) / 255 + 0.5);
                    }
                }
            }
            bitmap.UnlockBits(bitmapData);
            return bitmap;
            BmpCopy.Dispose();
        }
    }
}
