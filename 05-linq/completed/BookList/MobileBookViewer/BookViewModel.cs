using BookList.Library;
using System.ComponentModel;
using System.Windows.Input;

namespace MobileBookViewer;

public class BookViewModel : INotifyPropertyChanged
{
    private BookTitleComparer titleComparer = new();
    private int page = 0;

    private string searchText = "";
    public string SearchText
    {
        get { return searchText; }
        set
        {
            searchText = value;
            UpdateSearch();
            RaisePropertyChanged(nameof(SearchText));
        }
    }

    private List<Book>? allBooks;
    private List<Book>? defaultBooks;

    private List<Book>? books;
    public List<Book>? Books
    {
        get { return books; }
        set
        {
            books = value;
            RaisePropertyChanged(nameof(Books));
        }
    }

    public async Task Initialize()
    {
        allBooks = (await BookLoader.LoadJsonData("book_list.json"))?
                   .Where(b => b.Bookshelves?.Contains("owned-sci-fi") ?? false)
                   .OrderBy(b => b.Author).ThenBy(b => b.Title, titleComparer)
                   .ToList();
        defaultBooks = allBooks?.Take(20).ToList();
        Books = defaultBooks;
    }

    public ICommand PerformSearch => 
        new Command<string>((string searchText) => SearchText = searchText);

    public void UpdateSearch()
    {
        if (string.IsNullOrEmpty(searchText) || string.IsNullOrWhiteSpace(searchText))
        {
            Books = defaultBooks;
            return;
        }

        Books = allBooks?.Where(b => b.Author.Contains(searchText, StringComparison.CurrentCultureIgnoreCase) ||
                                     b.Title.Contains(searchText, StringComparison.CurrentCultureIgnoreCase))
                         .Take(100)
                         .ToList();
    }

    #region INotifyPropertyChanged Members

    public event PropertyChangedEventHandler? PropertyChanged;
    private void RaisePropertyChanged(string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    #endregion
}
