using System;
using System.Collections.Generic;
using System.Data;

namespace BasicFramework.Common
{
    public static class DataRowCollectionExtension
    {
        public static void Each(this DataRowCollection collection, Action<DataRow> action)
        {
            Each(collection, (i, o) => action(o));
        }

        public static void Each(this DataRowCollection collection, Action<int, DataRow> action)
        {
            if (collection == null) return;
            int i = 0;

            foreach (DataRow o in collection)
                action(i++, o);
        }

        public static IEnumerable<T> Select<T>(this DataRowCollection collection, Func<DataRow, T> func, Action<T> thenAction = null)
        {
            return Select(collection, (i, o) => func(o), thenAction);
        }

        public static IEnumerable<T> Select<T>(this DataRowCollection collection, Func<int, DataRow, T> func, Action<T> thenAction = null)
        {
            var list = new List<T>(collection.Count);
            Each(
                collection,
                (i, o) =>
                {
                    var t = func(i, o);
                    list.Add(t);
                    if (thenAction != null)
                    {
                        thenAction(t);
                    }
                });

            return list;
        }
    }
}