using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace ImageConverter.Services.Files
{
    public class FileService : IFileService
    {
        public T ReadFromJson<T>(string fileFolder, string fileName)
        {
            string filePath = Path.Combine(fileFolder, fileName);

            if (File.Exists(filePath))
            {
                string file = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<T>(file);
            }

            return default;
        }

        public void SaveToJson<T>(string fileFolder, string fileName, T value)
        {
            if (!Directory.Exists(fileFolder))
                Directory.CreateDirectory(fileFolder);

            var savingValue = JsonConvert.SerializeObject(value);
            File.WriteAllText(Path.Combine(fileFolder, fileName), savingValue, Encoding.UTF8);
        }
    }
}
