using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ImageConverter.Services.CustomSymbolsService;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace ImageConverter.ViewModels
{
    public partial class SettingsViewModel : ObservableObject
    {
        private readonly IThemeSelectorService _themeSelectorService;
        private readonly UserSymbolsService _userSymbolsService;

        [ObservableProperty]
        private ElementTheme _themeOnLoadSettingsPage;
        [ObservableProperty]
        private string _userSymbols;
        [ObservableProperty]
        private bool _useUserSymbols;

        public SettingsViewModel(IThemeSelectorService themeSelectorService, UserSymbolsService userSymbolsService)
        {
            _themeSelectorService = themeSelectorService;
            _userSymbolsService = userSymbolsService;
            _themeOnLoadSettingsPage = _themeSelectorService.CurrentTheme;
            UserSymbols = _userSymbolsService.UserSymbols;
            UseUserSymbols = _userSymbolsService.UseUserSymbols;
        }

        [RelayCommand]
        public async Task SwitchThemeAsync(ElementTheme theme)
        {
            if (_themeSelectorService.CurrentTheme != theme)
            {
                await _themeSelectorService.SetTheme(theme);
            }
        }

        [RelayCommand]
        public async Task SetUserSymbolsAsync()
        {
            if (!String.IsNullOrWhiteSpace(UserSymbols))
            {
                var cleanSymbols = new string(UserSymbols.Where(c => !Char.IsWhiteSpace(c)).ToArray());
                
                if (_userSymbolsService.UserSymbols != cleanSymbols)
                {
                    await _userSymbolsService.SetUserSymbolsAsync(cleanSymbols);
                    UserSymbols = _userSymbolsService.UserSymbols;
                }
            }
        }

        [RelayCommand]
        public async Task SetUseUserSymbolsAsync()
        {
            await _userSymbolsService.SetUseUserSymbolsAsync(!UseUserSymbols);
        }
    }
}
