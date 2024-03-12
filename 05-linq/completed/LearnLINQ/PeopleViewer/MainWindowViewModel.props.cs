using System.ComponentModel;

namespace PeopleViewer;

internal partial class MainWindowViewModel : INotifyPropertyChanged
{
    private bool dateFilterChecked;
    public bool DateFilterChecked
    {
        get => dateFilterChecked;
        set { dateFilterChecked = value; UpdateFilterAndSort(); }
    }

    private int dateFilterStartYear;
    public int DateFilterStartYear
    {
        get => dateFilterStartYear;
        set { dateFilterStartYear = value; UpdateFilterAndSort(); }
    }

    private int dateFilterEndYear;
    public int DateFilterEndYear
    {
        get => dateFilterEndYear;
        set { dateFilterEndYear = value; UpdateFilterAndSort(); }
    }

    private bool nameFilterChecked;
    public bool NameFilterChecked
    {
        get => nameFilterChecked;
        set { nameFilterChecked = value; UpdateFilterAndSort(); }
    }

    private string nameFilterValue;
    public string NameFilterValue
    {
        get => nameFilterValue;
        set { nameFilterValue = value; UpdateFilterAndSort(); }
    }

    private bool familyNameSortChecked;
    public bool FamilyNameSortChecked
    {
        get => familyNameSortChecked;
        set
        {
            familyNameSortChecked = value;
            UpdateFilterAndSort();
        }
    }

    private bool givenNameSortChecked;
    public bool GivenNameSortChecked
    {
        get => givenNameSortChecked;
        set
        {
            givenNameSortChecked = value;
            UpdateFilterAndSort();
        }
    }

    private bool startDateSortChecked;
    public bool StartDateSortChecked
    {
        get => startDateSortChecked;
        set
        {
            startDateSortChecked = value;
            UpdateFilterAndSort();
        }
    }

    private bool ratingSortChecked;
    public bool RatingSortChecked
    {
        get => ratingSortChecked;
        set
        {
            ratingSortChecked = value;
            UpdateFilterAndSort();
        }
    }

    #region INotifyPropertyChanged Members

    public event PropertyChangedEventHandler? PropertyChanged;
    private void RaisePropertyChanged(string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    #endregion
}
