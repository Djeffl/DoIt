using System;
using System.Globalization;

namespace DoIt.Client.Extensions
{
    public static class DateFormatExtensions
    {
        public static string ToStringFormat(this DateTime date)
        {
            return date.ToString("d", CultureInfo.CreateSpecificCulture("de-DE"));
        }

        public static string ToStringFormat(this DayOfWeek dayOfWeek)
        {
            CultureInfo english = new CultureInfo("en-US");
            return (english.DateTimeFormat.DayNames[(int)dayOfWeek]).Substring(0, 2);
        }

        public static string ToDayOfMonthStringFormat(this DateTime date)
        {
            CultureInfo english = new CultureInfo("en-US");
            return (english.DateTimeFormat.MonthNames[(int)date.Month-1]);
        }
    }
}
