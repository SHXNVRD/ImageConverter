using System.Threading.Tasks;

namespace ImageConverter.Services.CustomSymbolsService
{
    public interface IUserSymbolsService
    {
        string UserSymbols { get; }
        bool UseUserSymbols { get; }

        Task InitializeAsync();
        Task SetUserSymbolsAsync(string symbols);
        Task SetUseUserSymbolsAsync(bool useUserSymbols);
    }
}