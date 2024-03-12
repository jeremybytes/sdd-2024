using PeopleViewer.Library;
using System.ComponentModel;

namespace PeopleViewer;

internal partial class MainWindowViewModel : INotifyPropertyChanged
{
    private IEnumerable<Person> cachedPeople = new List<Person>();

    public IEnumerable<Person> People { get; private set; }

    public MainWindowViewModel()
    {
        dateFilterStartYear = 1985;
        dateFilterEndYear = 2000;
        nameFilterValue = "John";
        People = cachedPeople;
        RefreshData();
    }

    public void RefreshData()
    {
        cachedPeople = PeopleReader.GetPeople();
        ResetFilterAndSort();
    }

    private void ResetFilterAndSort()
    {
        familyNameSortChecked = false;
        givenNameSortChecked = false;
        startDateSortChecked = false;
        ratingSortChecked = false;
        dateFilterChecked = false;
        nameFilterChecked = false;
        UpdateFilterAndSort();
    }

    private void UpdateFilterAndSort()
    {
        People = cachedPeople;

        RaisePropertyChanged();
    }

    public void ShowAverageRating()
    {

    }

    public void ShowEarliestStartDate()
    {

    }

    public void ShowBestCommander()
    {

    }
}
