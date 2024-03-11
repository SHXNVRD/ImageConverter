using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ImageConverter.Services.Settings;
using ImageConverter.Services.ThemeSelector;
using Microsoft.UI.Xaml;
using System;
using System.Threading.Tasks;

namespace ImageConverter.ViewModels
{
    public partial class SettingsViewModel : ObservableObject
    {
        private readonly ISettingsService _settingsService;
        private readonly IThemeSelectorService _themeSelectorService;

        [ObservableProperty]
        private ElementTheme _themeOnLoadSettingsPage;

        public SettingsViewModel(IThemeSelectorService themeSelectorService, ISettingsService settingsService)
        {
            _themeSelectorService = themeSelectorService;
            _settingsService = settingsService;

            _themeOnLoadSettingsPage = _themeSelectorService.CurrentTheme;
        }

        [RelayCommand]
        public async Task SwitchThemeAsync(ElementTheme theme)
        {
            try
            {
                if (_themeSelectorService.CurrentTheme != theme)
                {
                    _themeSelectorService.SetTheme(theme);
                    await _themeSelectorService.SaveThemeAsync(theme);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
   
        }
    }
}
