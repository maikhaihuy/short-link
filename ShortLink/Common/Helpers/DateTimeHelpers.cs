using System;

namespace ShortLink.Common.Helpers
{
    public static class DateTimeHelpers
    {
        public static int GetTimestamp(DateTime dateTime) => (int) dateTime.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
    }
}