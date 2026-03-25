using Newtonsoft.Json;

namespace Weather.Weatherapi.Clients.Abstractoins.Forecast.Models
{
    /// <summary>
    /// Погодное условие (текст, иконка, код)
    /// </summary>
    public class WeatherConditionApiData
    {
        [JsonProperty("text")]
        public string? Text { get; set; }

        [JsonProperty("icon")]
        public string? IconUrl { get; set; }

        [JsonProperty("code")]
        public int Code { get; set; }
    }
}
