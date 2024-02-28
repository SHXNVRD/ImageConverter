using ImageConverter.Services.Settings;
using ImageConverter.ViewModels;
using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using ImageConverter.Services.Files;
using Microsoft.Extensions.DependencyInjection;
using ImageConverter.Services.ThemeSelector;

namespace ImageConverter
{
    public partial class App : Application
    {
        public static Window Window { get; private set; }
        public new static App Current => (App)Application.Current;
        public IServiceProvider Services { get; }

        private readonly IThemeSelectorService _themeSelectorService;
        public App()
        {
            this.InitializeComponent();
            Services = ConfigureServices();
            _themeSelectorService = Services.GetService<IThemeSelectorService>();

            _themeSelectorService.SetThemeOnLoadedApp();
        }

        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {

            Window = new MainWindow();
            Window.Activate();
        }

        public IServiceProvider ConfigureServices()
        {
            ServiceCollection services = new ServiceCollection();

            services.AddSingleton<IFileService, FileService>();
            services.AddSingleton<ISettingsService, SettingsService>();
            services.AddSingleton<IThemeSelectorService, ThemeSelectorService>();

            return services.BuildServiceProvider();
        }
    }
}
