using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System.Profile;

namespace ImageConverter.Models
{
    public class AsciiConverterSettings
    {
        internal static readonly char[] DefaultAsciiTable = { '.', ',', ';', '+', '*', '?', '%', 'S', '#', '@' };
        internal static readonly char[] DefaultAsciiTableNegative = { '@', '#', 'S', '%', '?', '*', '+', ';', ',', '.' };

        internal char[] _asciiTable;
        internal char[] _asciiTableNegative;

        public char[] AsciiTable
        {
            get => _asciiTable ?? DefaultAsciiTable;
            set => _asciiTable = value;
        }

        public char[] AsciiTableNegative
        {
            get => _asciiTableNegative ?? DefaultAsciiTableNegative;
            set => _asciiTableNegative = value;
        }

        public AsciiConverterSettings(AsciiConverterSettings original)
        {
            AsciiTable = original.AsciiTable;
            AsciiTableNegative = original.AsciiTableNegative;
        }

        public AsciiConverterSettings()
        { }
    }
}
