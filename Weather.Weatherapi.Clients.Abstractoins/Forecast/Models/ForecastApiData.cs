using System.Text.Json.Serialization;

namespace Weather.Weatherapi.Clients.Abstractoins.Forecast.Models
{
    /// <summary>
    /// Прогноз погоды
    /// </summary>
    public class ForecastApiData
    {
        [JsonPropertyName("forecastday")]
        public List<ForecastDayApiData>? ForecastDays { get; set; }
    }
}
