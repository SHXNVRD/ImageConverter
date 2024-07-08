using Microsoft.UI.Dispatching;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using Windows.ApplicationModel;
using WinUIEx;

namespace ImageConverter
{
    public sealed partial class MainWindow : WindowEx
    {
        public MainViewModel ViewModel { get; }
        public Frame Frame { get => ContentFrame; }

        public MainWindow(MainViewModel viewModel)
        {
            this.InitializeComponent();
            ViewModel = viewModel;
            Activated += MainWindow_Activated;
            ViewModel.NavigationService.Initialize(GetNavigationItems());
            ((FrameworkElement)Content).DataContext = ViewModel;
            ConfigureTitleBar();
        }

        public void ConfigureTitleBar()
        {
            ExtendsContentIntoTitleBar = true;
            AppTitle.Text = AppInfo.Current.DisplayInfo.DisplayName;
            SetTitleBar(AppTitleBar);
        }

        private void MainWindow_Activated(object sender, WindowActivatedEventArgs args)
        {
            var appTheme = App.GetService<IThemeSelectorService>().CurrentTheme;

            var theme = appTheme == ElementTheme.Default ?
                App.Current.RequestedTheme.ToElementTheme() : appTheme;

            if (args.WindowActivationState == WindowActivationState.Deactivated)
            {
                DispatcherQueue.TryEnqueue(() =>
                    AppTitle.UpdateForeground(theme));
            }
            else
            {
                DispatcherQueue.TryEnqueue(() =>
                    AppTitle.UpdateForeground(theme, true));
            }

            App.Current.AppTitle = AppTitle;
        }

        public IEnumerable<NavigationViewItem> GetNavigationItems()
        {
            var navigationItems =  NavView.MenuItems
                                   .OfType<NavigationViewItem>()
                                   .ToList();

            navigationItems.AddRange(NavView.FooterMenuItems.OfType<NavigationViewItem>());

            return navigationItems;
        }
    }
}
