using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;

namespace ActionRpg.Core.Cache
{
    public class MemCache : ICache<MemoryCache>
    {
        MemoryCache cache { get; set; }

        public MemCache(string cacheName)
        {
            cache = new MemoryCache(cacheName);
        }

        public bool Delete(string key)
        {
            if (Exists(key))
            {
                var removedItem = cache.Remove(key);
                return removedItem != null;
            }
            return true;
        }

        public X Get<X>(string key)
        {
            if (Exists(key))
            {
                return (X)cache.Get(key);
            }
            return default;
        }
        public Dictionary<string, X> GetMappedValues<X>(IEnumerable<string> keys)
        {
            return cache.GetValues(keys).ToDictionary(x => x.Key, x => (X)x.Value);
        }

        public X[] GetValues<X>(IEnumerable<string> keys)
        {
            return cache.GetValues(keys).Select(x => (X)x.Value).ToArray();
        }


        public bool Set<X>(string key, X value, int? TTL = null)
        {
            var cacheItem = new CacheItem(key, value);
            var cacheItemPolicy = new CacheItemPolicy { };
            if (TTL != null)
            {
                cacheItemPolicy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(TTL.Value);
            }
            return cache.Add(cacheItem, cacheItemPolicy);
        }

        public bool Exists(string key)
        {
            return cache.Contains(key);
        }

        public long Count(string key)
        {
            return cache.GetCount(key);
        }
    }
}
