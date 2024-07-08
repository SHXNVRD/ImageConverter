using CommunityToolkit.Mvvm.DependencyInjection;
using ImageConverter.Services.Files;
using ImageConverter.Services.Settings;
using ImageConverter.Services.ThemeSelector;
using ImageConverter.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using System.Diagnostics;

namespace ImageConverter.Views
{
    public sealed partial class SettingsPage : Page
    {
        public SettingsViewModel ViewModel { get; }

        public SettingsPage() : this(App.GetService<SettingsViewModel>())
        { 
            InitializeComponent();
        }

        private SettingsPage(SettingsViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = ViewModel;
        }

        private async void TextBox_LosingFocus(UIElement sender, LosingFocusEventArgs args)
        {
            await ViewModel.SetUserSymbolsAsync();
        }
    }
}
