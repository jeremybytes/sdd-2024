using System.Windows;

namespace BookListViewer;

public partial class MainWindow : Window
{
    private BookViewModel viewModel = new();

    public MainWindow()
    {
        InitializeComponent();
        DataContext = viewModel;
    }

    private void ResetListButton_Click(object sender, RoutedEventArgs e)
    {
        viewModel.ResetFilterAndSort();
    }
}
