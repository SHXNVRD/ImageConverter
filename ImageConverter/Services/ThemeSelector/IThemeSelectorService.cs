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
        void SetTheme(ElementTheme theme);
        Task SaveThemeAsync(ElementTheme theme);
        Task SetThemeOnLoadedAppAsync();
        Task<ElementTheme> LoadThemeAsync();
    }
}
