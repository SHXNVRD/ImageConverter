using ImageConverter.Services.Settings;
using ImageConverter.ViewModels;
using Microsoft.UI.Xaml;
using System;
using ImageConverter.Services.Files;
using Microsoft.Extensions.DependencyInjection;
using ImageConverter.Services.ThemeSelector;
using ImageConverter.Services.Navigation;
using Microsoft.UI.Xaml.Controls;
using ImageConverter.Services.ImageToASCII;

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
        }

        protected async override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            Window = new MainWindow();
            ElementTheme loadedTheme = await _themeSelectorService.LoadThemeAsync();
            _themeSelectorService.SetTheme(loadedTheme);
            Window.Activate();
        }

        public IServiceProvider ConfigureServices()
        {
            ServiceCollection services = new ServiceCollection();

            services.AddSingleton<IFileService, FileService>();
            services.AddSingleton<ISettingsService, SettingsService>();
            services.AddSingleton<IThemeSelectorService, ThemeSelectorService>();
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<IImageToASCIIService, ImageToASCIIService>();

            services.AddTransient<SettingsViewModel>();
            services.AddTransient<ConvertToASCIIViewModel>();

            return services.BuildServiceProvider();
        }
    }
}
