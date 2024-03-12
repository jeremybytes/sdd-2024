using BookList.Library;
using System.Text;

namespace BookList;

public static class Formatter
{
    public static string GetAuthorGroupOutput(IGrouping<string, Book> group)
    {
        StringBuilder result = new();
        result.AppendLine(group.Key);
        foreach (Book book in group)
        {
            result.AppendLine($"   {GetTitleOutput(book)}");
        }
        return result.ToString().Trim();
    }

    public static string GetFullBookOutput(Book book)
    {
        return $"{book.Author} - {book.Title}{GetPublicationYear(book.OriginalPublicationYear)}{GetPages(book.NumberOfPages)}{GetStars(book.MyRating)}";
    }

    public static string GetTitleOutput(Book book)
    {
        return $"{book.Title}{GetPublicationYear(book.OriginalPublicationYear)}{GetPages(book.NumberOfPages)}{GetStars(book.MyRating)}";
    }

    public static string GetPublicationYear(int? year)
    {
        if (year is null) return " (Unknown)";
        return $" ({year})";
    }

    public static string GetPages(int? pages)
    {
        if (pages is null || pages <= 0) return "";
        return $" - pp {pages}";
    }

    public static string GetReadToken(Book book) => book.ExclusiveShelf switch
    {
        "read" => " - READ",
        _ => "",
    };

    public static string GetStars(int? rating)
    {
        string output = string.Empty;
        if (rating is null) return output;
        return $" - {output.PadLeft(rating ?? 0, '*')}";
    }
}
