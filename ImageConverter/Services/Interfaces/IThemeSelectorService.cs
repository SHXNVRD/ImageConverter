using Microsoft.UI.Xaml;
using Microsoft.Xaml.Interactions.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageConverter.Services.ThemeSelector
{
    public interface IThemeSelectorService
    {
        ElementTheme CurrentTheme { get; }
        Task SetTheme(ElementTheme theme);
        void SetCurrentTheme();
        Task InitializeAsync();
    }
}
