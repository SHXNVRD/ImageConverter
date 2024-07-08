using Microsoft.UI.Xaml;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using ImageConverter.Services.CustomSymbolsService;
using WinUIEx;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.UI.Xaml.Controls;
using System;
using Microsoft.Extensions.Hosting;
using Microsoft.UI.Xaml.Automation;
using Microsoft.Extensions.Options;
using WinUICommunity;

namespace ImageConverter
{
    public partial class App : Application
    {
        public MainWindow MainWindow { get; private set; }
        public FrameworkElement MainRoot { get; private set; }
        public TextBlock AppTitle { get; set; }
        public new static App Current => (App)Application.Current;

        private readonly IHost _host;

        public App()
        {
            InitializeComponent();
            _host = Host
                .CreateDefaultBuilder()
                .UseContentRoot(AppContext.BaseDirectory)
                .ConfigureServices((context, services) =>
                {
                    services
                    .Configure<PickerOptions>(context.Configuration.GetSection(nameof(PickerOptions)))
                    .AddSingleton<ISettingsService, SettingsService>()
                    .AddSingleton<IThemeSelectorService, ThemeSelectorService>()
                    .AddSingleton<IPickerService, PickerService>()
                    .AddSingleton<IUserSymbolsService, UserSymbolsService>()
                    .AddSingleton<INavigationService, NavigationService>()
                    .AddTransient<MainViewModel>()
                    .AddTransient<SettingsViewModel>()
                    .AddScoped<ConvertToASCIIViewModel>()
                    .AddTransient<MainWindow>()
                    .AddTransient<SettingsPage>()
                    .AddScoped<ConvertToASCIIPage>();
                })
                .Build();
        }

        public static T GetService<T>() where T : class
        {
            if (App.Current._host.Services.GetService(typeof(T)) is not T service)
            {
                throw new ArgumentException($"{typeof(T)} needs to be registered in ConfigureServices within App.xaml.cs.");
            }

            return service;
        }

        protected async override void OnLaunched(LaunchActivatedEventArgs args)
        {
            MainWindow = GetService<MainWindow>();
            MainRoot = (FrameworkElement)MainWindow.Content;

            await _host.Services
                .GetService<IThemeSelectorService>()
                .InitializeAsync();
            await _host.Services
                .GetService<IUserSymbolsService>()
                .InitializeAsync();

            MainWindow.Activate();
        }
    }
}
