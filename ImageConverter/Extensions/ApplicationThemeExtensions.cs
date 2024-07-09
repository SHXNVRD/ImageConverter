using Microsoft.UI.Xaml;

namespace ImageConverter.Extensions
{
    public static class ApplicationThemeExtensions
    {
        public static ElementTheme ToElementTheme(this ApplicationTheme theme) =>
            theme == ApplicationTheme.Dark ? ElementTheme.Dark : ElementTheme.Light;
    }
}
