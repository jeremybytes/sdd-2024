using BookList.Library;
using System.ComponentModel;

namespace MobileBookViewer;

public partial class MainPage : ContentPage, INotifyPropertyChanged
{
    BookViewModel viewModel = new();

    public MainPage()
    {
        InitializeComponent();
        LoadAfterConstruction();
    }

    private async void LoadAfterConstruction()
    {
        await viewModel.Initialize();
        this.BindingContext = viewModel;
    }

    private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        SearchBar searchBar = (SearchBar)sender;
        if (searchBar.Text.Length == 0)
            viewModel.SearchText = searchBar.Text;
    }

    private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var book = ((ListView)sender).SelectedItem as Book;
        if (book is null) return;
        await Navigation.PushAsync(new BookDetailPage(book));
    }

    private async void LaserButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LaserBooksPage());
    }
}
