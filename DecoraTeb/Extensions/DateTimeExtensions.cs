using System.Globalization;

namespace DecoraTeb.Extensions;

public static class DateTimeExtensions
{
    private static readonly PersianCalendar PersianCalendar = new();

    public static string ToShamsi(this DateTime dateTime)
    {
        return $"{PersianCalendar.GetYear(dateTime):0000}/" +
               $"{PersianCalendar.GetMonth(dateTime):00}/" +
               $"{PersianCalendar.GetDayOfMonth(dateTime):00}";
    }

    public static string ToShamsiDateTime(this DateTime dateTime)
    {
        return $"{PersianCalendar.GetYear(dateTime):0000}/" +
               $"{PersianCalendar.GetMonth(dateTime):00}/" +
               $"{PersianCalendar.GetDayOfMonth(dateTime):00} " +
               $"{dateTime:HH:mm}";
    }

    public static string ToShamsiFull(this DateTime dateTime)
    {
        string[] days =
        {
            "یکشنبه",
            "دوشنبه",
            "سه شنبه",
            "چهارشنبه",
            "پنجشنبه",
            "جمعه",
            "شنبه"
        };

        return $"{days[(int)dateTime.DayOfWeek]} {PersianCalendar.GetDayOfMonth(dateTime):00}/" +
               $"{PersianCalendar.GetMonth(dateTime):00}/" +
               $"{PersianCalendar.GetYear(dateTime):0000}";
    }
}
