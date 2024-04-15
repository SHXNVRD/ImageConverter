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
        void Delete(string folderPath, string fileName);
    }
}
