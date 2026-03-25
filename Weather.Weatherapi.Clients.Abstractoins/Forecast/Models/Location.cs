using System.Text.Json.Serialization;

namespace Weather.Weatherapi.Clients.Abstractoins.Forecast.Models
{
    /// <summary>
    /// Информация о локации
    /// </summary>
    public class Location
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("region")]
        public string? Region { get; set; }

        [JsonPropertyName("country")]
        public string? Country { get; set; }

        [JsonPropertyName("lat")]
        public decimal Latitude { get; set; }

        [JsonPropertyName("lon")]
        public decimal Longitude { get; set; }

        [JsonPropertyName("tz_id")]
        public string? TimeZoneId { get; set; }

        [JsonPropertyName("localtime_epoch")]
        public long LocalTimeEpoch { get; set; }

        [JsonPropertyName("localtime")]
        public string? LocalTime { get; set; }
    }
}
