using System.Text.Json.Serialization;

namespace Weather.Weatherapi.Clients.Abstractoins.Forecast.Models
{
    /// <summary>
    /// Прогноз на один день
    /// </summary>
    public class ForecastDayApiData
    {
        [JsonPropertyName("date")]
        public string? Date { get; set; }

        [JsonPropertyName("date_epoch")]
        public long DateEpoch { get; set; }

        [JsonPropertyName("day")]
        public DayForecastApiData? Day { get; set; }

        [JsonPropertyName("astro")]
        public AstronomyApiData? Astronomy { get; set; }

        [JsonPropertyName("hour")]
        public List<HourlyForecastApiData>? Hourly { get; set; }
    }
}
