using System.Text.Json.Serialization;

namespace Weather.Weatherapi.Clients.Abstractoins.Forecast.Models
{
    /// <summary>
    /// Корневой объект ответа WeatherAPI Forecast
    /// </summary>
    public class WeatherForecastResponse
    {
        [JsonPropertyName("location")]
        public Location? Location { get; set; }

        [JsonPropertyName("current")]
        public CurrentWeather? Current { get; set; }

        [JsonPropertyName("forecast")]
        public Forecast? Forecast { get; set; }
    }
}
