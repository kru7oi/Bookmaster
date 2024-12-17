using Bookmaster.Model;
using System.Windows;
using System.Windows.Controls;

namespace Bookmaster.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для BrowseCatalogPage.xaml
    /// </summary>
    public partial class BrowseCatalogPage : Page
    {
        private List<Book> _books = App.context.Books.ToList();
        public BrowseCatalogPage()
        {
            InitializeComponent();

            BookAuthorsLv.ItemsSource = _books;

            BookDetailsGrid.Visibility = Visibility.Hidden;
        }

        private void BookAuthorsLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            string bookTitle = SearchByBookTitleTb.Text;
            string authorName = SearchByAuthorNameTb.Text;
            string bookSubjects = SearchByBookSubjectsTb.Text;

            if (string.IsNullOrEmpty(bookTitle) &&
                string.IsNullOrEmpty(authorName) &&
                string.IsNullOrEmpty(bookSubjects))
            {
                BookAuthorsLv.ItemsSource = _books;
            }
            else
            {
                BookAuthorsLv.ItemsSource = _books.Where(book =>
                book.Title.Contains(bookTitle, StringComparison.OrdinalIgnoreCase) &&
                book.Authors.Contains(authorName, StringComparison.OrdinalIgnoreCase));
            }
        }
    }
}
