using Microsoft.UI.Xaml;
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
