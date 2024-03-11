using ImageConverter.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

namespace ImageConverter.Views
{
    public sealed partial class ConvertToASCIIPage : Page
    {
        public ConvertToASCIIViewModel ViewModel { get; private set; }

        public ConvertToASCIIPage()
        {
            this.InitializeComponent();
            ViewModel = App.Current.Services.GetService<ConvertToASCIIViewModel>();
        }
    }
}
