using PersonReader.CSV;
using PersonReader.Interface;
using PersonReader.Service;
using PersonReader.SQL;
using System.Windows;

namespace PeopleViewer;

public partial class PeopleViewerWindow : Window
{
    public PeopleViewerWindow()
    {
        InitializeComponent();
    }

    private async void ServiceButton_Click(object sender, RoutedEventArgs e)
    {
        await FetchData(new ServiceReader());
    }

    private async void CSVButton_Click(object sender, RoutedEventArgs e)
    {
        await FetchData(new CSVReader());
    }

    private async void SQLButton_Click(object sender, RoutedEventArgs e)
    {
        await FetchData(new SQLReader());
    }

    private async Task FetchData(IPersonReader reader)
    {
        ClearListBox();

        var people = await reader.GetPeople();
        foreach (var person in people)
            PersonListBox.Items.Add(person);

        ShowReaderType(reader);
    }

    private void ClearButton_Click(object sender, RoutedEventArgs e)
    {
        ClearListBox();
    }

    private void ShowReaderType(IPersonReader reader)
    {
        ReaderTypeTextBlock.Text = reader.GetType().ToString();
    }

    private void ClearReaderType()
    {
        ReaderTypeTextBlock.Text = string.Empty;
    }

    private void ClearListBox()
    {
        PersonListBox.Items.Clear();
        ClearReaderType();
    }
}
