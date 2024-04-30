using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using System.Xml.Linq;

namespace ImageConverter.Helpers
{

    public static class DialogService
    {
        public static async Task<bool> ConfirmationDialogAsync(FrameworkElement element, string title, string content, string yesButtonText)
        {
            return (await ConfirmationDialogAsync(element, title, content, yesButtonText, string.Empty, string.Empty)).Value;
        }

        public static async Task<bool> ConfirmationDialogAsync(FrameworkElement element, string title, string content, string yesButtonText, string noButtonText)
        {
            return (await ConfirmationDialogAsync(element, title, content, yesButtonText, noButtonText, string.Empty)).Value;
        }

        private static async Task<bool?> ConfirmationDialogAsync(FrameworkElement element, string title, string content, string yesButtonText, string noButtonText, string cancelButtonText)
        {
            var dialog = new ContentDialog
            {
                Title = title,
                Content = content,
                PrimaryButtonText = yesButtonText,
                SecondaryButtonText = noButtonText,
                CloseButtonText = cancelButtonText,
                XamlRoot = element.XamlRoot,
                RequestedTheme = element.ActualTheme,
                DefaultButton = ContentDialogButton.Primary
            };
            var result = await dialog.ShowAsync();

            if (result == ContentDialogResult.None)
            {
                return null;
            }

            return result == ContentDialogResult.Primary;
        }
    }
}
