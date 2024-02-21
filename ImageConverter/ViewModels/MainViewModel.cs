using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using ImageConverter.Views;
using ImageConverter.Services;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;

namespace ImageConverter.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool _backButtonEnabled;
        [ObservableProperty]
        private string _navigationHeader;
        [ObservableProperty]
        private NavigationViewItem _selectedNavigationItem;

        private NavigationService _navigationService;

        public MainViewModel(NavigationService navigation)
        {
            _navigationService = navigation;
        }

        [RelayCommand]
        public void OnLoaded() => _navigationService.NavigateTo(typeof(HomePage));

        [RelayCommand]
        public void OnItemInvoked(NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked == true)
            {
                _navigationService.NavigateTo(typeof(SettingsPage));
            }
            else if (args.InvokedItemContainer != null)
            {
                Type navPageType = Type.GetType(args.InvokedItemContainer.Tag.ToString());
                _navigationService.NavigateTo(navPageType);
            }
        }

        [RelayCommand]
        public void OnNavigated(NavigationEventArgs args)
        {
            BackButtonEnabled = _navigationService.CanGoBack();
            SelectedNavigationItem = _navigationService.GetCurrentNavigationItem();
            NavigationHeader = SelectedNavigationItem.Content.ToString();
        }

        [RelayCommand]
        public void OnBackRequested() => _navigationService.GoBack();

        [RelayCommand]
        public void OnNavigationFailed(NavigationFailedEventArgs args) => _navigationService.OnNavigationFailed(args);
    }
}
