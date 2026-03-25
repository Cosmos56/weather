using System.Text.Json.Serialization;

namespace Weather.Weatherapi.Clients.Abstractoins.Forecast.Models
{
    /// <summary>
    /// Погодное условие (текст, иконка, код)
    /// </summary>
    public class WeatherCondition
    {
        [JsonPropertyName("text")]
        public string? Text { get; set; }

        [JsonPropertyName("icon")]
        public string? IconUrl { get; set; }

        [JsonPropertyName("code")]
        public int Code { get; set; }
    }
}
