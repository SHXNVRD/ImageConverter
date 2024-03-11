using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.CompilerServices;
using Windows.Graphics.Imaging;
using System.Drawing.Imaging;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.InteropServices;

namespace ImageConverter.Extensions
{
    public static class SoftwareBitmapExtensions
    {
        public static Bitmap ConvertToBitmap(this SoftwareBitmap softwareBitmap)
        {
            var softwareBitmapBgra8 = SoftwareBitmap.Convert(softwareBitmap, BitmapPixelFormat.Bgra8);

            byte[] pixels = new byte[softwareBitmapBgra8.PixelWidth * softwareBitmapBgra8.PixelHeight * 4];
            softwareBitmapBgra8.CopyToBuffer(pixels.AsBuffer());

            Bitmap bitmap = new Bitmap(softwareBitmapBgra8.PixelWidth,
                                       softwareBitmapBgra8.PixelHeight,
                                       softwareBitmapBgra8.PixelWidth * 4,
                                       PixelFormat.Format32bppArgb,
                                       Marshal.UnsafeAddrOfPinnedArrayElement(pixels, 0));
            return bitmap;
        }
    }
}
