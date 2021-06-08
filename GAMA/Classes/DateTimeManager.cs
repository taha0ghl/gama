using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace MyClass
{
    public enum PersianDayOfWeek
    {
        شنبه = 1,
        یک_شنبه = 2,
        دو_شنبه = 3,
        سه_شنبه = 4,
        چهار_شنبه = 5,
        پنج_شنبه = 6,
        جمعه = 7
    }

    public enum PersianMonthNames
    {
        فروردین,
        اردیبهشت,
        خرداد,
        تیر,
        مرداد,
        شهریور,
        مهر,
        آبان,
        آذر,
        دی,
        بهمن,
        اسفند
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
                    return PersianDayOfWeek.شنبه;
                case DayOfWeek.Sunday:
                    return PersianDayOfWeek.یک_شنبه;
                case DayOfWeek.Monday:
                    return PersianDayOfWeek.دو_شنبه;
                case DayOfWeek.Tuesday:
                    return PersianDayOfWeek.سه_شنبه;
                case DayOfWeek.Wednesday:
                    return PersianDayOfWeek.چهار_شنبه;
                case DayOfWeek.Thursday:
                    return PersianDayOfWeek.پنج_شنبه;
                case DayOfWeek.Friday:
                    return PersianDayOfWeek.جمعه;
                default:
                    throw new Exception();
            }
        }
    }
}
