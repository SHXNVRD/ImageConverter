using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageConverter.Services.ImageToASCII
{
    public interface IImageToASCIIService
    {
        char[][] Convert(Bitmap bitmap);
        char[][] ConvertNegative(Bitmap bitmap);
        char[][] Convert(Bitmap bitmap, char[] asciiTable);
        float Map(float valueMap, float start1, float stop1, float start2, float stop2);
        string StringifyASCIIArray(char[][] ASCIIArray);
        public Bitmap ResizeBitMap(Bitmap bitmap, uint maxWidth, double widthOffset);
    }
}
