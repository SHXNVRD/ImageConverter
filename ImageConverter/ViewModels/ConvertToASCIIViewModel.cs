using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ImageConverter.Services.ImageToASCII;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Graphics.Imaging;
using Windows.Networking.NetworkOperators;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using ImageConverter.Extensions;
using Microsoft.UI.Xaml.Controls;
using Windows.System.RemoteSystems;
using ImageConverter.Services.Files;

namespace ImageConverter.ViewModels
{
    public partial class ConvertToASCIIViewModel : ObservableObject
    {
        private const int DENOMINATOR = 100;

        private IImageToASCIIService _imageToASCIIService;
        private IFileService _fileService;
        private Bitmap _bitmap;
        private StorageFile _imageFile;
        private string _asciiArt;

        [ObservableProperty]
        private int _sizePercent = 100;

        [ObservableProperty]
        private double _widthOffset = 1;

        [ObservableProperty]
        private bool _isNegativeOn;

        public ConvertToASCIIViewModel(IImageToASCIIService imageToASCIIService, IFileService fileService)
        {
            _imageToASCIIService = imageToASCIIService;
            _fileService = fileService;
        }

        [RelayCommand]
        private async Task OnAddAsync()
        {
            FileOpenPicker openPicker = new FileOpenPicker();
            Window window = App.Window;
            var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(window);
            WinRT.Interop.InitializeWithWindow.Initialize(openPicker, hWnd);

            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.Desktop;

            openPicker.FileTypeFilter.Add(".jpg");
            openPicker.FileTypeFilter.Add(".png");
            openPicker.FileTypeFilter.Add(".gif");
            openPicker.FileTypeFilter.Add(".exif");
            openPicker.FileTypeFilter.Add(".tiff");

            _imageFile = await openPicker.PickSingleFileAsync();
            SoftwareBitmap softwareBitmap = await GetSoftwareBitmapAsync(_imageFile);
            _bitmap = softwareBitmap.ConvertToBitmap();
        }

        [RelayCommand]
        private void OnGenerateASCII()
        {
            try
            {
                if (_bitmap == null)
                    return;

                double maxWidth = _bitmap.Width * SizePercent / DENOMINATOR;
                var resizedBitmap = _imageToASCIIService.ResizeBitMap(_bitmap, (uint)maxWidth, WidthOffset);
                char[][] rows;

                if (IsNegativeOn)
                    rows = _imageToASCIIService.ConvertNegative(resizedBitmap);
                else
                    rows = _imageToASCIIService.Convert(resizedBitmap);

                _asciiArt = _imageToASCIIService.StringifyASCIIArray(rows);
                resizedBitmap.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [RelayCommand]
        private async Task OnSaveASCIIAsync()
        {
            await SaveASCIIAsync();
        }

        private async Task SaveASCIIAsync()
        {
            if (_asciiArt == null)
                return;

            await _fileService.SaveFileAsync(_asciiArt);
        }

        [RelayCommand]
        private void OnResetSettings()
        {
            ResetSettings();
        }

        private void ResetSettings()
        {
            WidthOffset = 1;
            SizePercent = 10;
            IsNegativeOn = false;
        }

        public async Task<SoftwareBitmap> GetSoftwareBitmapAsync(StorageFile image)
        {
            using (IRandomAccessStream stream = await image.OpenAsync(FileAccessMode.Read))
            {
                BitmapDecoder decoder = await BitmapDecoder.CreateAsync(stream);
                return await decoder.GetSoftwareBitmapAsync();
            }
        }
    }
}
