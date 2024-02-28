using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageConverter.Services.Files
{
    public interface IFileService
    {
        T ReadFromJson<T>(string fileFolder, string fileName);
        void SaveToJson<T>(string fileFolder, string fileName, T value);
    }
}
