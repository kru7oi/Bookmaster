using Bookmaster.Model;
using System.Windows;

namespace Bookmaster.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddEditCustomerWindow.xaml
    /// </summary>
    public partial class AddEditCustomerWindow : Window
    {
        public AddEditCustomerWindow()
        {
            InitializeComponent();
        }

        public AddEditCustomerWindow(Customer selectedCustomer)
        {
            InitializeComponent();
        }
    }
}
