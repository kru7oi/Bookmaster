using Bookmaster.AppData;
using Bookmaster.View.Pages;
using Bookmaster.View.Windows;
using System.Windows;

namespace Bookmaster
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MainFrame.Navigate(new BrowseCatalogPage());

            LogoutMi.Visibility = Visibility.Collapsed;
            LibraryMi.Visibility = Visibility.Collapsed;
        }

        private void LoginMi_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            if (loginWindow.ShowDialog() == true)
            {
                LogoutMi.Visibility = Visibility.Visible;
                LibraryMi.Visibility = Visibility.Visible;
                LoginMi.Visibility = Visibility.Collapsed;
            }
        }

        private void LogoutMi_Click(object sender, RoutedEventArgs e)
        {
            AuthenticationService.Logout();

            LogoutMi.Visibility = Visibility.Collapsed;
            LibraryMi.Visibility = Visibility.Collapsed;
            LoginMi.Visibility = Visibility.Visible;
        }

        private void CloseAppMi_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BrowseCatalogMi_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new BrowseCatalogPage());
        }

        private void CustomersMi_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ManageCustomersPage());
        }

        private void CirculationMi_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CirculationPage());
        }

        private void ReportsMi_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ReportsPage());
        }
    }
}