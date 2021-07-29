using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Utility
{
    public static class Utilities
    {

        private static int _sequenceNumber;
        public static String GetEnumDescription(this Enum value)
        {
            if (value == null)
            {
                return null;
            }
            var description = GetAttribute<DescriptionAttribute>(value);
            return description?.Description;
        }
        private static TAttribute GetAttribute<TAttribute>(this Enum value)
            where TAttribute : Attribute
        {
            var type = value.GetType();
            var name = Enum.GetName(type, value);
            if (name == null)
                return null;
            return type.GetField(name).GetCustomAttributes(false).OfType<TAttribute>().SingleOrDefault();
        }

        public static string ConvertToPersianDate(this DateTime date, bool showTime = false)
        {
            if (date <= DateTime.MinValue)
                return "";
            var persianCalendar = new PersianCalendar();
            int dayOfMonth = persianCalendar.GetDayOfMonth(date);
            int month = persianCalendar.GetMonth(date);
            int year = persianCalendar.GetYear(date);
            int hour = persianCalendar.GetHour(date);
            int minute = persianCalendar.GetMinute(date);
            int second = persianCalendar.GetSecond(date);
            string str1 = persianCalendar.GetDayOfMonth(date).CompareTo(10) >= 0 ? dayOfMonth.ToString() : "0" + (object)dayOfMonth;
            string str2 = persianCalendar.GetMonth(date).CompareTo(10) >= 0 ? month.ToString() : "0" + (object)month;
            if (!showTime)
                return $"{(object)year}/{(object)str2}/{(object)str1}";
            return
                $"{(object)year}/{(object)str2}/{(object)str1} {(hour < 10 ? "0" : "")}{ hour}:{(minute < 10 ? "0" : "")}{(object)minute}:{(second < 10 ? "0" : "")}{(object)second}";
        }

        public static string GetSequenceNumber()
        {
            var seqNo = Interlocked.Increment(ref _sequenceNumber);

            var result = $"{DateTime.Now:MMddHHmmss}{seqNo:000000}";

            return result;
        }

    }
}
