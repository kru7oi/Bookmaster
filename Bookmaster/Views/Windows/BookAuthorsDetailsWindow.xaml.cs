using Bookmaster.AppData;
using Bookmaster.Model;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Bookmaster.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для BookAuthorsDetailsWindow.xaml
    /// </summary>
    public partial class BookAuthorsDetailsWindow : Window
    {
        public BookAuthorsDetailsWindow(ICollection<BookAuthor> bookAuthors)
        {
            InitializeComponent();

            AuthorsCmb.ItemsSource = bookAuthors;
            AuthorsCmb.SelectedIndex = 0;
            AuthorsCmb.DisplayMemberPath = "Author.Name";
        }

        private void AuthorsCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataContext = AuthorsCmb.SelectedItem as BookAuthor;
        }

        private void WikipediaHl_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            string browserPath = @"C:\Users\Владислав\AppData\Local\Yandex\YandexBrowser\Application\browser.exe";

            try
            {
                Process.Start(browserPath, e.Uri.AbsoluteUri);
                e.Handled = true;
            }
            catch (Exception exception)
            {
                Feedback.Error(exception.Message);
            }
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
