using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Graphics.Imaging;
using WinRT;
using System.Runtime.InteropServices.WindowsRuntime;

namespace ImageConverter.Models
{
    [ComImport]
    [Guid("5B0D3235-4DBA-4D44-865E-8F1D0E4FD04D")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    unsafe interface IMemoryBufferByteAccess
    {
        void GetBuffer(out byte* buffer, out uint capacity);
    }

    public static class AsciiConverter
    {
        private static readonly char[] _asciiTable = { '.', ',', ';', '+', '*', '?', '%', 'S', '#', '@' };
        private static readonly char[] _asciiTableNegative = { '@', '#', 'S', '%', '?', '*', '+', ';', ',', '.' };

        public static char[][] Convert(SoftwareBitmap softwareBitmap)
        {
            if (softwareBitmap == null)
                throw new ArgumentNullException(nameof(softwareBitmap), "softwareBitmap cannot be null");
            return Convert(softwareBitmap, _asciiTable);
        }

        public static char[][] ConvertNegative(SoftwareBitmap softwareBitmap)
        {
            if (softwareBitmap == null)
                throw new ArgumentNullException(nameof(softwareBitmap), "softwareBitmap cannot be null");
            return Convert(softwareBitmap, _asciiTableNegative);
        }

        public static async Task<char[][]> ConvertAsync(SoftwareBitmap softwareBitmap)
        {
            if (softwareBitmap == null)
                throw new ArgumentNullException(nameof(softwareBitmap), "softwareBitmap cannot be null");
            return await Task.Run(() => Convert(softwareBitmap, _asciiTable));
        }

        public static async Task<char[][]> ConvertNegativeAsync(SoftwareBitmap softwareBitmap)
        {
            if (softwareBitmap == null)
                throw new ArgumentNullException(nameof(softwareBitmap), "softwareBitmap cannot be null");
            return await Task.Run(() => Convert(softwareBitmap, _asciiTableNegative));
        }

        private static char[][] Convert(SoftwareBitmap softwareBitmap, char[] asciiTable)
        {
            if (softwareBitmap == null)
                throw new ArgumentNullException(nameof(softwareBitmap), "softwareBitmap cannot be null");
            if (asciiTable == null)
                throw new ArgumentNullException(nameof(asciiTable), "asciiTable cannot be null");
            if (asciiTable.Length == 0)
                throw new ArgumentException("The asciiTable cannot be of zero length", nameof(asciiTable));

            char[][] result = new char[softwareBitmap.PixelHeight][];

            using (var buffer = softwareBitmap.LockBuffer(BitmapBufferAccessMode.Read))
            using (var reference = buffer.CreateReference())
            {
                unsafe
                {
                    reference.As<IMemoryBufferByteAccess>().GetBuffer(out byte* pixels, out uint capacity);

                    for (int y = 0; y < softwareBitmap.PixelHeight; y++)
                    {
                        result[y] = new char[softwareBitmap.PixelWidth];

                        for (int x = 0; x < softwareBitmap.PixelWidth; x++)
                        {
                            int index = y * softwareBitmap.PixelWidth + x;
                            byte pixelValue = pixels[index];
                            int mapIndex = (int)Map(pixelValue, 0, 255, 0, asciiTable.Length - 1);
                            result[y][x] = asciiTable[mapIndex];
                        }
                    }
                }
            }
            return result;
        }

        public static float Map(float valueMap, float start1, float stop1, float start2, float stop2)
        {
            return (valueMap - start1) / (stop1 - start1) * (stop2 - start2) + start2;
        }

        public static string StringifyAscii(char[][] asciiArray)
        {
            if (asciiArray == null)
                throw new ArgumentNullException(nameof(asciiArray), "asciiArray cannot be null");
            if (asciiArray.Length == 0)
                throw new ArgumentException("The asciiArray cannot be of zero length", nameof(asciiArray));

            StringBuilder builder = new StringBuilder();

            foreach (var row in asciiArray)
            {
                string cleanRow = new(row.Where(c => !char.IsControl(c)).ToArray());
                builder.AppendLine(cleanRow);
            }

            return builder.ToString();
        }
    }
}
