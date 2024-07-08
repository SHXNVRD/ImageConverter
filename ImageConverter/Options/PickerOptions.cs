using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;

namespace ImageConverter.Options
{
    public class PickerOptions
    {
        public IList<string> OpenFileTypes { get; set; }
        public Dictionary<string, IList<string>> SaveFileTypes { get; set; }
        public string SavingFileName { get; set; }
    }
}
