using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Threading.Tasks;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.Storage.Streams;
using Microsoft.UI.Dispatching;
using System.Diagnostics;
using System.Collections.ObjectModel;
using ImageConverter.Helpers;

namespace ImageConverter.ViewModels
{
    public partial class ConvertToASCIIViewModel : ObservableObject
    {
        //private readonly DispatcherQueue _dispetcherQueue = DispatcherQueue.GetForCurrentThread();

        private const int DENOMINATOR = 100;

        private IPickerService _pickerService;
        private ISettingsService _settinsService;
        private SoftwareBitmap _softwareBitmap;

        [ObservableProperty]
        private ObservableCollection<string> _asciiArtRows;

        [ObservableProperty]
        private string _asciiArt;

        [ObservableProperty]
        private int _sizePercent = 100;

        [ObservableProperty]
        private double _widthOffset = 1;

        [ObservableProperty]
        private bool _isNegativeOn;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(ImagePath))]
        private StorageFile _imageFile;

        public string ImagePath
        {
            get
            {
                if (ImageFile != null)
                    return ImageFile.Path;
                else
                    return default;
            }
        }

        public ConvertToASCIIViewModel(IPickerService pickerService, ISettingsService settingsService)
        {
            _pickerService = pickerService;
            _settinsService = settingsService;
        }

        [RelayCommand]
        private async Task OnAddAsync()
        {
            ImageFile = await _pickerService.PickImageAsync(App.Current.Window);

            if (ImageFile == null)
                return;

            _softwareBitmap = await GetSoftwareBitmapAsync(ImageFile);
        }

        [RelayCommand]
        private async Task OnGenerateASCII()
        {
            SoftwareBitmap resizedBitmap = null;

            try
            {
                if (_softwareBitmap == null)
                    return;

                var newWidth = _softwareBitmap.PixelWidth * SizePercent / DENOMINATOR;
                var newHeight = _softwareBitmap.PixelHeight / WidthOffset * newWidth / _softwareBitmap.PixelHeight;
                resizedBitmap = _softwareBitmap.Resize(newWidth, (int)newHeight);
                resizedBitmap = resizedBitmap.ConvertToGrayscale();
                char[][] rows;

                if (await _settinsService.ReadSettingAsync<bool>("UseCustomSymbols"))
                {
                    var settings = new AsciiConverterSettings();
                    var symbols = _settinsService.ReadSettingAsync<string>("CustomSymbols").Result.ToCharArray();
                    settings.AsciiTable = symbols;
                    Array.Reverse(symbols);
                    settings.AsciiTableNegative = symbols;

                    if (IsNegativeOn)
                    {
                        rows = await AsciiConvert.ConvertAsync(resizedBitmap, settings);
                    }
                    else
                    {
                        rows = await AsciiConvert.ConvertNegativeAsync(resizedBitmap, settings);

                    }

                    AsciiArt = AsciiConvert.StringifyAscii(rows);
                }
                else
                {
                    if (IsNegativeOn)
                    {
                        rows = await AsciiConvert.ConvertAsync(resizedBitmap);
                    }
                    else
                    {
                        rows = await AsciiConvert.ConvertNegativeAsync(resizedBitmap);

                    }

                    AsciiArt = AsciiConvert.StringifyAscii(rows);
                }

            }
            catch (Exception ex)
            {
                await DialogService.ConfirmationDialogAsync(App.Current.MainRoot, "Возникла ошибка", $"{ex.Message}\n{ex.StackTrace}", "ОК");
            }
            finally
            {
                resizedBitmap?.Dispose();
            }
        }

        [RelayCommand]
        private async Task SaveAsync()
        {
            if (AsciiArt == null)
                return;

            try
            {
                StorageFile file = await _pickerService.PickSaveTxtAsync(App.Current.Window);

                if (file == null)
                    return;

                await FileIO.WriteTextAsync(file, AsciiArt);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
            }
        }

        [RelayCommand]
        private void ResetSettings()
        {
            WidthOffset = 1;
            SizePercent = 100;
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