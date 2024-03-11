using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageConverter.Services.Files
{
    public interface IFileService
    {
        //Task<T> ReadJsonAsync<T>(string fileFolder, string fileName);
        //Task SaveJsonAsync<T>(string fileFolder, string fileName, T value);

        T ReadJson<T>(string fileFolder, string fileName);
        void SaveJson<T>(string fileFolder, string fileName, T value);
        Task SaveFileAsync(string fileFolder, string fileName, string value);
        Task SaveFileAsync(string value);
    }
}
