using System.Text.Json.Serialization;

namespace Weather.Weatherapi.Clients.Abstractoins.Forecast.Models
{
    /// <summary>
    /// Прогноз погоды
    /// </summary>
    public class Forecast
    {
        [JsonPropertyName("forecastday")]
        public List<ForecastDay>? ForecastDays { get; set; }
    }
}
