using PersonReader.Interface;
using PersonReader.Service;
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
        ClearListBox();

        IPersonReader reader = new ServiceReader();

        var people = await reader.GetPeople();
        foreach (var person in people)
            PersonListBox.Items.Add(person);

        ShowReaderType(reader);
    }

    private async void CSVButton_Click(object sender, RoutedEventArgs e)
    {
        await Task.Delay(1);
    }

    private async void SQLButton_Click(object sender, RoutedEventArgs e)
    {
        await Task.Delay(1);
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
