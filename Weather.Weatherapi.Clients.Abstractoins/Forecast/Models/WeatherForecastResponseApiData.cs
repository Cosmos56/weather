using System.Text.Json.Serialization;

namespace Weather.Weatherapi.Clients.Abstractoins.Forecast.Models
{
    /// <summary>
    /// Корневой объект ответа WeatherAPI Forecast
    /// </summary>
    public class WeatherForecastResponseApiData
    {
        [JsonPropertyName("location")]
        public LocationApiData? Location { get; set; }

        [JsonPropertyName("current")]
        public CurrentWeatherApiData? Current { get; set; }

        [JsonPropertyName("forecast")]
        public ForecastApiData? Forecast { get; set; }
    }
}
