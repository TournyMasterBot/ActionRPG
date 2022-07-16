using Newtonsoft.Json;
using System;

namespace ActionRpg.Core
{
    public static class Utils
    {
        public static string CreateIdentifier()
        {
            return Guid.NewGuid().ToString("d");
        }

        public static string ToJson<T>(this T obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }

        public static T ToModel<T>(this string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
