using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace WhatsAppDemo.Common
{
    public static class Extensions
    {
        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");

        public static DateTime FromTimeStampToDateTime(this string jsontimestamp)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);

            return origin.AddSeconds(Convert.ToDouble(jsontimestamp));
        }

    }
}
