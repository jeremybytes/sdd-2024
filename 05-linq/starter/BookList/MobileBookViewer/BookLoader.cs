using BookList.Library;
using System.Text.Json;

namespace MobileBookViewer;

public static class BookLoader
{
    public static async Task<List<Book>?> LoadJsonData(string fileName)
    {
        List<Book>? output;
        JsonSerializerOptions options = new()
        {
            Converters = { new BookShelfConverter(), new BookDateConverter() },
        };

        using var stream = await FileSystem.OpenAppPackageFileAsync(fileName);
        using var reader = new StreamReader(stream);

        string content = await reader.ReadToEndAsync();

        output = JsonSerializer.Deserialize<List<Book>>(content, options);

        return output ?? [];
    }

    public static async Task<List<LaserBook>?> LoadLaserJsonData(string fileName)
    {
        List<LaserBook>? output;
        JsonSerializerOptions options = new()
        {
            Converters = { new LaserBookOwnedConverter() },
        };

        using var stream = await FileSystem.OpenAppPackageFileAsync(fileName);
        using var reader = new StreamReader(stream);

        string content = await reader.ReadToEndAsync();

        output = JsonSerializer.Deserialize<List<LaserBook>>(content, options);

        return output ?? [];
    }


}
