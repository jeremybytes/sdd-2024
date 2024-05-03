using System.Runtime.CompilerServices;

namespace HouseControl.Sunset;

public class CachingSunsetProvider : ISunsetProvider
{
    private readonly ISunsetProvider wrappedProvider;

    public CachingSunsetProvider(ISunsetProvider sunsetProvider)
    {
        wrappedProvider = sunsetProvider;
    }

    private DateTime dataDate;
    private DateTimeOffset sunrise;
    private DateTimeOffset sunset;

    private void ValidateCache(DateTime date)
    {
        if (dataDate != date)
        {
            sunrise = wrappedProvider.GetSunrise(date);
            sunset = wrappedProvider.GetSunset(date);
            dataDate = date;
        }
    }

    public DateTimeOffset GetSunrise(DateTime date)
    {
        ValidateCache(date);
        return sunrise;
    }

    public DateTimeOffset GetSunset(DateTime date)
    {
        ValidateCache(date);
        return sunset;
    }
}
