using System;
using System.Web;
using System.Web.Caching;

namespace BasicFramework.Common
{
    public class CacheHelper
    {
        private static Cache cache;

        public static double SaveTime { get; set; }

        static CacheHelper()
        {
            cache = HttpContext.Current.Cache;
            SaveTime = 15.0;
        }

        public static object Get(string key)
        {
            return cache.Get(key);
        }

        public static object Remove(string key)
        {
            return cache.Remove(key);
        }

        public static object Get(string key, Action action)
        {
            object obj = cache.Get(key);
            if (null == obj)
            {
                action();
                obj = cache.Get(key);
            }
            return obj;
        }

        public static T Get<T>(string key)
        {
            object obj = Get(key);
            if (obj == null)
                return default(T);
            else
                return (T)obj;
        }

        public static void Insert(string key, object value, CacheDependency dependency, CacheItemPriority priority, CacheItemRemovedCallback callback)
        {
            cache.Insert(key, value, dependency, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(SaveTime), priority, callback);
        }

        public static void Insert(string key, object value, CacheDependency dependency, CacheItemRemovedCallback callback)
        {
            Insert(key, value, dependency, CacheItemPriority.Default, callback);
        }

        public static void Insert(string key, object value, CacheDependency dependency)
        {
            Insert(key, value, dependency, CacheItemPriority.Default, null);
        }

        public static void Insert(string key, object value)
        {
            Insert(key, value, null, CacheItemPriority.Default, null);
        }
    }
}