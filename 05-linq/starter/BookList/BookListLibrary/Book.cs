namespace BookList.Library;

public record LaserBook(
    int Number,
    string Title,
    string Author,
    bool Owned)
{ }

public record Book(
    int BookId, 
    string Title, 
    string Author,
    int? OriginalPublicationYear, 
    int? NumberOfPages, 
    Shelves? Bookshelves, 
    string ExclusiveShelf,
    int? MyRating, 
    DateOnly? DateRead)
{
    public override string ToString()
    {
        string output = $"{Author} - {Title}";
        output += $"\n  {OriginalPublicationYear?.ToString() ?? "Unknown Date"} - pp {NumberOfPages?.ToString() ?? "Unknown"}";
        if (DateRead is not null)
            output += $"\n  Read: {DateRead:yyyy/MM/dd}";
        output += $"\n  Shelves: {GetShelves()} - Exclusive: {ExclusiveShelf}";
        return output;
    }

    public string GetShelves()
    {
        string output = string.Empty;
        if (Bookshelves is not null && Bookshelves.Count > 0)
        {
            output = Bookshelves[0];
            foreach (var shelf in Bookshelves.Skip(1))
            {
                output += ", " + shelf;
            }
        }
        return output;
    }
}

public class Shelves : List<string>
{
    public Shelves()
        : base() { }

    public Shelves(IEnumerable<string> items)
    {
        this.AddRange(items);
    }
}