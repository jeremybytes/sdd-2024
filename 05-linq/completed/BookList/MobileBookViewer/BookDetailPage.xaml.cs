using BookList.Library;

namespace MobileBookViewer;

public partial class BookDetailPage : ContentPage
{
	public BookDetailPage(Book book)
	{
		InitializeComponent();
		this.BindingContext = book;
	}
}