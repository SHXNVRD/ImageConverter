using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ImageConverter.Services.Settings;
using ImageConverter.Services.ThemeSelector;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace ImageConverter.ViewModels
{
    public partial class SettingsViewModel : ObservableObject
    {
        private readonly ISettingsService _settingsService;
        private IThemeSelectorService _themeSelectorService;

        public SettingsViewModel(IThemeSelectorService themeSelectorService, ISettingsService settingsService)
        {
            _themeSelectorService = themeSelectorService;
            _settingsService = settingsService;
        }

        [RelayCommand]
        public void SetTheme(string themeName)
        {
            if (Enum.TryParse(themeName, out ElementTheme theme))
            {
                _themeSelectorService.SetTheme(theme);
                _settingsService.SaveSetting<ElementTheme>("AppRequestedTheme", theme);
            }
        }

        [RelayCommand]
        public void OnExpanded()
        {
            
        }
    }
}
