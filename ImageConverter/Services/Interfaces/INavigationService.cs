﻿using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageConverter.Services.Interfaces
{
    public interface INavigationService
    {
        public bool CanGoBack { get; }
        public Frame Frame { get; set; }
        NavigationViewItem GetCurrentNavigationItem();
        void Initialize(IEnumerable<NavigationViewItem> navigationItems);
        void OnNavigationFailed(NavigationFailedEventArgs args);
        bool GoBack();
        void NavigateTo(Type pageType);
    }
}