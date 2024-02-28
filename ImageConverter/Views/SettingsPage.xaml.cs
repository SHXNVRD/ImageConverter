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
            ViewModel = new SettingsViewModel(App.Current.Services.GetService<IThemeSelectorService>(), App.Current.Services.GetService<ISettingsService>());
            DataContext = ViewModel;
        }
    }
}
