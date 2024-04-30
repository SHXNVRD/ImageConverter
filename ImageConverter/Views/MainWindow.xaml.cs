using CommunityToolkit.WinUI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using WinUIEx;

namespace ImageConverter
{
    public sealed partial class MainWindow : WindowEx
    {
        public MainViewModel ViewModel { get; }
        public Frame Frame { get => ContentFrame; }

        public MainWindow()
        {
            this.InitializeComponent();
            ViewModel = new MainViewModel(new NavigationService(GetNavigationItems()));
            ((FrameworkElement)Content).DataContext = ViewModel;
            AppWindow.SetIcon(Path.Combine(AppContext.BaseDirectory, "Assets/WindowIcon.ico"));
            ExtendsContentIntoTitleBar = true;
            SetTitleBar(AppTitleBar);
            AppTitleBarTextBlock.Text = "AppTitle";
        }

        private void MainWindow_Activated(object sender, WindowActivatedEventArgs args)
        {
            if (args.WindowActivationState == WindowActivationState.Deactivated)
            {
                AppTitleBarTextBlock.Foreground =
                    (SolidColorBrush)App.Current.Resources["WindowCaptionForegroundDisabled"];
            }
            else
            {
                AppTitleBarTextBlock.Foreground =
                    (SolidColorBrush)App.Current.Resources["WindowCaptionForeground"];
            }
        }

        public IEnumerable<NavigationViewItem> GetNavigationItems()
        {
            var navigationItems =  NavView.MenuItems
                                   .OfType<NavigationViewItem>()
                                   .ToList();

            navigationItems.AddRange(NavView.FooterMenuItems.OfType<NavigationViewItem>());

            return navigationItems;
        }

        private double NavViewCompactModeThresholdWidth { get { return NavView.CompactModeThresholdWidth; } }
    }
}
