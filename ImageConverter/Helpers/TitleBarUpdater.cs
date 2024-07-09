using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Runtime.InteropServices;
using Windows.UI;
using Windows.UI.ViewManagement;

namespace ImageConverter.Helpers
{
    public static class TitleBarUpdater
    {
        private const int _wainactive = 0x00;
        private const int _waactice = 0x01;
        private const int _wmactivate = 0x0006;

        [DllImport("user32.dll")]
        private static extern IntPtr GetActiveWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, IntPtr lParam);

        public static void UpdateTitleBar(TextBlock appTitle, ElementTheme theme, bool activated = false)
        {
            if (App.Current.MainWindow.ExtendsContentIntoTitleBar)
            {
                if (theme == ElementTheme.Default)
                {
                    var uiSettings = new UISettings();
                    var background = uiSettings.GetColorValue(UIColorType.Background);

                    theme = background == Colors.White ? ElementTheme.Light : ElementTheme.Dark;
                }

                if (theme == ElementTheme.Default)
                {
                    theme = Application.Current.RequestedTheme == ApplicationTheme.Light ? ElementTheme.Light : ElementTheme.Dark;
                }

                App.Current.MainWindow.AppWindow.TitleBar.ButtonForegroundColor = theme switch
                {
                    ElementTheme.Dark => Colors.White,
                    ElementTheme.Light => Colors.Black,
                    _ => Colors.Transparent
                };

                App.Current.MainWindow.AppWindow.TitleBar.ButtonHoverForegroundColor = theme switch
                {
                    ElementTheme.Dark => Colors.White,
                    ElementTheme.Light => Colors.Black,
                    _ => Colors.Transparent
                };

                App.Current.MainWindow.AppWindow.TitleBar.ButtonHoverBackgroundColor = theme switch
                {
                    ElementTheme.Dark => Color.FromArgb(0x33, 0xFF, 0xFF, 0xFF),
                    ElementTheme.Light => Color.FromArgb(0x33, 0x00, 0x00, 0x00),
                    _ => Colors.Transparent
                };

                App.Current.MainWindow.AppWindow.TitleBar.ButtonPressedBackgroundColor = theme switch
                {
                    ElementTheme.Dark => Color.FromArgb(0x66, 0xFF, 0xFF, 0xFF),
                    ElementTheme.Light => Color.FromArgb(0x66, 0x00, 0x00, 0x00),
                    _ => Colors.Transparent
                };

                App.Current.MainWindow.AppWindow.TitleBar.BackgroundColor = Colors.Transparent;

                var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(App.Current.MainWindow);
                if (hwnd == GetActiveWindow())
                {
                    SendMessage(hwnd, _wmactivate, _wainactive, IntPtr.Zero);
                    SendMessage(hwnd, _wmactivate, _waactice, IntPtr.Zero);
                }
                else
                {
                    SendMessage(hwnd, _wmactivate, _waactice, IntPtr.Zero);
                    SendMessage(hwnd, _wmactivate, _wainactive, IntPtr.Zero);
                }

                appTitle.UpdateForeground(theme, activated);
            }
        }
    }
}
