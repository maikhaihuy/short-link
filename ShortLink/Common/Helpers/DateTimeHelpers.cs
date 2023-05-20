using System;

namespace ShortLink.Common.Helpers
{
    public static class DateTimeHelpers
    {
        public static long GetTimestamp(DateTime dateTime) => new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds();
    }
}