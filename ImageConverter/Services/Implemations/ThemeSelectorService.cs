using ImageConverter.Helpers;
using ImageConverter.Services.Settings;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WinUICommunity;

namespace ImageConverter.Services.ThemeSelector
{
    public class ThemeSelectorService : IThemeSelectorService
    {
        public ElementTheme CurrentTheme { get; set; } = ElementTheme.Default;
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
                SetCurrentTheme();
                _isInitialized = true;
            }
        }

        public async Task SetTheme(ElementTheme theme)
        {
            CurrentTheme = theme;

            SetCurrentTheme();
            await SaveThemeAsync(CurrentTheme);
        }

        public void SetCurrentTheme()
        {
            if (App.Current.MainWindow.Content is FrameworkElement frameworkElement)
            {
                frameworkElement.RequestedTheme = CurrentTheme;
                App.Current.MainWindow.DispatcherQueue.TryEnqueue(() =>
                {
                    TitleBarUpdater.UpdateTitleBar(App.Current.AppTitle, CurrentTheme, true);
                });
            }
        }

        private async Task SaveThemeAsync(ElementTheme theme)
        {
            await _settingsService.SaveSettingAsync(_settingsKey, theme);
        }

        private async Task<ElementTheme> LoadThemeAsync()
        {
            var themeName = await _settingsService.ReadSettingAsync<string>(_settingsKey);

            if (Enum.TryParse(themeName, out ElementTheme theme))
            {
                return theme;
            }

            return ElementTheme.Default;
        }
    }
}