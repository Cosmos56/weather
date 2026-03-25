using Newtonsoft.Json;

namespace Weather.Weatherapi.Clients.Abstractoins.Forecast.Models
{
    /// <summary>
    /// Информация о локации
    /// </summary>
    public class LocationApiData
    {
        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("region")]
        public string? Region { get; set; }

        [JsonProperty("country")]
        public string? Country { get; set; }

        [JsonProperty("lat")]
        public decimal Latitude { get; set; }

        [JsonProperty("lon")]
        public decimal Longitude { get; set; }

        [JsonProperty("tz_id")]
        public string? TimeZoneId { get; set; }

        [JsonProperty("localtime_epoch")]
        public long LocalTimeEpoch { get; set; }

        [JsonProperty("localtime")]
        public string? LocalTime { get; set; }
    }
}
