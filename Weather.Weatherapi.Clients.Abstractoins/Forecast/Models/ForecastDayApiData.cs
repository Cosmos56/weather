using Newtonsoft.Json;

namespace Weather.Weatherapi.Clients.Abstractoins.Forecast.Models
{
    /// <summary>
    /// Прогноз на один день
    /// </summary>
    public class ForecastDayApiData
    {
        [JsonProperty("date")]
        public string? Date { get; set; }

        [JsonProperty("date_epoch")]
        public long DateEpoch { get; set; }

        [JsonProperty("day")]
        public DayForecastApiData? Day { get; set; }

        [JsonProperty("astro")]
        public AstronomyApiData? Astronomy { get; set; }

        [JsonProperty("hour")]
        public List<HourlyForecastApiData>? Hourly { get; set; }
    }
}
