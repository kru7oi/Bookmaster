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
        //private readonly List<Book> _allBooks = App.context.Books.ToList();
        //private readonly List<Author> _allAuthors = App.context.Authors.ToList();
        public MainWindow()
        {
            InitializeComponent();

            MainFrame.Navigate(new BrowseCatalogPage());

            //BooksLv.ItemsSource = App.context.Books.ToList();

            //_allAuthors.Insert(0, new() { Name = "Все авторы" });

            //SearchCmb.ItemsSource = _allAuthors;
        }
        private void BrowseCatalogMi_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new BrowseCatalogPage());
        }

        private void LoginMi_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.ShowDialog();
        }

        private void LogoutMi_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CloseMi_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ManageCustomersMi_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ManageCustomersPage());
        }

        private void CirculationMi_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ReviewsMi_Click(object sender, RoutedEventArgs e)
        {

        }


        //private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    string searchText = SearchTb.Text;

        //    if (string.IsNullOrEmpty(searchText))
        //    {
        //        BooksLv.ItemsSource = _allBooks;
        //    }
        //    else
        //    {
        //        BooksLv.ItemsSource = _allBooks.Where(book => book.Title.Contains(searchText, StringComparison.OrdinalIgnoreCase));
        //    }
        //}

        //private void SearchCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    var selectedAuthor = SearchCmb.SelectedItem as Author;

        //    if (selectedAuthor == null || selectedAuthor.Name == "Все авторы")
        //    {
        //        BooksLv.ItemsSource = _allBooks;
        //    }
        //    else
        //    {
        //        int selectedAuthorId = selectedAuthor.Id;
        //        BooksLv.ItemsSource = _allBooks.Where(book => book.Author.Id == selectedAuthorId);
        //    }
        //}
    }
}