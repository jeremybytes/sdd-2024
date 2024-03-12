using BookList.Library;

namespace BookList;

class Program
{
    static void Main(string[] args)
    {
        var fileName = AppDomain.CurrentDomain.BaseDirectory + "book_list.json";
        var books = Loader.LoadJsonData(fileName);

        // Raw book list
        //var bookList = books;

        // Science Fiction Books
        var filtered = books.Where(b => b.Bookshelves?.Contains("owned-sci-fi") ?? false);
        //var bookList = filteredBooks;

        // Ordered by Author
        //var sorted = filtered.OrderBy(b => b.Author);
        //var bookList = sorted;

        // Filtered to Single Author
        //filtered = filtered.Where(b => b.Author.Contains("Brunner", StringComparison.CurrentCultureIgnoreCase));
        //var bookList = filtered;

        // Ordered by Title
        //var sorted = filtered.OrderBy(b => b.Title);
        //var sorted = filtered.OrderBy(b => b.Title, new BookTitleComparer());
        //var bookList = sorted;

        // 1970s books
        filtered = filtered.Where(b => (b.OriginalPublicationYear >= 1970 &&
                                       b.OriginalPublicationYear <= 1979)); //.WithMessage("filter 1970s"));
        //var bookList = filtered;

        // Sorted by Author / Title
        var sorted = filtered.OrderBy(b => b.Author).ThenBy(b => b.Title, new BookTitleComparer());
        //var bookList = sorted;

        // Show Books
        //foreach (var book in bookList)
        //{
        //    Console.WriteLine(Formatter.GetFullBookOutput(book));
        //    //Console.WriteLine(Formatter.GetTitleOutput(book));
        //}
        //Console.WriteLine("=======================");
        //Console.WriteLine($"Total books: {books.Count()}");
        //Console.WriteLine($"Filtered books: {bookList.Count()}");


        // Group by Author
        var grouped = sorted.GroupBy(b => b.Author);
        foreach(var group in grouped)
        {
            Console.WriteLine(Formatter.GetAuthorGroupOutput(group));
            var averageRatingForAuthor = group.Average(b => b.MyRating);
            if (averageRatingForAuthor > 0)
                Console.WriteLine($"   || Average rating: {averageRatingForAuthor:#.##} ||");
        }
        Console.WriteLine("=======================");
        Console.WriteLine($"Fitered books: {sorted.Count()}");
        Console.WriteLine($"Total authors: {grouped.Count()}");

    }
}
