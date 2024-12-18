using Bookmaster.AppData;
using Bookmaster.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Windows;
using System.Windows.Controls;

namespace Bookmaster.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddEditCustomerWindow.xaml
    /// </summary>
    public partial class AddEditCustomerWindow : Window
    {
        private List<City> _cities = App.context.Cities.ToList();
        public AddEditCustomerWindow()
        {
            InitializeComponent();

            CustomerCityCmb.ItemsSource = App.context.Cities.ToList();
            CustomerCityCmb.DisplayMemberPath = "Name";
            CustomerCityCmb.SelectedValuePath = "Id";

            CustomerIdTb.Text = GenerateCustomerId();
        }

        public AddEditCustomerWindow(Customer selectedCustomer)
        {
            InitializeComponent();

            DataContext = selectedCustomer;

            CustomerCityCmb.ItemsSource = App.context.Cities.ToList();
            CustomerCityCmb.DisplayMemberPath = "Name";
            CustomerCityCmb.SelectedValuePath = "Id";
            CustomerCityCmb.SelectedItem = selectedCustomer.City;
        }

        private void AddCustomerBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Customer newCustomer = new Customer()
                {
                    Id = CustomerIdTb.Text,
                    Name = CustomerNameTb.Text,
                    Address = CustomerAddressTb.Text,
                    CityId = Convert.ToInt32(CustomerCityCmb.SelectedValue),
                    Phone = CustomerPhoneTb.Text,
                    Email = CustomerEmailTb.Text,
                    Zip = CustomerZipTb.Text,
                };

                App.context.Customers.Add(newCustomer);
                App.context.SaveChanges();

                Feedback.Information("Читатель успешно добавлен!");
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"Некорректный аргумент: {ex.Message}");
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show($"Ошибка при добавлении администратора: {ex.Message}");
            }
            catch (InvalidOperationException exception)
            {
                Feedback.Error($"Недопустимая операция: {exception.Message}");
            }
            catch (SqlException exception)
            {
                Feedback.Error($"Ошибка SQL: {exception.Message}");
            }
            catch (TimeoutException ex)
            {
                MessageBox.Show($"Превышено время ожидания: {ex.Message}");
            }
            catch (Exception exception)
            {
                Feedback.Error($"Произошла непредвиденная ошибка: {exception.Message}");
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void EditCustomerBtn_Click(object sender, RoutedEventArgs e)
        {
            App.context.SaveChanges();

            Feedback.Information("Изменения успешно сохранены.");
        }

        private string GenerateCustomerId()
        {
            throw new NotImplementedException();
        }

        private string FormatPhoneNumber()
        {
            throw new NotImplementedException();
        }

        private void CustomerPhoneTb_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
