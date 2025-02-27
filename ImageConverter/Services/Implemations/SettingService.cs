﻿using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ImageConverter.Services.Settings
{
    public class SettingsService : ISettingsService
    {
        private const string _defaultAppDataFolder = "ImageConverter/ApplicationData";
        private const string _defaultSettingsFile = "Settings.json";

        private readonly string _rootAppDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        private readonly string _appDataFolder;
        private readonly string _settingsFile;

        private IDictionary<string, object> _settings;

        private bool _isInitialized;

        public SettingsService()
        {
            _appDataFolder = Path.Combine(_rootAppDataFolder, _defaultAppDataFolder);
            _settingsFile = _defaultSettingsFile;
            _settings = new Dictionary<string, object>();
        }

        public async Task InitializeAsync()
        {
            if (!_isInitialized)
            {
                _settings = await Task.Run(() => FileStorage.ReadJson<IDictionary<string, object>>(_appDataFolder, _settingsFile)) ?? new Dictionary<string, object>();

                _isInitialized = true;
            }
        }

        public async Task<T?> ReadSettingAsync<T>(string key)
        {
            await InitializeAsync();

            if (_settings != null && _settings.TryGetValue(key, out var value))
            {
                return JsonConvert.DeserializeObject<T>((string)value);
            }

            return default;
        }

        public async Task SaveSettingAsync<T>(string key, T value)
        {
            await InitializeAsync();

            _settings[key] = JsonConvert.SerializeObject(value);

            await Task.Run(() => FileStorage.SaveJson(_appDataFolder, _settingsFile, _settings));
        }
    }
}
