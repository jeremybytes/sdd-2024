namespace MobileBookViewer;

public partial class LaserBooksPage : ContentPage
{
    LaserViewModel viewModel = new();

    public LaserBooksPage()
	{
		InitializeComponent();
        LoadAfterConstruction();
    }

    private async void LoadAfterConstruction()
    {
        await viewModel.Initialize();
        this.BindingContext = viewModel;
    }
}