using Bookmaster.AppData;
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
            Customer? selectedCustomer = CustomersLv.SelectedItem as Customer;

            if (selectedCustomer != null)
            {
                AddEditCustomerWindow addEditCustomerWindow = new AddEditCustomerWindow(selectedCustomer);
                addEditCustomerWindow.ShowDialog();
            }
            else
            {
                Feedback.Error("Невозможно открыть окно для редактирования читателя. Сначала выберите его из списка.");
            }
        }

        private void AddCustomerBtn_Click(object sender, RoutedEventArgs e)
        {
            AddEditCustomerWindow addEditCustomerWindow = new AddEditCustomerWindow();
            if (addEditCustomerWindow.ShowDialog() == true)
            {
                CustomersLv.ItemsSource = _customers;
            }
        }
    }
}
