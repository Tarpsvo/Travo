using System;

namespace Travo.BLL.Helpers
{
    public static class DateTimeConverter
    {
        public static long ConvertToUnixTimestamp(DateTime date)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan diff = date.ToUniversalTime() - origin;
            return (long) diff.TotalSeconds;
        }
    }
}
