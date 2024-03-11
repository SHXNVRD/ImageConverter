using CommunityToolkit.WinUI.UI.Behaviors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageConverter.Services.ImageToASCII
{
    public class ImageToASCIIService : IImageToASCIIService
    {
        private readonly char[] _asciiTable = { '.', ',', ';', '+', '*', '?', '%', 'S', '#', '@' };
        private readonly char[] _asciiTableNegative = { '@', '#', 'S', '%', '?', '*', '+', ';', ',', '.' };

        public ImageToASCIIService()
        {

        }

        public char[][] Convert(Bitmap bitmap)
        {
            return Convert(bitmap, _asciiTable);
        }

        public char[][] ConvertNegative(Bitmap bitmap)
        {
            return Convert(bitmap, _asciiTableNegative);
        }

        public char[][] Convert(Bitmap bitmap, char[] asciiTable)
        {
            char[][] result = new char[bitmap.Height][];

            for (int y = 0; y < bitmap.Height; y++)
            {
                result[y] = new char[bitmap.Width];

                for (int x = 0; x < bitmap.Width; x++)
                {
                    int mapIndex = (int)Map(bitmap.GetPixel(x, y).R, 0, 255, 0, asciiTable.Length - 1);
                    result[y][x] = asciiTable[mapIndex];
                }
            }

            return result;
        }

        public float Map(float valueMap, float start1, float stop1, float start2, float stop2)
        {
            return (valueMap - start1) / (stop1 - start1) * (stop2 - start2) + start2;
        }

        public string StringifyASCIIArray(char[][] ASCIIArray)
        {
            StringBuilder builder = new StringBuilder();

            foreach (var row in ASCIIArray)
            {
                string cleanRow = new string(row.Where(c => !char.IsControl(c)).ToArray());
                builder.AppendLine(cleanRow);
            }

            return builder.ToString();
        }

        public Bitmap ResizeBitMap(Bitmap bitmap, uint maxWidth, double widthOffset)
        {
            if (bitmap.Height <= 0)
                throw new Exception("Деление на ноль нельзя");

            var newHeight = bitmap.Height / widthOffset * maxWidth / bitmap.Height;

            if (bitmap.Width > maxWidth || bitmap.Height > newHeight)
            {
                Bitmap resizedBitmap = new Bitmap(bitmap, new Size((int)maxWidth, (int)newHeight));
                return resizedBitmap;
            }

            return bitmap;
        }
    }
}
