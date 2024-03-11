using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ImageConverter.Services.Navigation
{
    public class NavigationService : INavigationService
    {
        private Frame _mainFrame;
        private IEnumerable<NavigationViewItem> _navigationItems;
        public Type SourcePageType { get { return _mainFrame.SourcePageType; } }

        public NavigationService(Frame mainFrame, IEnumerable<NavigationViewItem> navigationItems)
        {
            _mainFrame = mainFrame;
            _navigationItems = navigationItems;
        }

        public void NavigateTo(Type pageType)
        {
            if (_mainFrame.CurrentSourcePageType != pageType && pageType != null)
            {
                _mainFrame.Navigate(pageType, null, new SuppressNavigationTransitionInfo());
            }
        }

        public bool CanGoBack() => _mainFrame.CanGoBack;

        public bool GoBack()
        {
            if (CanGoBack())
            {
                _mainFrame.GoBack();
                return true;
            }
            return false;
        }

        public void OnNavigationFailed(NavigationFailedEventArgs args)
        {
            throw new Exception("Failed to load Page " + args.SourcePageType.FullName);
        }

        public NavigationViewItem GetCurrentNavigationItem() =>
            _navigationItems.First(i => i.Tag.Equals(_mainFrame.SourcePageType.FullName.ToString()));
    }
}
