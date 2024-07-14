using System.Text;
using Windows.Graphics.Imaging;
using System.Runtime.InteropServices.WindowsRuntime;
using WinRT;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace ImageConverter.Converter
{
    public class AsciiConverter
    {
        private char[] _asciiTable;
        private char[] _asciiTableNegative;

        public AsciiConverter()
        {
            _asciiTable = AsciiConverterSettings.DefaultAsciiTable;
            _asciiTableNegative = AsciiConverterSettings.DefaultAsciiTableNegative;
        }

        public static AsciiConverter Create() => new AsciiConverter();

        public static AsciiConverter Create(AsciiConverterSettings settings)
        {
            AsciiConverter converter = Create();

            if (settings != null)
            {
                ApplyAsciiConverterSettings(converter, settings);
            }

            return converter;
        }

        private static void ApplyAsciiConverterSettings(AsciiConverter converter, AsciiConverterSettings settings)
        {
            if (settings._asciiTable != null)
                converter._asciiTable = settings.AsciiTable;
            if (settings._asciiTableNegative != null)
                converter._asciiTableNegative = settings.AsciiTableNegative;
        }

        public async Task<char[][]> ConvertAsync(SoftwareBitmap softwareBitmap)
        {
            if (softwareBitmap == null)
                throw new ArgumentNullException(nameof(softwareBitmap), "softwareBitmap cannot be null");
            return await Task.Run(() => Convert(softwareBitmap, _asciiTable));
        }

        public async Task<char[][]> ConvertNegativeAsync(SoftwareBitmap softwareBitmap)
        {
            if (softwareBitmap == null)
                throw new ArgumentNullException(nameof(softwareBitmap), "softwareBitmap cannot be null");
            return await Task.Run(() => Convert(softwareBitmap, _asciiTableNegative));
        }

        private char[][] Convert(SoftwareBitmap softwareBitmap, char[] asciiTable)
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

        public static double Map(float valueMap, float start1, float stop1, float start2, float stop2)
        {
            var mappedValue = (valueMap - start1) / (stop1 - start1) * (stop2 - start2) + start2;
            return Math.Round(mappedValue, MidpointRounding.AwayFromZero);
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