using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageConverter.Services.Settings
{
    public interface ISettingsService
    {
        void Initialize();
        T ReadSetting<T>(string key);
        void SaveSetting<T>(string key, T value);
    }
}
