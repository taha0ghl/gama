using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace MyClass
{
    public enum PersianDayOfWeek
    {
        Shanbe = 1,
        Yekshanbe = 2,
        Doshanbe = 3,
        Seshanbe = 4,
        Charshanbe = 5,
        Panjshanbe = 6,
        Jome = 7
    }
    public static class DateTimeManager
    {
        private static readonly PersianCalendar calendar = new PersianCalendar();

        public static string GetDate(DateTime dateTime)
        {
            string output;

            string day = Convert.ToString(calendar.GetDayOfMonth(dateTime));
            string mounth = Convert.ToString(calendar.GetMonth(dateTime));

            day = (day.Length == 1) ? "0" + day : day;
            mounth = (mounth.Length == 1) ? "0" + mounth : mounth;

            string year = Convert.ToString(calendar.GetYear(dateTime));

            output = string.Format("{0}/{1}/{2}", year, mounth, day);

            return output;
        }
        public static string GetTime(DateTime dateTime)
        {
            string output;

            string seconde = Convert.ToString(dateTime.Second);
            string minute = Convert.ToString(dateTime.Minute);

            seconde = (seconde.Length == 1) ? "0" + seconde : seconde;
            minute = (minute.Length == 1) ? "0" + minute : minute;

            string hour = Convert.ToString(dateTime.Hour);
            hour = (hour.Length == 1) ? "0" + hour : hour;

            output = string.Format("{0}:{1}:{2}", hour, minute, seconde);

            return output;
        }
        public static PersianDayOfWeek PersionDayOfWeek(this DayOfWeek date)
        {
            switch (date)
            {
                case DayOfWeek.Saturday:
                    return PersianDayOfWeek.Shanbe;
                case DayOfWeek.Sunday:
                    return PersianDayOfWeek.Yekshanbe;
                case DayOfWeek.Monday:
                    return PersianDayOfWeek.Doshanbe;
                case DayOfWeek.Tuesday:
                    return PersianDayOfWeek.Seshanbe;
                case DayOfWeek.Wednesday:
                    return PersianDayOfWeek.Charshanbe;
                case DayOfWeek.Thursday:
                    return PersianDayOfWeek.Panjshanbe;
                case DayOfWeek.Friday:
                    return PersianDayOfWeek.Jome;
                default:
                    throw new Exception();
            }
        }
    }
}
