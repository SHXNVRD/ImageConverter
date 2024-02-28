using ImageConverter.Services.Settings;
using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageConverter.Services.ThemeSelector
{
    public class ThemeSelectorService : IThemeSelectorService
    {
        public ElementTheme CurrentTheme { get; private set; } = ElementTheme.Default;
        private const string _settingsKey = "AppRequestedTheme";

        private readonly ISettingsService _settingsService;

        public ThemeSelectorService(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        public ElementTheme GetCurrentTheme()
        {
            if (App.Window.Content is FrameworkElement frameworkElement)
            {
                return frameworkElement.ActualTheme;
            }
            return ElementTheme.Default;
        }

        public void SetTheme(ElementTheme theme)
        {
            if (App.Window.Content is FrameworkElement frameworkElement)
            {
                CurrentTheme = theme;
                frameworkElement.RequestedTheme = theme;
            }
        }

        public ElementTheme LoadTheme()
        {
            var themeName = _settingsService.ReadSetting<string>(_settingsKey);

            if (Enum.TryParse(themeName, out ElementTheme theme))
            {
                CurrentTheme = theme;
                return theme;
            }

            return ElementTheme.Default;
        }

        public void SetThemeOnLoadedApp()
        {
            ElementTheme loadedTheme = LoadTheme();

            switch (loadedTheme)
            {
                case ElementTheme.Light:
                    App.Current.RequestedTheme = ApplicationTheme.Light;
                    break;
                case ElementTheme.Dark:
                    App.Current.RequestedTheme = ApplicationTheme.Dark;
                    break;
                default:
                    break;
            }
        }
    }
}
