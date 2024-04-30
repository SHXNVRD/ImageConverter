using ImageConverter.Services.Files;
using ImageConverter.Services.Settings;
using ImageConverter.Services.ThemeSelector;
using ImageConverter.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml.Controls;

namespace ImageConverter.Views
{
    public sealed partial class SettingsPage : Page
    {
        public SettingsViewModel ViewModel { get; private set; }

        public SettingsPage()
        {
            this.InitializeComponent();
            ViewModel = Ioc.Default.GetService<SettingsViewModel>();
            DataContext = ViewModel;
        }

        private async void TextBox_LosingFocus(Microsoft.UI.Xaml.UIElement sender, Microsoft.UI.Xaml.Input.LosingFocusEventArgs args)
        {
            await ViewModel.SetUserSymbolsAsync();
        }
    }
}
