namespace BookList;

public static class ConsoleExtension
{
    public static T WithMessage<T>(this T data, string message)
    {
        Console.WriteLine(message);
        return data;
    }
}
