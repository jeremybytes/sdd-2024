using System.Text.Json;
using System.Text.Json.Serialization;

namespace BookList.Library;

public class Loader
{
    public static List<Book> LoadJsonData(string fileName)
    {
        var output = new List<Book>();
        var options = new JsonSerializerOptions()
        {
            Converters = { new BookShelfConverter(), new BookDateConverter() },
        };

        if (File.Exists(fileName))
        {
            using var reader = new StreamReader(fileName);
            output = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(
                reader.ReadToEnd(), options);
        }

        return output!;
    }
}

public class BookShelfConverter : JsonConverter<Shelves?>
{
    public override Shelves? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        var value = reader.GetString();
        if (string.IsNullOrEmpty(value)) return null;
        var items = value.Split(", ");
        Shelves shelves = new(items);
        return shelves;
    }

    public override void Write(
        Utf8JsonWriter writer,
        Shelves? shelvesValue,
        JsonSerializerOptions options) => throw new NotImplementedException();
}

public class BookDateConverter : JsonConverter<DateOnly?>
{
    public override DateOnly? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        var value = reader.GetString();
        if (string.IsNullOrEmpty(value)) return null;
        DateOnly? date = DateOnly.Parse(value);
        return date;
    }

    public override void Write(
        Utf8JsonWriter writer,
        DateOnly? dateOnlyValue,
        JsonSerializerOptions options) => throw new NotImplementedException();
}

public class LaserBookOwnedConverter : JsonConverter<bool>
{
    public override bool Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        var value = reader.GetString();
        if (string.IsNullOrEmpty(value)) return false;
        bool owned = value == "true" ? true : false;
        return owned;
    }

    public override void Write(
        Utf8JsonWriter writer,
        bool laserOwnedValue,
        JsonSerializerOptions options) => throw new NotImplementedException();
}