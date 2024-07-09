using Microsoft.UI.Xaml.Controls;

namespace ImageConverter.Views
{
    public sealed partial class ConvertToASCIIPage : Page
    {
        public ConvertToASCIIViewModel ViewModel { get; }

        public ConvertToASCIIPage() : this(App.GetService<ConvertToASCIIViewModel>())
        {
            InitializeComponent();
        }

        private ConvertToASCIIPage(ConvertToASCIIViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = ViewModel;
        }
    }
}
