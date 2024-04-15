using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;

namespace ImageConverter.Services.Pickers
{
    public class PickerService : IPickerService
    {
        public async Task<StorageFile> PickImageAsync(Window window)
        {
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.Desktop;

            var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(window);
            WinRT.Interop.InitializeWithWindow.Initialize(openPicker, hWnd);

            openPicker.FileTypeFilter.Add(".jpg");
            openPicker.FileTypeFilter.Add(".png");
            openPicker.FileTypeFilter.Add(".gif");
            openPicker.FileTypeFilter.Add(".exif");
            openPicker.FileTypeFilter.Add(".tiff");

            return await openPicker.PickSingleFileAsync();
        }

        public async Task<StorageFile> PickSaveTxtAsync(Window window)
        {
            FileSavePicker savePicker = new FileSavePicker();
            var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(window);
            WinRT.Interop.InitializeWithWindow.Initialize(savePicker, hWnd);

            savePicker.FileTypeChoices.Add("txt", new List<string>() { ".txt" });
            savePicker.SuggestedFileName = "New ASCII art";
            savePicker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;

            return await savePicker.PickSaveFileAsync();
        }
    }
}
