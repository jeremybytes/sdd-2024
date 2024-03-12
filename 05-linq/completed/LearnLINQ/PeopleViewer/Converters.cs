﻿using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace PeopleViewer;

/// <summary>
/// For more information on the Value Converters, please
/// see the "Data Templates and Value Converters" demo available
/// at http://www.jeremybytes.com/Demos.aspx
/// </summary>
public class VisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        return value switch
        {
            null => Visibility.Hidden,
            "" => Visibility.Hidden,
            _ => Visibility.Visible,
        };
    }

    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

public class DecadeConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        int year = ((DateTime)value).Year;
        return string.Format($"{year.ToString()[..3]}0s");
    }

    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

public class RatingConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        int rating = (int)value;
        return string.Format($"{rating}/10 Stars");
    }

    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

public class RatingStarConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        int rating = (int)value;
        string output = string.Empty;
        return output.PadLeft(rating, '*');
    }

    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        string input = (string)value;
        return input.Count(c => c == '*');
    }
}

public class DecadeBrushConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
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

    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
