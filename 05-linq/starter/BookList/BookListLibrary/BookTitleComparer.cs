namespace BookList.Library;

public class BookTitleComparer : IComparer<string>
{
    public int Compare(string? x, string? y)
    {
        x = StripArticles(x);
        y = StripArticles(y);

        return x?.CompareTo(y) ?? 0;
    }

    private string? StripArticles(string? title)
    {
        return title?.Split(' ')?[0] switch
        {
            "The" => title.Remove(0, 4),
            "A" => title.Remove(0, 2),
            "An" => title.Remove(0, 3),
            _ => title
        };
    }
}
