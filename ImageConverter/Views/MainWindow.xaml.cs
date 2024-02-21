using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using ImageConverter.ViewModels;
using Microsoft.Web.WebView2.Core;
using ImageConverter.Services;

namespace ImageConverter
{
    public sealed partial class MainWindow : Window
    {
        public MainViewModel ViewModel { get; }

        public MainWindow()
        {
            this.InitializeComponent();
            ViewModel = new MainViewModel(new NavigationService(ContentFrame, GetNavigationItems()));
            RootGrid.DataContext = ViewModel;
        }

        private IEnumerable<NavigationViewItem> GetNavigationItems()
        {
            return NavView.MenuItems.OfType<NavigationViewItem>();
        }

        private double NavViewCompactModeThresholdWidth { get { return NavView.CompactModeThresholdWidth; } }
    }
}
