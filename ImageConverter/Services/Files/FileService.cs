using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ImageConverter.Services.Settings;
using Newtonsoft.Json;
using Windows.Graphics.Printing3D;

namespace ImageConverter.Services.Files
{
    public class FileService : IFileService
    {
        public T ReadJson<T>(string folderPath, string fileName)
        {
            string filePath = Path.Combine(folderPath, fileName);

            if (File.Exists(filePath))
            {
                string file = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<T>(file);
            }

            return default;
        }

        public void SaveJson<T>(string folderPath, string fileName, T value)
        {
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            var savingValue = JsonConvert.SerializeObject(value);
            File.WriteAllText(Path.Combine(folderPath, fileName), savingValue, Encoding.UTF8);
        }

        public void Delete(string folderPath, string fileName)
        {
            if (fileName != null && File.Exists(Path.Combine(folderPath, fileName)))
            {
                File.Delete(Path.Combine(folderPath, fileName));
            }
        }
    }
}
