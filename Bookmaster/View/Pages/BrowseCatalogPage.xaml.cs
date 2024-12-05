using Bookmaster.Model;
using System.Windows.Controls;

namespace Bookmaster.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для BrowseCatalogPage.xaml
    /// </summary>
    public partial class BrowseCatalogPage : Page
    {
        private readonly List<BookAuthor> _allBookAuthors = App.context.BookAuthors.ToList();
        public BrowseCatalogPage()
        {
            InitializeComponent();

            BookAuthorsLv.ItemsSource = _allBookAuthors;
        }

        private void BookAuthorsLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void PreviousPageBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void NextPageBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}
