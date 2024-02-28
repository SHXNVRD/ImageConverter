using ImageConverter.Services.Files;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using System.Text.Json.Nodes;
using Windows.Storage;
using Microsoft.UI.Xaml;

namespace ImageConverter.Services.Settings
{
    public class SettingsService : ISettingsService
    {
        private const string _defaultAppDataFolder = "ImageConverter/ApplicationData";
        private const string _defaultSettingsFile = "Settings.json";

        private readonly string _rootAppDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        private readonly string _appDataFolder;
        private readonly string _settingsFile;

        private readonly IFileService _fileService;

        private IDictionary<string, object> _settings;

        private bool _isInitialized;

        public SettingsService(IFileService fileService)
        {
            _fileService = fileService;
            _appDataFolder = Path.Combine(_rootAppDataFolder, _defaultAppDataFolder);
            _settingsFile = _defaultSettingsFile;

            _settings = new Dictionary<string, object>();
        }

        public void Initialize()
        {
            if (!_isInitialized)
            {
                _settings = _fileService.ReadFromJson<IDictionary<string, object>>(_appDataFolder, _settingsFile) ?? new Dictionary<string, object>();

                _isInitialized = true;
            }
        }

        public T ReadSetting<T>(string key)
        {
            Initialize();

            if (_settings != null && _settings.TryGetValue(key, out var value))
            {
                return JsonConvert.DeserializeObject<T>((string)value);
            }

            return default;
        }

        public void SaveSetting<T>(string key, T value)
        {
            Initialize();

            _settings[key] = JsonConvert.SerializeObject(value);

            _fileService.SaveToJson(_appDataFolder, _settingsFile, _settings);
        }
    }
}
