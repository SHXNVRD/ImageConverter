using ImageConverter.Services.Settings;
using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ImageConverter.Services.ThemeSelector
{
    public class ThemeSelectorService : IThemeSelectorService
    {
        public ElementTheme CurrentTheme { get; private set; } = ElementTheme.Default;
        private const string _settingsKey = "AppRequestedTheme";

        private readonly ISettingsService _settingsService;

        private bool _isInitialized;

        public ThemeSelectorService(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        public async Task InitializeAsync()
        {
            if (!_isInitialized)
            {
                CurrentTheme = await LoadThemeAsync();
                _isInitialized = true;
            }
        }

        public void SetTheme(ElementTheme theme)
        {
            if (App.Window.Content is FrameworkElement frameworkElement)
            {
                CurrentTheme = theme;
                frameworkElement.RequestedTheme = theme;
            }
        }

        public async Task SaveThemeAsync(ElementTheme theme)
        {
            await _settingsService.SaveSettingAsync(_settingsKey, theme);
        }

        public async Task<ElementTheme> LoadThemeAsync()
        {
            var themeName = await _settingsService.ReadSettingAsync<string>(_settingsKey);

            if (Enum.TryParse(themeName, out ElementTheme theme))
            {
                CurrentTheme = theme;
                return theme;
            }

            return ElementTheme.Default;
        }

        public async Task SetThemeOnLoadedAppAsync()
        {
            ElementTheme loadedTheme = await LoadThemeAsync();

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
