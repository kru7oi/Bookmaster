using Bookmaster.Model;
using System.Windows;
using System.Windows.Controls;

namespace Bookmaster.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для ManageCustomersPage.xaml
    /// </summary>
    public partial class ManageCustomersPage : Page
    {
        private List<Customer> _customers = App.context.Customers.ToList();
        public ManageCustomersPage()
        {
            InitializeComponent();
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            CustomersLv.Visibility = Visibility.Visible;

            string customerId = SearchCustomerByIdTb.Text;
            string customerName = SearchCustomerByNameTb.Text;

            if (string.IsNullOrEmpty(customerId) &&
                string.IsNullOrEmpty(customerName))
            {
                CustomersLv.ItemsSource = _customers;
            }
            else
            {
                CustomersLv.ItemsSource = _customers.Where(customer =>
                customer.Id.Contains(customerId, StringComparison.OrdinalIgnoreCase) &&
                customer.Name.Contains(customerName, StringComparison.OrdinalIgnoreCase));
            }
        }

        private void EditCustomerBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddCustomerBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
