using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INT.Service.ZKemkeeper.Conveters
{
    public static class ZKemDateConverter
    {
        public static string DateFormat = "{0}-{1}-{2} {3}:{4}:{5}";

        public static DateTime ConvertToDate(int year, int month, int day, int hour, int minutes, int seconds)
        {
            var dateToConvert =
                string.Format(DateFormat,
                    year.ToString()
                        , CompleteTime(month.ToString())
                        , CompleteTime(day.ToString())
                        , CompleteTime(hour.ToString())
                        , CompleteTime(minutes.ToString())
                        , CompleteTime(seconds.ToString()));
            var date = Convert.ToDateTime(dateToConvert);
            return date;
        }

        private static string CompleteTime(string timeValue)
        {
            if (!string.IsNullOrWhiteSpace(timeValue) && timeValue.Length > 1)
                return timeValue;
            return timeValue.PadLeft(2, '0');
        }
    }
}
