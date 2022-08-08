using System.Collections.Generic;

namespace ActionRpg.Core.Cache
{
    public interface ICache<T>
    {
        X Get<X>(string key);
        Dictionary<string, X> GetMappedValues<X>(IEnumerable<string> keys);
        X[] GetValues<X>(IEnumerable<string> keys);
        bool Set<X>(string key, X value, int? TTL = null);
        bool Delete(string key);
        bool Exists(string key);
        long Count(string key);
    }
}
