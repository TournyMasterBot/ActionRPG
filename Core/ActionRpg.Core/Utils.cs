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

        /// <summary>
        /// Todo : Create random name
        /// </summary>
        public static string CreateName()
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
