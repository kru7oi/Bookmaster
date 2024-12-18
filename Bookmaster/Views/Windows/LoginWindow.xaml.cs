using Bookmaster.AppData;
using System.Windows;

namespace Bookmaster.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void AuthenticateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (AuthenticationService.Authenticate(LoginTb.Text, PasswordPb.Password))
            {
                DialogResult = true;
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
