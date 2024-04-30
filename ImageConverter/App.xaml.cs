using Microsoft.UI.Xaml;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using ImageConverter.Services.CustomSymbolsService;

namespace ImageConverter
{
    public partial class App : Application
    {
        public MainWindow Window { get; private set; }
        public FrameworkElement MainRoot { get; private set; }
        public new static App Current => (App)Application.Current;

        public App()
        {
            this.InitializeComponent();
            ConfigureServices();
        }

        protected async override void OnLaunched(LaunchActivatedEventArgs args)
        {
            Window = new MainWindow();
            MainRoot = (FrameworkElement)Window.Content;
            await Ioc.Default.GetService<IThemeSelectorService>().InitializeAsync();
            Ioc.Default.GetService<IThemeSelectorService>().SetCurrentTheme();
            await Ioc.Default.GetService<UserSymbolsService>().InitializeAsync();
            Window.Activate();
        }

        public void ConfigureServices()
        {
            ServiceCollection services = new ServiceCollection();

            services.AddSingleton<IFileService, FileService>();
            services.AddSingleton<ISettingsService, SettingsService>();
            services.AddSingleton<IThemeSelectorService, ThemeSelectorService>();
            services.AddSingleton<IPickerService, PickerService>();
            services.AddSingleton<UserSymbolsService>();

            services.AddTransient<SettingsViewModel>();
            services.AddTransient<ConvertToASCIIViewModel>();

            Ioc.Default.ConfigureServices(services.BuildServiceProvider());
        }
    }
}
