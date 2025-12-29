using System;
using System.Collections.Generic;
using System.Text;

namespace TechnicalStation.Core.Domain.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime RoundToSeconds(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second);
        }
    }
}
