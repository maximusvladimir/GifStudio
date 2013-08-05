using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;

namespace Gifbrary.Utilities
{
    /// <summary>
    /// Color dithering with a thresold matrix (ordered dithering).
    /// </summary>
    /// 
    /// <remarks><para>The class implements ordered color dithering as described on
    /// <a href="http://en.wikipedia.org/wiki/Ordered_dithering">Wikipedia</a>.
    /// The algorithm achieves dithering by applying a <see cref="ThresholdMatrix">threshold map</see> on
    /// the pixels displayed, causing some of the pixels to be rendered at a different color, depending on
    /// how far in between the color is of available <see cref="ColorTable">color entries</see>.</para>
    /// 
    /// <para>The image processing routine accepts 24/32 bpp color images for processing. As a result this routine
    /// produces 4 bpp or 8 bpp indexed image, which depends on size of the specified
    /// <see cref="ColorTable">color table</see> - 4 bpp result for
    /// color tables with 16 colors or less; 8 bpp result for larger color tables.</para>
    /// 
    /// <para>Sample usage:</para>
    /// <code>
    /// // create color image quantization routine
    /// ColorImageQuantizer ciq = new ColorImageQuantizer( new MedianCutQuantizer( ) );
    /// // create 256 colors table
    /// Color[] colorTable = ciq.CalculatePalette( image, 256 );
    /// // create dithering routine
    /// OrderedColorDithering dithering = new OrderedColorDithering( );
    /// dithering.ColorTable = colorTable;
    /// // apply the dithering routine
    /// Bitmap newImage = dithering.Apply( image );
    /// </code>
    /// 
    /// <para><b>Initial image:</b></para>
    /// <img src="img/imaging/sample1.jpg" width="480" height="361" />
    /// <para><b>Result image:</b></para>
    /// <img src="img/imaging/ordered_color_dithering.png" width="480" height="361" />
    /// </remarks>
    /// 
    public class OrderedColorDithering
    {
        private bool useCaching = false;

        private Color[] colorTable = new Color[16]
        {
            Color.Black,   Color.DarkBlue,    Color.DarkGreen, Color.DarkCyan,
            Color.DarkRed, Color.DarkMagenta, Color.DarkKhaki, Color.LightGray,
            Color.Gray,    Color.Blue,        Color.Green,     Color.Cyan,
            Color.Red,     Color.Magenta,     Color.Yellow,    Color.White
        };

        private byte[,] matrix = new byte[4, 4]
                {
                        {  2, 18,  6, 22 },
                        { 26, 10, 30, 14 },
                        {  8, 24,  4, 20 },
                        { 32, 16, 28, 12 }
                };

