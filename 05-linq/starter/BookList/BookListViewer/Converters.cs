using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace BookListViewer;

/// <summary>
/// For more information on the Value Converters, please
/// see the "Data Templates and Value Converters" demo available
/// at http://www.jeremybytes.com/Demos.aspx
/// </summary>
public class DecadeConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        int year = ((DateTime)value).Year;
        return string.Format($"{year.ToString()[..3]}0s");
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

public class RatingConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        int rating = (int)value;
        return string.Format($"{rating}/10 Stars");
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

public class RatingStarConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        int rating = (int)value;
        string output = string.Empty;
        return output.PadLeft(rating, '*');
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        string input = (string)value;
        return input.Count(c => c == '*');
    }
}

public class DecadeBrushConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        int decade = (((DateTime)value).Year / 10) * 10;

        return decade switch
        {
            1970 => new SolidColorBrush(Colors.Maroon),
            1980 => new SolidColorBrush(Colors.DarkGreen),
            1990 => new SolidColorBrush(Colors.DarkSlateBlue),
            2000 => new SolidColorBrush(Colors.CadetBlue),
            2010 => new SolidColorBrush(Colors.DarkMagenta),
            _ => new SolidColorBrush(Colors.DarkSlateGray),
        };
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

public enum BookTemplate
{
    FlatAuthor,
    FlatTitle,
    FlatYear,
    AuthorTitleGroup,
    AuthorYearGoup,
    YearAuthorGroup,
    YearTitleGroup,
}

public class DataTemplateConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        BookTemplate template = (BookTemplate)value;
        return template switch
        {
            BookTemplate.FlatAuthor => (DataTemplate)Application.Current.FindResource("FlatAuthorTemplate"),
            BookTemplate.FlatTitle => (DataTemplate)Application.Current.FindResource("FlatTitleTemplate"),
            BookTemplate.FlatYear => (DataTemplate)Application.Current.FindResource("FlatYearTemplate"),
            BookTemplate.AuthorTitleGroup => (DataTemplate)Application.Current.FindResource("AuthorTitleGroupTemplate"),
            BookTemplate.AuthorYearGoup => (DataTemplate)Application.Current.FindResource("AuthorYearGroupTemplate"),
            BookTemplate.YearAuthorGroup => (DataTemplate)Application.Current.FindResource("YearAuthorTemplate"),
            BookTemplate.YearTitleGroup => (DataTemplate)Application.Current.FindResource("YearTitleTemplate"),
            _ => (DataTemplate)Application.Current.FindResource("BookListTemplate"),
        } ;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

public class ReadConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        string shelf = (string)value;

        return shelf switch
        {
            "read" => "R",
            "to-read" => " ",
            _ => "",
        };
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
