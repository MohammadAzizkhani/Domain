using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public static string GetSequenceNumber()
        {
            var seqNo = Interlocked.Increment(ref _sequenceNumber);

            var result = $"{DateTime.Now:MMddHHmmss}{seqNo:000000}";

            return result;
        }

    }
}
