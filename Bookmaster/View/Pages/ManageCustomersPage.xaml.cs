using Bookmaster.Model;
using Bookmaster.View.Windows;
using System.Windows;
using System.Windows.Controls;

namespace Bookmaster.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для ManageCustomersPage.xaml
    /// </summary>
    public partial class ManageCustomersPage : Page
    {
        private readonly List<Customer> _customers = App.context.Customers.ToList();
        public ManageCustomersPage()
        {
            InitializeComponent();

            CustomersLv.ItemsSource = _customers;
        }

        private void SearchCustomerBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditCustomerBtn_Click(object sender, RoutedEventArgs e)
        {
            AddEditCustomerWindow addEditCustomerWindow = new AddEditCustomerWindow();
            addEditCustomerWindow.ShowDialog();
        }

        private void AddCustomerBtn_Click(object sender, RoutedEventArgs e)
        {
            AddEditCustomerWindow addEditCustomerWindow = new AddEditCustomerWindow();
            addEditCustomerWindow.ShowDialog();
        }
    }
}
