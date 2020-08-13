using Newtonsoft.Json;
using System;

namespace Safeon.Systems.Utils.Extensions
{
    public static class JsonExtension
    {
        public static T JsonTo<T>(this string json, JsonSerializerSettings settings)
        {
            return JsonConvert.DeserializeObject<T>(json, settings);
        }

        public static T JsonTo<T>(this string json)
        {
            var config = new JsonSerializerSettings();
            config.DateTimeZoneHandling = DateTimeZoneHandling.Local;
            return JsonConvert.DeserializeObject<T>(json, config);
        }

        public static T JsonTo<T>(this string json, DateTimeZoneHandling timeZoneHandling)
        {
            var config = new JsonSerializerSettings();
            config.DateTimeZoneHandling = timeZoneHandling;
            return JsonConvert.DeserializeObject<T>(json, config);
        }

        public static T TryJsonPara<T>(this string json)
            where T : class
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static string ToJson(this object objeto)
        {
            return JsonConvert.SerializeObject(objeto);
        }

        public static string ToJson(this object objeto, DateTimeZoneHandling timeZoneHandling)
        {
            var config = new JsonSerializerSettings();
            config.DateTimeZoneHandling = timeZoneHandling;
            return JsonConvert.SerializeObject(objeto, config);
        }

        public static string ToJson(this object objeto, ReferenceLoopHandling referenceLoopHandling)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.ReferenceLoopHandling = referenceLoopHandling;
            return ToJson(objeto, settings);
        }

        public static string ToJson(this object objeto, JsonSerializerSettings settings)
        {
            return JsonConvert.SerializeObject(objeto, settings);
        }
    }
}
