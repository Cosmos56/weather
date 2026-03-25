using Newtonsoft.Json;

namespace Weather.Weatherapi.Clients.Abstractoins.Forecast.Models
{
    /// <summary>
    /// Прогноз погоды
    /// </summary>
    public class ForecastApiData
    {
        [JsonProperty("forecastday")]
        public List<ForecastDayApiData>? ForecastDays { get; set; }
    }
}
