using System.Threading.Tasks;

namespace ImageConverter.Services.Settings
{
    public interface ISettingsService
    {
        Task InitializeAsync();
        Task<T?> ReadSettingAsync<T>(string key);
        Task SaveSettingAsync<T>(string key, T value);
    }
}
