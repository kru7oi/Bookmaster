using Bookmaster.Model;
using Bookmaster.View.Windows;
using System.Windows;
using System.Windows.Controls;

namespace Bookmaster.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для BrowseCatalogPage.xaml
    /// </summary>
    public partial class BrowseCatalogPage : Page
    {
        private readonly List<BookAuthor> _allBookAuthors = App.context.BookAuthors.ToList();
        private BookAuthor? _selectedBookAuthor;
        public BrowseCatalogPage()
        {
            InitializeComponent();

            BookAuthorsLv.ItemsSource = _allBookAuthors;
        }

        private void BookAuthorsLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedBookAuthor = BookAuthorsLv.SelectedItem as BookAuthor;

            List<BookCover> bookCovers = App.context.BookCovers.Where(bookCover => bookCover.BookId == _selectedBookAuthor.BookId).ToList();

            if (_selectedBookAuthor != null)
            {
                BookDetailsGrid.DataContext = _selectedBookAuthor;
            }
        }

        private void PreviousPageBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NextPageBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OpenBookAuthorsDetailsHl_Click(object sender, RoutedEventArgs e)
        {
            BookAuthorsDetailsWindow bookAuthorsDetailsWindow = new BookAuthorsDetailsWindow();
            bookAuthorsDetailsWindow.ShowDialog();
        }
    }
}
