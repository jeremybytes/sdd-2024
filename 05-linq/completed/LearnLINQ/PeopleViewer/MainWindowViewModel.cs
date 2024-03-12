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

        if (NameFilterChecked)
        {
            //People = Enumerable.Where(People, SelectPerson);
            //People = People.Where(SelectPerson);
            People = People.Where(p => p.GivenName == NameFilterValue);
        }

        if (DateFilterChecked)
            People = People.Where(p => p.StartDate.Year >= DateFilterStartYear)
                           .Where(p => p.StartDate.Year <= DateFilterEndYear);

        if (FamilyNameSortChecked)
            People = People.OrderBy(p => p.FamilyName);

        if (GivenNameSortChecked)
            People = People.OrderBy(p => p.GivenName).ThenBy(p => p.FamilyName);

        if (StartDateSortChecked)
            People = People.OrderBy(p => p.StartDate);

        if (RatingSortChecked)
            People = People.OrderByDescending(p => p.Rating);

        RaisePropertyChanged();
    }

    //private bool SelectPerson(Person person)
    //{
    //    return person.GivenName == NameFilterValue;
    //}

    public void ShowAverageRating()
    {
        var average = People.Average(p => p.Rating).ToString("#.#");
        ShowPopup("Average Rating", average);
    }

    public void ShowEarliestStartDate()
    {
        var earliest = People.Min(p => p.StartDate).ToString("MM/dd/yyyy");
        ShowPopup("Earliest Start Date", earliest);
    }

    public void ShowBestCommander()
    {
        var best = People.MaxBy(p => p.Rating);
        ShowPopup("Best Commander", best!.ToString());
    }
}
