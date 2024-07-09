using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml;
using Microsoft.UI;
using Windows.UI;

namespace ImageConverter.Extensions
{
    public static class TextBlockExtensions
    {
        public static void UpdateForeground(this TextBlock appTitle, ElementTheme theme, bool activated = false)
        {
            if (activated)
            {
                appTitle.Foreground = theme switch
                {
                    ElementTheme.Dark => new SolidColorBrush(Colors.White),
                    ElementTheme.Light => new SolidColorBrush(Colors.Black),
                    _ => new SolidColorBrush(Colors.Transparent)
                };
            }
            else
            {
                appTitle.Foreground = theme switch
                {
                    ElementTheme.Dark => appTitle.Foreground = (SolidColorBrush)App.Current.Resources["WindowCaptionForegroundDisabled"],
                    ElementTheme.Light => new SolidColorBrush(Color.FromArgb(255, 105, 105, 105)),
                    _ => new SolidColorBrush(Colors.Transparent)
                };
            }
        }
    }
}
