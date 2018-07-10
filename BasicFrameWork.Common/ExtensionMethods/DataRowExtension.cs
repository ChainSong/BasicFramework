using System;
using System.Data;

namespace BasicFramework.Common
{
    public static class DataRowExtension
    {
        public static bool? Boolean(this DataRow row, string name)
        {
            return row[name].ObjectToNullableBoolean();
        }

        public static DateTime? DateTime(this DataRow row, string name)
        {
            return row[name].ObjectToNullableDateTime();
        }

        public static decimal? Decimal(this DataRow row, string name)
        {
            return row[name].ObjectToNullableDecimal();
        }

        public static double? Double(this DataRow row, string name)
        {
            return row[name].ObjectToNullableDouble();
        }

        public static Guid? Guid(this DataRow row, string name)
        {
            return row[name].ObjectToNullableGuid();
        }

        public static int? Int32(this DataRow row, string name)
        {
            return row[name].ObjectToNullableInt32();
        }

        public static long? Int64(this DataRow row, string name)
        {
            return row[name].ObjectToNullableInt64();
        }

        public static string String(this DataRow row, string name)
        {
            return row[name].ObjectToString();
        }
    }
}