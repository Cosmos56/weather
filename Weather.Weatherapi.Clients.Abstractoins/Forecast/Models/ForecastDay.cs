using System.Text.Json.Serialization;

namespace Weather.Weatherapi.Clients.Abstractoins.Forecast.Models
{
    /// <summary>
    /// Прогноз на один день
    /// </summary>
    public class ForecastDay
    {
        [JsonPropertyName("date")]
        public string? Date { get; set; }

        [JsonPropertyName("date_epoch")]
        public long DateEpoch { get; set; }

        [JsonPropertyName("day")]
        public DayForecast? Day { get; set; }

        [JsonPropertyName("astro")]
        public Astronomy? Astronomy { get; set; }

        [JsonPropertyName("hour")]
        public List<HourlyForecast>? Hourly { get; set; }
    }
}
