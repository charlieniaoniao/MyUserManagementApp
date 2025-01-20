using MyUserManagementApp.Services;
using System.Windows;

namespace MyUserManagementApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModels.UserManagementViewModel();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var client = new TestClient();
            await client.InitHubConnectionAsync();
        }
    }
}