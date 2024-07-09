using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;

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
