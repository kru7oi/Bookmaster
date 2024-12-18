using Bookmaster.AppData;
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
        private Book? _selectedBook;

        private List<Book> _books = App.context.Books.ToList();
        private List<BookCover> _covers = App.context.BookCovers.ToList();

        private PaginationService<Book>? _booksPagination;
        private PaginationService<BookCover>? _coverPagination;
        public BrowseCatalogPage()
        {
            InitializeComponent();
        }

        private void BookAuthorsLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Book? selectedBook = BookAuthorsLv.SelectedItem as Book;

            if (selectedBook != null)
            {
                BookDetailsGrid.Visibility = Visibility.Visible;
                BookDetailsGrid.DataContext = selectedBook;
                _coverPagination = new PaginationService<BookCover>(_covers.Where(cover => cover.BookId == selectedBook.Id).ToList(), 1);
                CoversLb.ItemsSource = _coverPagination.CurrentPageOfItems;
                _coverPagination.UpdateNavigationButtons(NextCoverBtn, PreviousCoverBtn);
            }
        }

        #region Поиск по книгам
        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            SearchResultsGrid.Visibility = Visibility.Visible;

            string bookTitle = SearchByBookTitleTb.Text;
            string authorName = SearchByAuthorNameTb.Text;
            string bookSubjects = SearchByBookSubjectsTb.Text;

            if (string.IsNullOrEmpty(bookTitle) &&
                string.IsNullOrEmpty(authorName) &&
                string.IsNullOrEmpty(bookSubjects))
            {
                _booksPagination = new PaginationService<Book>(_books, 50);
            }
            else
            {
                IEnumerable<Book> searchResult = _books.Where(book =>
                book.Title.Contains(bookTitle, StringComparison.OrdinalIgnoreCase) &&
                book.Authors.Contains(authorName, StringComparison.OrdinalIgnoreCase));

                _booksPagination = new PaginationService<Book>(searchResult.ToList(), 50);
            }

            BookAuthorsLv.ItemsSource = _booksPagination.CurrentPageOfItems;
            CurrentPageTb.Text = _booksPagination.CurrentPageNumber.ToString();
            TotalPagesTbl.DataContext = TotalBooksTbl.DataContext = _booksPagination;
            _booksPagination.UpdateNavigationButtons(NextBookBtn, PreviousBookBtn);
        }
        #endregion

        #region Навигация по книгам
        private void PreviousBookBtn_Click(object sender, RoutedEventArgs e)
        {
            BookAuthorsLv.ItemsSource = _booksPagination.PreviousPage();
            CurrentPageTb.Text = _booksPagination.CurrentPageNumber.ToString();
            _booksPagination.UpdateNavigationButtons(NextBookBtn, PreviousBookBtn);
        }
        private void NextBookBtn_Click(object sender, RoutedEventArgs e)
        {
            BookAuthorsLv.ItemsSource = _booksPagination.NextPage();
            CurrentPageTb.Text = _booksPagination.CurrentPageNumber.ToString();
            _booksPagination.UpdateNavigationButtons(NextBookBtn, PreviousBookBtn);
        }
        private void CurrentPageTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(CurrentPageTb.Text, out int pageNumber) && pageNumber >= 1 && pageNumber <= _booksPagination.TotalPages)
            {
                BookAuthorsLv.ItemsSource = _booksPagination.SetCurrentPage(pageNumber);
            }

            _booksPagination.UpdateNavigationButtons(NextBookBtn, PreviousBookBtn);
        }
        #endregion

        private void AuthorsDetailsHl_Click(object sender, RoutedEventArgs e)
        {
            _selectedBook = BookAuthorsLv.SelectedItem as Book;

            if (_selectedBook != null)
            {
                BookAuthorsDetailsWindow bookAuthorsDetailsWindow = new BookAuthorsDetailsWindow(_selectedBook.BookAuthors);
                bookAuthorsDetailsWindow.ShowDialog();
            }
        }

        private void PreviousCoverBtn_Click(object sender, RoutedEventArgs e)
        {
            CoversLb.ItemsSource = _coverPagination.PreviousPage();
            _coverPagination.UpdateNavigationButtons(NextCoverBtn, PreviousCoverBtn);
        }

        private void NextCoverBtn_Click(object sender, RoutedEventArgs e)
        {
            CoversLb.ItemsSource = _coverPagination.NextPage();
            _coverPagination.UpdateNavigationButtons(NextCoverBtn, PreviousCoverBtn);
        }
    }
}
