using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ImageConverter.Services.Implemations
{
    public class NavigationService : INavigationService
    {
        private Frame _frame;
        private IEnumerable<NavigationViewItem> _navigationItems;
        private bool _initialized;

        public Type SourcePageType { get { return Frame.SourcePageType; } }

        public Frame Frame
        {
            get
            {
                if (_frame == null)
                {
                    _frame = App.Current.MainWindow.Frame;
                }

                return _frame;
            }
            set { _frame = value; }
        }

        public void NavigateTo(Type pageType)
        {
            if (Frame.CurrentSourcePageType != pageType && pageType != null)
            {
                Frame.Navigate(pageType, null, new SuppressNavigationTransitionInfo());
            }
        }

        public bool CanGoBack => Frame != null && Frame.CanGoBack;

        public bool GoBack()
        {
            if (CanGoBack)
            {
                Frame.GoBack();
                return true;
            }
            return false;
        }

        public void OnNavigationFailed(NavigationFailedEventArgs args)
        {
            throw new Exception("Failed to load Page " + args.SourcePageType.FullName);
        }

        public NavigationViewItem GetCurrentNavigationItem() =>
            _navigationItems.First(i => i.Tag.Equals(Frame.SourcePageType.FullName.ToString()));

        public void Initialize(IEnumerable<NavigationViewItem> navigationItems)
        {
            if (!_initialized)
            {
                _navigationItems = navigationItems;
                _initialized = true;
            }
        }
    }
}
