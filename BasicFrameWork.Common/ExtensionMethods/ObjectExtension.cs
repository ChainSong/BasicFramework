using System;
using System.ComponentModel;
using System.Configuration;
using System.Text;
using System.Web.Configuration;
using System.Web.Script.Serialization;

namespace BasicFramework.Common
{
    public static class ObjectExtension
    {
        public static object ConvertSimpleType(this object value, Type destinationType)
        {
            object returnValue;

            if ((value == null) || destinationType.IsInstanceOfType(value))
            {
                return value;
            }

            string str = value as string;

            if ((str != null) && (str.Length == 0))
            {
                return null;
            }

            TypeConverter converter = TypeDescriptor.GetConverter(destinationType);

            bool flag = converter.CanConvertFrom(value.GetType());

            if (!flag)
            {
                converter = TypeDescriptor.GetConverter(value.GetType());
            }

            if (!flag && !converter.CanConvertTo(destinationType))
            {
                return destinationType.IsValueType ? Activator.CreateInstance(destinationType) : null;
            }

            try
            {
                returnValue = flag ? converter.ConvertFrom(null, null, value) : converter.ConvertTo(null, null, value, destinationType);
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("类型转换出错：" + value.ToString() + "==>" + destinationType, e);
            }

            return returnValue;
        }

        public static string DateTimeToString(this DateTime t, string format = null)
        {
            return t.ToString(format ?? "yyyy-MM-dd");
        }

        public static string DateTimeToString(this DateTime? t, string format = null)
        {
            return t.HasValue ? DateTimeToString(t.Value, format) : string.Empty;
        }

        public static string DecimalToString(this decimal t)
        {
            return t.ToString("#,###.##");
        }

        public static string DecimalToString(this decimal? t)
        {
            return t.HasValue ? DecimalToString(t.Value) : string.Empty;
        }

        public static T FromJsonStringTo<T>(this string str)
        {
            var serializer = new JavaScriptSerializer();
            return serializer.Deserialize<T>(str);
        }

        public static bool ObjectToBoolean(this object obj)
        {
            return DBNull.Value.Equals(obj) ? false : Convert.ToBoolean(obj);
        }

        public static DateTime ObjectToDateTime(this object obj)
        {
            return DBNull.Value.Equals(obj) ? DateTime.MinValue : Convert.ToDateTime(obj);
        }

        public static decimal ObjectToDecimal(this object obj)
        {
            return DBNull.Value.Equals(obj) ? 0 : string.IsNullOrEmpty(obj.ToString()) ? 0 : Convert.ToDecimal(obj);
        }

        public static double ObjectToDouble(this object obj)
        {
            return DBNull.Value.Equals(obj) ? 0 : string.IsNullOrEmpty(obj.ToString()) ? 0 : Convert.ToDouble(obj);
        }
        public static double? ToDouble(this object obj)
        {
            if (string.IsNullOrEmpty(obj.ToString()))
            {
                return 0;
            }
            else
            {
                return Convert.ToDouble(obj);
            }
                   
        }

        public static Int32 ObjectToInt32(this object obj)
        {
            return DBNull.Value.Equals(obj) ? 0 : string.IsNullOrEmpty(obj.ToString()) ? 0 : Convert.ToInt32(obj);
        }

        public static Int64 ObjectToInt64(this object obj)
        {
            return DBNull.Value.Equals(obj) ? 0 : string.IsNullOrEmpty(obj.ToString()) ? 0 : Convert.ToInt64(obj);
        }

        public static bool? ObjectToNullableBoolean(this object obj)
        {
            return obj == null || DBNull.Value.Equals(obj) ? null : (bool?)Convert.ToBoolean(obj);
        }

        public static DateTime? ObjectToNullableDateTime(this object obj)
        {
            return obj == null || DBNull.Value.Equals(obj) ? null : (DateTime?)Convert.ToDateTime(obj);
        }

        public static decimal? ObjectToNullableDecimal(this object obj)
        {
            return obj == null || DBNull.Value.Equals(obj) ? null : (decimal?)Convert.ToDecimal(obj);
        }

        public static double? ObjectToNullableDouble(this object obj)
        {
            return obj == null || DBNull.Value.Equals(obj) ? null : (double?)Convert.ToDouble(obj);
        }

        public static Guid? ObjectToNullableGuid(this object obj)
        {
            return obj == null || DBNull.Value.Equals(obj) ? null : (Guid?)obj;
        }

        public static Int32? ObjectToNullableInt32(this object obj)
        {
            return obj == null || DBNull.Value.Equals(obj) ? null : (Int32?)Convert.ToInt32(obj);
        }

        public static Int64? ObjectToNullableInt64(this object obj)
        {
            return obj == null || DBNull.Value.Equals(obj) ? null : (Int64?)Convert.ToInt64(obj);
        }

        public static string ObjectToString(this object obj)
        {
            return obj == null || DBNull.Value.Equals(obj) ? string.Empty : obj.ToString();
        }

        public static string ToJsonString(this object obj)
        {
            var serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = 20971520;
            return serializer.Serialize(obj);
        }

        public static string ToUtf8String(this string s)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (c >= 0 && c <= 255)
                {
                    sb.Append(c);
                }
                else
                {
                    byte[] b;
                    try
                    {
                        b = Encoding.UTF8.GetBytes(c.ToString());
                    }
                    catch (Exception ex)
                    {
                        b = new byte[0];
                    }
                    for (int j = 0; j < b.Length; j++)
                    {
                        int k = b[j];
                        if (k < 0) k += 256;

                        sb.Append("%" + Convert.ToString(k, 16).ToUpper());
                    }
                }
            }
            return sb.ToString();
        }

        public static string YearMonth(this DateTime t)
        {
            return t.ToString("yyyy-MM");
        }

        public static string YearMonthDay(this DateTime t)
        {
            return t.ToString("yyyy-MM-dd");
        }

        public static bool IsStartWithChineseLetter(this string str)
        {
            int code = 0;
            int chfrom = Convert.ToInt32("4e00", 16); //范围（0x4e00～0x9fff）转换成int（chfrom～chend）
            int chend = Convert.ToInt32("9fff", 16);
            if (!string.IsNullOrEmpty(str))
            {
                code = Char.ConvertToUtf32(str, 0); //获得字符串input中指定索引index处字符unicode编码

                if (code >= chfrom && code <= chend)
                {
                    return true; //当code在中文范围内返回true
                }
                else
                {
                    return false; //当code不在中文范围内返回false
                }
            }
            return false;
        }
    }
}