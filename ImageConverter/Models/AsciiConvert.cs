using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Graphics.Imaging;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.InteropServices;
using WinRT;
using Windows.Devices.Sensors;

namespace ImageConverter.Models
{
    public static class AsciiConvert
    {
        public static async Task<char[][]> ConvertAsync(SoftwareBitmap bitmap)
        {
            AsciiConverter converter = AsciiConverter.Create();
            return await converter.ConvertAsync(bitmap);
        }

        public static async Task<char[][]> ConvertNegativeAsync(SoftwareBitmap bitmap)
        {
            AsciiConverter converter = AsciiConverter.Create();
            return await converter.ConvertNegativeAsync(bitmap);
        }

        public static async Task<char[][]> ConvertAsync(SoftwareBitmap bitmap, AsciiConverterSettings settings)
        {
            AsciiConverter converter = AsciiConverter.Create(settings);
            return await converter.ConvertAsync(bitmap);
        }

        public static async Task<char[][]> ConvertNegativeAsync(SoftwareBitmap bitmap, AsciiConverterSettings settings)
        {
            AsciiConverter converter = AsciiConverter.Create(settings);
            return await converter.ConvertNegativeAsync(bitmap);
        }

        public static string StringifyAscii(char[][] asciiArray)
        {
            return AsciiConverter.StringifyAscii(asciiArray);
        }

        public static string StringifyAscii(char[][] asciiArray, AsciiConverterSettings settings)
        {
            return AsciiConverter.StringifyAscii(asciiArray);
        }
    }
}
