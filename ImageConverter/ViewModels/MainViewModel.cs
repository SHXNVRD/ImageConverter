using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using ImageConverter.Views;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using ImageConverter.Services.Interfaces;

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

        public INavigationService NavigationService { get; }

        public MainViewModel(INavigationService navigation)
        {
            NavigationService = navigation;
        }

        [RelayCommand]
        public void OnLoaded() => NavigationService.NavigateTo(typeof(ConvertToASCIIPage));

        [RelayCommand]
        public void OnItemInvoked(NavigationViewItemInvokedEventArgs args)
        {
            Type navPageType = Type.GetType(args.InvokedItemContainer.Tag.ToString());
            NavigationService.NavigateTo(navPageType);
        }

        [RelayCommand]
        public void OnNavigated(NavigationEventArgs args)
        {
            BackButtonEnabled = NavigationService.CanGoBack;
            SelectedNavigationItem = NavigationService.GetCurrentNavigationItem();
        }

        [RelayCommand]
        public void OnBackRequested() => NavigationService.GoBack();

        [RelayCommand]
        public void OnNavigationFailed(NavigationFailedEventArgs args) => NavigationService.OnNavigationFailed(args);
    }
}
