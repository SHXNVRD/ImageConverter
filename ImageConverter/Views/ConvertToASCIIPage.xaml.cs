using Microsoft.UI.Xaml.Controls;

namespace ImageConverter.Views
{
    public sealed partial class ConvertToASCIIPage : Page
    {
        public ConvertToASCIIViewModel ViewModel { get; private set; }

        public ConvertToASCIIPage()
        {
            this.InitializeComponent();
            ViewModel = Ioc.Default.GetService<ConvertToASCIIViewModel>();
        }
    }
}
