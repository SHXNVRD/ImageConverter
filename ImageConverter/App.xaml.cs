using Microsoft.UI.Xaml;
using System;
using Microsoft.Extensions.DependencyInjection;

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

        protected async override void OnLaunched(LaunchActivatedEventArgs args)
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
            services.AddSingleton<IPickerService, PickerService>();

            services.AddTransient<SettingsViewModel>();
            services.AddTransient<ConvertToASCIIViewModel>();

            return services.BuildServiceProvider();
        }
    }
}
