using Microsoft.UI.Xaml;
using System.Threading.Tasks;
using Windows.Storage;

namespace ImageConverter.Services.Interfaces
{
    public interface IPickerService
    {
        Task<StorageFile> PickImageAsync(Window window);
        Task<StorageFile> PickSaveTxtAsync(Window window);
    }
}
