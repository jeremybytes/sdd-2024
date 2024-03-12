using BookList.Library;

namespace BookList;

class Program
{
    static void Main(string[] args)
    {
        var fileName = AppDomain.CurrentDomain.BaseDirectory + "book_list.json";
        var books = Loader.LoadJsonData(fileName);

        // Raw book list
        var bookList = books;

        // Show books
        foreach (var book in bookList)
            Console.WriteLine(Formatter.GetFullBookOutput(book));
        Console.WriteLine("=======================");
        Console.WriteLine($"Total books: {bookList.Count()}");
    }
}
