using System.Windows.Controls;

namespace Bookmaster.AppData
{
    class PaginationService<T>
    {
        private readonly int _pageSize;
        private readonly List<T> _items;
        private int _currentPageIndex = 0;
        private int _currentPageNumber = 0;

        public int CurrentPageNumber
        {
            get
            {
                return _currentPageNumber = _currentPageIndex + 1;
            }
            private set
            {
                _currentPageIndex = value - 1;

                _currentPageNumber = value;
            }
        }
        public int ItemsCount => _items.Count;
        public int TotalPages => (_items.Count + _pageSize - 1) / _pageSize;
        public IEnumerable<T> CurrentPageOfItems => _items.Skip(_currentPageIndex * _pageSize).Take(_pageSize);
        public PaginationService(List<T> items, int pageSize)
        {
            _items = items;
            _pageSize = pageSize;
        }

        public IEnumerable<T> SetCurrentPage(int pageNumber)
        {
            CurrentPageNumber = pageNumber;
            return CurrentPageOfItems;
        }
        public IEnumerable<T> NextPage()
        {
            if (_currentPageIndex < TotalPages - 1)
            {
                _currentPageIndex++;
            }

            return CurrentPageOfItems;
        }
        public IEnumerable<T> PreviousPage()
        {
            if (_currentPageIndex > 0)
            {
                _currentPageIndex--;
            }

            return CurrentPageOfItems;
        }
        public void UpdateNavigationButtons(Button nextBtn, Button previousBtn)
        {
            nextBtn.IsEnabled = _currentPageIndex < (_items.Count / _pageSize);
            previousBtn.IsEnabled = _currentPageIndex > 0;
        }
    }
}
