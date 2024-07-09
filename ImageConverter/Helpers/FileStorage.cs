using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace ImageConverter.Services.Files
{
    public static class FileStorage
    {
        public static T ReadJson<T>(string folderPath, string fileName)
        {
            string filePath = Path.Combine(folderPath, fileName);

            if (File.Exists(filePath))
            {
                string file = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<T>(file);
            }

            return default;
        }

        public static void SaveJson<T>(string folderPath, string fileName, T value)
        {
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            var savingValue = JsonConvert.SerializeObject(value);
            File.WriteAllText(Path.Combine(folderPath, fileName), savingValue, Encoding.UTF8);
        }

        public static void Delete(string folderPath, string fileName)
        {
            if (fileName != null && File.Exists(Path.Combine(folderPath, fileName)))
            {
                File.Delete(Path.Combine(folderPath, fileName));
            }
        }
    }
}
