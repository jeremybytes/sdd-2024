using BookList.Library;
using System.ComponentModel;

namespace MobileBookViewer;

public class LaserViewModel : INotifyPropertyChanged
{
    private List<LaserBook>? allBooks;

    private List<LaserBook>? books;
    public List<LaserBook>? Books
    {
        get { return books; }
        set
        {
            books = value;
            RaisePropertyChanged(nameof(Books));
        }
    }

    private bool notOwned = false;
    public bool NotOwned
    {
        get { return notOwned; }
        set
        {
            notOwned = value;
            UpdateFilterAndSort();
        }
    }

    private string? sortValue;
    public string SortValue
    {
        get { return sortValue ?? "Number"; }
        set
        {
            sortValue = value;
            UpdateFilterAndSort();
        }
    }

    public async Task Initialize()
    {
        allBooks = (await BookLoader.LoadLaserJsonData("laser_books.json"))?
                   .OrderBy(b => b.Number)
                   .ToList();
        books = allBooks;
        Books = books;
    }

    private void UpdateFilterAndSort()
    {
        var filtered = notOwned switch 
        { 
            true => allBooks!.Where(b => b.Owned == !notOwned),
            false => allBooks!,
        };
            
        var sorted = sortValue switch 
        {
            "Author" => filtered?.OrderBy(b => b.Author).ThenBy(b => b.Number),
            "Number" => filtered?.OrderBy(b => b.Number),
            _ => filtered?.OrderBy(b => b.Number),
        };
        books = sorted?.ToList();
        RaisePropertyChanged();
    }

    #region INotifyPropertyChanged Members

    public event PropertyChangedEventHandler? PropertyChanged;
    private void RaisePropertyChanged(string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    #endregion
}
