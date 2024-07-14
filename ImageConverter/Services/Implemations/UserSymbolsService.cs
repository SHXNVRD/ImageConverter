using System.Threading.Tasks;

namespace ImageConverter.Services.CustomSymbolsService
{
    public class UserSymbolsService : IUserSymbolsService
    {
        private readonly ISettingsService _settingsService;
        private bool _isInitialized;

        const string UserSymbolsSettingsKey = "UserSymbols";
        const string UseUserSymbolsSettingsKey = "UseUserSymbols";

        public string? UserSymbols { get; private set; }
        public bool UseUserSymbols { get; private set; }

        public UserSymbolsService(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        public async Task InitializeAsync()
        {
            if (!_isInitialized)
            {
                UserSymbols = await _settingsService.ReadSettingAsync<string>(UserSymbolsSettingsKey);
                UseUserSymbols = await _settingsService.ReadSettingAsync<bool>(UseUserSymbolsSettingsKey);
                _isInitialized = true;
            }
        }

        public async Task SetUserSymbolsAsync(string symbols)
        {
            UserSymbols = symbols;

            await SaveUserSymbolsAsync(UserSymbols);
        }

        public async Task SetUseUserSymbolsAsync(bool useUserSymbols)
        {
            UseUserSymbols = useUserSymbols;

            await SaveUseUserSymbolsAsync(UseUserSymbols);
        }

        private async Task SaveUserSymbolsAsync(string symbols)
        {
            await _settingsService.SaveSettingAsync<string>(UserSymbolsSettingsKey, symbols);
        }

        private async Task SaveUseUserSymbolsAsync(bool useUserSymbols)
        {
            await _settingsService.SaveSettingAsync<bool>(UseUserSymbolsSettingsKey, useUserSymbols);
        }
    }
}
