using HouseControl.Sunset;

namespace HouseControl.Library;

public class ScheduleHelper
{
    private readonly ISunsetProvider SunsetProvider;

    public ScheduleHelper(ISunsetProvider sunsetProvider)
    {
        this.SunsetProvider = sunsetProvider;
    }

    public static bool IsInFuture(DateTimeOffset checkTime)
    {
        return checkTime > DateTimeOffset.Now;
    }

    public DateTimeOffset RollForwardToNextDay(ScheduleInfo info)
    {
        if (IsInFuture(info.EventTime))
            return info.EventTime;

        var nextDay = DateTimeOffset.Now.Date.AddDays(1);
        return info.TimeType switch
        {
            ScheduleTimeType.Standard => nextDay + info.EventTime.TimeOfDay + info.RelativeOffset,
            ScheduleTimeType.Sunset => SunsetProvider.GetSunset(nextDay) + info.RelativeOffset,
            ScheduleTimeType.Sunrise => SunsetProvider.GetSunrise(nextDay) + info.RelativeOffset,
            _ => info.EventTime
        };
    }

    public DateTimeOffset RollForwardToNextWeekdayDay(ScheduleInfo info)
    {
        if (IsInFuture(info.EventTime))
            return info.EventTime;

        var nextDay = DateTimeOffset.Now.Date + TimeSpan.FromDays(1);
        while (nextDay.DayOfWeek == DayOfWeek.Saturday
            || nextDay.DayOfWeek == DayOfWeek.Sunday)
        {
            nextDay = nextDay.AddDays(1);
        }

        return info.TimeType switch
        {
            ScheduleTimeType.Standard => nextDay + info.EventTime.TimeOfDay + info.RelativeOffset,
            ScheduleTimeType.Sunset => SunsetProvider.GetSunset(nextDay) + info.RelativeOffset,
            ScheduleTimeType.Sunrise => SunsetProvider.GetSunrise(nextDay) + info.RelativeOffset,
            _ => info.EventTime
        };
    }

    public DateTimeOffset RollForwardToNextWeekendDay(ScheduleInfo info)
    {
        if (IsInFuture(info.EventTime))
            return info.EventTime;

        var nextDay = DateTimeOffset.Now.Date.AddDays(1);
        while (nextDay.DayOfWeek != DayOfWeek.Saturday
            && nextDay.DayOfWeek != DayOfWeek.Sunday)
        {
            nextDay = nextDay.AddDays(1);
        }
        return info.TimeType switch
        {
            ScheduleTimeType.Standard => nextDay + info.EventTime.TimeOfDay + info.RelativeOffset,
            ScheduleTimeType.Sunset => SunsetProvider.GetSunset(nextDay) + info.RelativeOffset,
            ScheduleTimeType.Sunrise => SunsetProvider.GetSunrise(nextDay) + info.RelativeOffset,
            _ => info.EventTime
        };
    }
}
