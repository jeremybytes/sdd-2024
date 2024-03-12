using System.Windows;

namespace PeopleViewer;

public partial class MainWindow : Window
{
    MainWindowViewModel viewModel = new();

    public MainWindow()
    {
        InitializeComponent();
        DataContext = viewModel;
    }

    private void RefreshButton_Click(object sender, RoutedEventArgs e)
    {
        viewModel.RefreshData();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        viewModel.HidePopup();
    }

    private void AverageButton_Click(object sender, RoutedEventArgs e)
    {
        viewModel.ShowAverageRating();
    }

    private void BestButton_Click(object sender, RoutedEventArgs e)
    {
        viewModel.ShowBestCommander();
    }

    private void EarliestButton_Click(object sender, RoutedEventArgs e)
    {
        viewModel.ShowEarliestStartDate();
    }
}
