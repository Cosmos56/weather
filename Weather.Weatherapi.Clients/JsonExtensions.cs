using Newtonsoft.Json;

namespace Weather.Weatherapi.Clients
{
    public static class JsonExtensions
    {
        public static string ToJsonString(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static T FromJsonString<T>(this string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}