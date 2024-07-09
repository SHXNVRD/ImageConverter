using Microsoft.UI.Dispatching;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            InitializeComponent();
            ViewModel = viewModel;
            Activated += MainWindow_Activated;
            ViewModel.NavigationService.Initialize(GetNavigationItems());
            ((FrameworkElement)Content).DataContext = ViewModel;
            AppWindow.SetPresenter(AppWindowPresenterKind.Overlapped);
            ConfigureTitleBar();
        }

        private void ConfigureTitleBar()
        {
            ExtendsContentIntoTitleBar = true;

            if (RuntimeHelper.IsMSIX)
                AppTitle.Text = AppInfo.Current.DisplayInfo.DisplayName;
            else
                AppTitle.Text = Assembly.GetExecutingAssembly().GetName().Name;

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

        private IEnumerable<NavigationViewItem> GetNavigationItems()
        {
            var navigationItems =  NavView.MenuItems
                                   .OfType<NavigationViewItem>()
                                   .ToList();

            navigationItems.AddRange(NavView.FooterMenuItems.OfType<NavigationViewItem>());

            return navigationItems;
        }
    }
}
