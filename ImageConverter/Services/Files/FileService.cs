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
        private const string DEFAULT_ASCII_FOLDER = "ImageConverter/ASCIIArtsFolder";
        private const string DEFAULT_ASCII_FIE = "ASCII.txt";

        private readonly string _rootAppDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        private readonly string _appASCIIFolder;
        public string UserFolder { get; private set; }

        public readonly string SettingsKey = "ASCIIArtsFolder";

        public FileService()
        {
            _appASCIIFolder = Path.Combine(_rootAppDataFolder, DEFAULT_ASCII_FOLDER);
        }

        public T ReadJson<T>(string fileFolder, string fileName)
        {
            string filePath = Path.Combine(fileFolder, fileName);

            if (File.Exists(filePath))
            {
                string file = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<T>(file);
            }

            return default;
        }

        public void SaveJson<T>(string fileFolder, string fileName, T value)
        {
            if (!Directory.Exists(fileFolder))
                Directory.CreateDirectory(fileFolder);

            var savingValue = JsonConvert.SerializeObject(value);
            File.WriteAllText(Path.Combine(fileFolder, fileName), savingValue, Encoding.UTF8);
        }

        public async Task SaveFileAsync(string fileFolder, string fileName, string value)
        {
            await File.WriteAllTextAsync(Path.Combine(fileFolder, fileName), value);
        }

        public async Task SaveFileAsync(string value)
        {
            if (Directory.Exists(UserFolder))
            {
                await File.WriteAllTextAsync(Path.Combine(UserFolder, DEFAULT_ASCII_FIE), value);
            }
            else
            {
                if (!Directory.Exists(_appASCIIFolder))
                    Directory.CreateDirectory(_appASCIIFolder);

                await File.WriteAllTextAsync(Path.Combine(_appASCIIFolder, DEFAULT_ASCII_FIE), value);
            }
        }
    }
}
