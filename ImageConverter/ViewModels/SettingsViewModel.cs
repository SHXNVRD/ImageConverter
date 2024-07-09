using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ImageConverter.Services.CustomSymbolsService;
using Microsoft.UI.Xaml;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ImageConverter.ViewModels
{
    public partial class SettingsViewModel : ObservableObject
    {
        private readonly IThemeSelectorService _themeSelectorService;
        private readonly IUserSymbolsService _userSymbolsService;

        [ObservableProperty]
        private ElementTheme _currentTheme;
        [ObservableProperty]
        private string _userSymbols;
        [ObservableProperty]
        private bool _userSymbolsIsOn;

        public SettingsViewModel(IThemeSelectorService themeSelectorService, IUserSymbolsService userSymbolsService)
        {
            _themeSelectorService = themeSelectorService;
            _userSymbolsService = userSymbolsService;
            CurrentTheme = _themeSelectorService.CurrentTheme;
            UserSymbols = _userSymbolsService.UserSymbols;
            UserSymbolsIsOn = _userSymbolsService.UseUserSymbols;
        }

        [RelayCommand]
        public async Task SwitchThemeAsync(ElementTheme theme)
        {
            if (_themeSelectorService.CurrentTheme != theme)
            {
                await _themeSelectorService.SetTheme(theme);
                CurrentTheme = _themeSelectorService.CurrentTheme;
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
        public async Task SetUseUserSymbolsAsync() =>
            await _userSymbolsService.SetUseUserSymbolsAsync(UserSymbolsIsOn);
    }
}
