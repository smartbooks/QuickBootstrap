using System;

namespace WY.Extendsions
{
    public static class DateTimeExtendsions
    {
        public static int ToUnixTimeStamp(this DateTime dateTime)
        {
            var startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1, 0, 0, 0, 0));
            return (int)(dateTime - startTime).TotalSeconds;
        }

        public static DateTime ToDateTime(this long unixTimeStamp, int millisecond = 0)
        {
            var dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1, 0, 0, 0, millisecond));
            var toNow = new TimeSpan(unixTimeStamp);
            return dtStart.Add(toNow);
        }

        public static DateTime ToDateTime(this string unixTimeStamp, int millisecond = 0)
        {
            return ToDateTime(long.Parse(unixTimeStamp + "0000000"), millisecond);
        }

        /// <summary>
        /// 一年中第几季度
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static int ToSeason(this DateTime dateTime)
        {
            if (dateTime.Month >= 1 && dateTime.Month <= 3)
            {
                return 1;
            }

            if (dateTime.Month >= 4 && dateTime.Month <= 6)
            {
                return 2;
            }

            if (dateTime.Month >= 7 && dateTime.Month <= 9)
            {
                return 3;
            }

            if (dateTime.Month >= 10 && dateTime.Month <= 12)
            {
                return 4;
            }

            return 0;
        }

        /// <summary>
        /// 一年中第几周
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static int ToWeek(this DateTime dateTime)
        {
            if (dateTime.DayOfYear % 7 == 0)
            {
                return dateTime.DayOfYear / 7;
            }

            return (dateTime.DayOfYear / 7) + 1;
        }

        /// <summary>
        /// 一小时内第几刻钟
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static int ToQuarterHour(this DateTime dateTime)
        {
            if (dateTime.Minute >= 0 && dateTime.Minute < 15)
            {
                return 1;
            }

            if (dateTime.Minute >= 15 && dateTime.Minute < 30)
            {
                return 2;
            }


            if (dateTime.Minute >= 30 && dateTime.Minute < 45)
            {
                return 3;
            }

            if (dateTime.Minute >= 45 && dateTime.Minute < 59)
            {
                return 4;
            }

            return 0;
        }
    }
}