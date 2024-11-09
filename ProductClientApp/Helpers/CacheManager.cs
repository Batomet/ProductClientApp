using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductClientApp.Helpers
{
    public static class CacheManager
    {
        private static readonly Dictionary<string, (DateTimeOffset time, object data)> Cache = new();

        public static void Set(string key, object data, TimeSpan duration)
        {
            Cache[key] = (DateTimeOffset.Now.Add(duration), data);
        }

        public static object Get(string key)
        {
            if (Cache.ContainsKey(key) && Cache[key].time > DateTimeOffset.Now)
            {
                return Cache[key].data;
            }
            return null;
        }

        public static void Remove(string key)
        {
            Cache.Remove(key);
        }
    }
}