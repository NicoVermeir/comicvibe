using ComicVibe.App.ViewModels;
using Windows.UI.Xaml.Controls;

namespace ComicVibe.App.Views
{
    public sealed partial class MainPage : Page
    {
        private MainViewModel ViewModel => DataContext as MainViewModel;

        public MainPage()
        {
            InitializeComponent();
        }
    }
}
