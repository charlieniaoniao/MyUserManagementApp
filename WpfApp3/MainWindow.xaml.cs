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
    }
}