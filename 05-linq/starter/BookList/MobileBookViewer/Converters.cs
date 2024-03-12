using BookList.Library;
using System.Globalization;

namespace MobileBookViewer;

public class ReadConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        string shelf = (string?)value ?? "";

        return shelf switch
        {
            "read" => "Read",
            "to-read" => "To Be Read",
            _ => "",
        };
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

public class RatingConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        int rating = (int?)value ?? 0;

        return rating switch
        {
            1 => "*    ",
            2 => "**   ",
            3 => "***  ",
            4 => "**** ",
            5 => "*****",
            _ => "     ",
        };
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

public class ShelvesConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        Book? book = (Book?)value;
        if (book is null) return "";
        return book.GetShelves();
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

public class PagesConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        int pages = (int?)value ?? 0;
        return pages switch
        {
            0 => "",
            _ => $"pp. {pages}",
        };
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

public class DateReadConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        DateOnly? read = (DateOnly?)value;
        if (read is null) return "";
        return $"Date Read: {read:MM/dd/yyyy}";
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

public class LaserOwnedConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        bool read = (bool?)value ?? false;
        return read switch
        {
            true => "Owned",
            false => "Not Owned",
        };
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
