using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web.Script.Serialization;

namespace BasicFramework.Common
{
    public static class EnumerableExtension
    {
        //public static void Each<T>(this IEnumerable<T> collection, Action<T> action)
        //{
        //    if (collection == null)
        //    {
        //        return;
        //    }

        //    foreach (var o in collection)
        //    {
        //        action(o);
        //    }
        //}

        public static DataTable ConverToDataTableWithAnEmptyRow(this IEnumerable<string> collection)
        {
            DataTable dt = collection.ConverToEmptyDataTable();

            dt.Rows.Add(dt.NewRow());

            return dt;
        }

        public static DataTable ConverToEmptyDataTable(this IEnumerable<string> collection)
        {
            DataTable dt = new DataTable();

            collection.Each((i, name) => dt.Columns.Add(name, typeof(string)));

            return dt;
        }

        public static DataTable ConverToTable<T>(this IEnumerable<T> collection, DataTable dt)
        {
            if (collection == null || !collection.Any())
            {
                return dt;
            }

            IEnumerable<PropertyInfo> properties = typeof(T).GetProperties();

            foreach (T entity in collection)
            {
                DataRow dr = dt.NewRow();
                foreach (PropertyInfo property in properties)
                {
                    var attributes = property.GetCustomAttributes(typeof(EntityPropertyExtensionAttribute), false);

                    if (attributes != null && attributes.Any())
                    {
                        EntityPropertyExtensionAttribute attribute = (EntityPropertyExtensionAttribute)attributes.First();

                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            if (dt.Columns[i].ColumnName == attribute.ViewTableColumnName)
                            {
                                object val = property.GetValue(entity, null);

                                if (val == null)
                                {
                                    dr[dt.Columns[i].ColumnName] = string.Empty;
                                    break;
                                }

                                if (!string.IsNullOrEmpty(attribute.ToStringVal))
                                {
                                    MethodInfo mInfo = property.PropertyType.GetMethod("ToString",
                                        BindingFlags.Public | BindingFlags.Instance,
                                        null,
                                        CallingConventions.Any,
                                        new Type[] { typeof(string) },
                                        null);

                                    if (mInfo != null)
                                    {
                                        dr[dt.Columns[i].ColumnName] = mInfo.Invoke(val, new[] { attribute.ToStringVal });
                                    }
                                    else
                                    {
                                        dr[dt.Columns[i].ColumnName] = val.ToString();
                                    }
                                }
                                else
                                {
                                    dr[dt.Columns[i].ColumnName] = val.ToString();
                                }

                                break;
                            }
                        }
                    }
                }

                dt.Rows.Add(dr);
            }

            return dt;
        }

        public static void Each<T>(this IEnumerable<T> collection, Action<int, T> action)
        {
            if (collection == null)
            {
                return;
            }

            int i = 0;

            foreach (var o in collection)
            {
                action(i++, o);
            }
        }

        public static IEnumerable<R> Each<T,R>(this IEnumerable<T> collection, Func<int,T,R> func)
        {
            if (collection == null)
            {
                return Enumerable.Empty<R>();
            }

            int i = 0;
            IList<R> returnList = new List<R>();
            foreach (var o in collection)
            {
                var returnval = func(i++, o);
                if (returnval != null)
                {
                    returnList.Add(returnval);
                }
            }

            return returnList;
        }

        /// <summary>
        /// 将List转为datatable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable dt = new DataTable();
            for (int i = 0; i < properties.Count; i++)
            {
                PropertyDescriptor property = properties[i];
                dt.Columns.Add(property.Name, property.PropertyType);
            }
            object[] values = new object[properties.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = properties[i].GetValue(item);
                }
                dt.Rows.Add(values);
            }
            return dt;
        }


        /// <summary>
        /// 将IEnumerable转为datatable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static DataTable ToDataTable<T>(this IEnumerable<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable dt = new DataTable();
            for (int i = 0; i < properties.Count; i++)
            {
                PropertyDescriptor property = properties[i];
                dt.Columns.Add(property.Name);
            }
            object[] values = new object[properties.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = properties[i].GetValue(item);
                }
                dt.Rows.Add(values);
            }
            return dt;
        }
    }
}