using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;

namespace ImageConverter.Services.Interfaces
{
    public interface IPickerService
    {
        Task<StorageFile> PickImageAsync(Window window);
        Task<StorageFile> PickSaveTxtAsync(Window window);
    }
}