        /// <summary>
        /// Threshold matrix - values to add source image's values.
        /// </summary>
        /// 
        /// <remarks><para>The property keeps a threshold matrix, which is applied to values of a source image
        /// to dither. By adding these values to the source image the algorithm produces the effect when pixels
        /// of the same color in source image may have different color in the result image (which depends on pixel's
        /// position). This threshold map is also known as an index matrix or Bayer matrix.</para>
        /// 
        /// <para>By default the property is inialized with the below matrix:
        /// <code lang="none">
        ///  2   18    6   22
        /// 26   10   30   14
        ///  8   24    4   20
        /// 32   16   28   12
        /// </code>
        /// </para>
        /// </remarks>
        /// 
        public byte[,] ThresholdMatrix
        {
            get { return (byte[,])matrix.Clone(); }
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Threshold matrix cannot be set to null.");
                }
                matrix = value;
            }
        }

        /// <summary>
        /// Color table to use for image dithering. Must contain 2-256 colors.
        /// </summary>
        /// 
        /// <remarks><para>Color table size determines format of the resulting image produced by this
        /// image processing routine. If color table contains 16 color or less, then result image will have
        /// 4 bpp indexed pixel format. If color table contains more than 16 colors, then result image will
        /// have 8 bpp indexed pixel format.</para>
        /// 
        /// <para>By default the property is initialized with default 16 colors, which are:
        /// Black, Dark Blue, Dark Green, Dark Cyan, Dark Red, Dark Magenta, Dark Khaki, Light Gray,
        /// Gray, Blue, Green, Cyan, Red, Magenta, Yellow and White.</para>
        /// </remarks>
        /// 
        /// <exception cref="ArgumentException">Color table length must be in the [2, 256] range.</exception>
        /// 
        public Color[] ColorTable
        {
            get { return colorTable; }
            set
            {
                if ((colorTable.Length < 2) || (colorTable.Length > 256))
                    throw new ArgumentException("Color table length must be in the [2, 256] range.");

                colorTable = value;
            }
        }

        /// <summary>
        /// Use color caching during color dithering or not.
        /// </summary>
        /// 
        /// <remarks><para>The property  specifies if internal cache of already processed colors should be used or not.
        /// For each pixel in the original image the color dithering routine does search in target color palette to find
        /// the best matching color. To avoid doing the search again and again for already processed colors, the class may
        /// use internal dictionary which maps colors of original image to indexes in target color palette.
        /// </para>
        /// 
        /// <para><note>The property provides a trade off. On one hand it may speedup color dithering routine, but on another
        /// hand it increases memory usage. Also cache usage may not be efficient for very small target color tables.</note></para>
        /// 
        /// <para>Default value is set to <see langword="false"/>.</para>
        /// </remarks>
        /// 
        public bool UseCaching
        {
            get { return useCaching; }
            set { useCaching = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderedColorDithering"/> class.
        /// </summary>
        /// 
        public OrderedColorDithering()
        {
            KnownColor[] colors = (KnownColor[])Enum.GetValues(typeof(KnownColor));
            Color[] arr = new Color[colors.Length];
            int counter = 0;
            foreach (KnownColor knowColor in colors)
            {
                arr[counter] = Color.FromKnownColor(knowColor);
                counter++;
            }
            colorTable = arr;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderedColorDithering"/> class.
        /// </summary>
        /// 
        /// <param name="matrix">Threshold matrix (see <see cref="ThresholdMatrix"/> property).</param>
        /// 
        public OrderedColorDithering(byte[,] matrix)
        {
            ThresholdMatrix = matrix;
        }

        /// <summary>
        /// Perform color dithering for the specified image.
        /// </summary>
        /// 
        /// <param name="sourceImage">Source image to do color dithering for.</param>
        /// 
        /// <returns>Returns color dithered image. See <see cref="ColorTable"/> for information about format of
        /// the result image.</returns>
        /// 
        /// <exception cref="UnsupportedImageFormatException">Unsupported pixel format of the source image. It must 24 or 32 bpp color image.</exception>
        /// 
        public Bitmap Apply(Bitmap sourceImage)
        {
            Bitmap result = null;

                result = Apply(sourceImage,true);
                if ((sourceImage.HorizontalResolution > 0) && (sourceImage.VerticalResolution > 0))
                {
                    result.SetResolution(sourceImage.HorizontalResolution, sourceImage.VerticalResolution);
                }

            return result;
        }

        public unsafe Bitmap Apply(Bitmap sourceImage, bool optcode)
        {
            cache.Clear();

            // get image size
            int width = sourceImage.Width;
            int height = sourceImage.Height;
            BitmapData data = sourceImage.LockBits(new Rectangle(0, 0, width,  height), ImageLockMode.ReadOnly,sourceImage.PixelFormat);
            int stride = data.Stride;
            int pixelSize = Bitmap.GetPixelFormatSize(sourceImage.PixelFormat) / 8;

            int offset = stride - width * pixelSize;

            // create destination image
            Bitmap destImage = new Bitmap(width, height, (colorTable.Length > 16) ?
                PixelFormat.Format8bppIndexed : PixelFormat.Format4bppIndexed);
            // and init its palette
            ColorPalette cp = destImage.Palette;
            for (int i = 0, n = colorTable.Length; i < n; i++)
            {
                cp.Entries[i] = colorTable[i];
            }
            destImage.Palette = cp;
            BitmapData destData = destImage.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite, destImage.PixelFormat);
            int r, g, b, toAdd;
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
                        byte* ptr = (byte*)data.Scan0.ToPointer();
            byte* dstBase = (byte*)destData.Scan0.ToPointer();
            byte colorIndex;

            bool is8bpp = (colorTable.Length > 16);
            for (int y = 0; y < height; y++)
            {
                byte* dst = dstBase + y * destData.Stride;
                for (int x = 0; x < width; x++, ptr += pixelSize)
                {
                    toAdd = matrix[(y % rows), (x % cols)];
                    r = ptr[RGB.R] + toAdd;
                    g = ptr[RGB.G] + toAdd;
                    b = ptr[RGB.B] + toAdd;

                    if (r > 255)
                        r = 255;
                    if (g > 255)
                        g = 255;
                    if (b > 255)
                        b = 255;
                    Color closestColor = GetClosestColor(r, g, b, out colorIndex);
                    if (is8bpp)
                    {
                        *dst = colorIndex;
                        dst++;
                    }
                    else
                    {
                        if (x % 2 == 0)
                        {
                            *dst |= (byte)(colorIndex << 4);
                        }
                        else
                        {
                            *dst |= (colorIndex);
                            dst++;
                        }
                    }
                }
            }
            sourceImage.UnlockBits(data);
            destImage.UnlockBits(destData);

            return destImage;
        }

        [NonSerialized]
        private Dictionary<Color, byte> cache = new Dictionary<Color, byte>();
        private Color GetClosestColor(int red, int green, int blue, out byte colorIndex)
        {
            Color color = Color.FromArgb(red, green, blue);

            if ((useCaching) && (cache.ContainsKey(color)))
            {
                colorIndex = cache[color];
            }
            else
            {
                colorIndex = 0;
                int minError = int.MaxValue;

                for (int i = 0, n = colorTable.Length; i < n; i++)
                {
                    int dr = red - colorTable[i].R;
                    int dg = green - colorTable[i].G;
                    int db = blue - colorTable[i].B;

                    int error = dr * dr + dg * dg + db * db;

                    if (error < minError)
                    {
                        minError = error;
                        colorIndex = (byte)i;
                    }
                }

                if (useCaching)
                {
                    cache.Add(color, colorIndex);
                }
            }

            return colorTable[colorIndex];
        }
    }
    public class RGB
    {
        /// <summary>
        /// Index of red component.
        /// </summary>
        public const short R = 2;

        /// <summary>
        /// Index of green component.
        /// </summary>
        public const short G = 1;

        /// <summary>
        /// Index of blue component.
        /// </summary>
        public const short B = 0;

        /// <summary>
        /// Index of alpha component for ARGB images.
        /// </summary>
        public const short A = 3;

        /// <summary>
        /// Red component.
        /// </summary>
        public byte Red;

        /// <summary>
        /// Green component.
        /// </summary>
        public byte Green;

        /// <summary>
        /// Blue component.
        /// </summary>
        public byte Blue;

        /// <summary>
        /// Alpha component.
        /// </summary>
        public byte Alpha;

        /// <summary>
        /// <see cref="System.Drawing.Color">Color</see> value of the class.
        /// </summary>
        public System.Drawing.Color Color
        {
            get { return Color.FromArgb(Alpha, Red, Green, Blue); }
            set
            {
                Red = value.R;
                Green = value.G;
                Blue = value.B;
                Alpha = value.A;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RGB"/> class.
        /// </summary>
        public RGB()
        {
            Red = 0;
            Green = 0;
            Blue = 0;
            Alpha = 255;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RGB"/> class.
        /// </summary>
        /// 
        /// <param name="red">Red component.</param>
        /// <param name="green">Green component.</param>
        /// <param name="blue">Blue component.</param>
        /// 
        public RGB(byte red, byte green, byte blue)
        {
            this.Red = red;
            this.Green = green;
            this.Blue = blue;
            this.Alpha = 255;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RGB"/> class.
        /// </summary>
        /// 
        /// <param name="red">Red component.</param>
        /// <param name="green">Green component.</param>
        /// <param name="blue">Blue component.</param>
        /// <param name="alpha">Alpha component.</param>
        /// 
        public RGB(byte red, byte green, byte blue, byte alpha)
        {
            this.Red = red;
            this.Green = green;
            this.Blue = blue;
            this.Alpha = alpha;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RGB"/> class.
        /// </summary>
        /// 
        /// <param name="color">Initialize from specified <see cref="System.Drawing.Color">color.</see></param>
        /// 
        public RGB(System.Drawing.Color color)
        {
            this.Red = color.R;
            this.Green = color.G;
            this.Blue = color.B;
            this.Alpha = color.A;
        }
    }
}
