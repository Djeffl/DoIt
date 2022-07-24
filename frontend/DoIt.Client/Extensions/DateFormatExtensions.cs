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
    }
}
