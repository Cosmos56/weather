using Newtonsoft.Json;

namespace Weather.Weatherapi.Clients.Abstractoins.Forecast.Models
{
    /// <summary>
    /// Сводка погоды за день
    /// </summary>
    public class DayForecastApiData
    {
        [JsonProperty("maxtemp_c")]
        public decimal MaxTempCelsius { get; set; }

        [JsonProperty("maxtemp_f")]
        public decimal MaxTempFahrenheit { get; set; }

        [JsonProperty("mintemp_c")]
        public decimal MinTempCelsius { get; set; }

        [JsonProperty("mintemp_f")]
        public decimal MinTempFahrenheit { get; set; }

        [JsonProperty("avgtemp_c")]
        public decimal AvgTempCelsius { get; set; }

        [JsonProperty("avgtemp_f")]
        public decimal AvgTempFahrenheit { get; set; }

        [JsonProperty("maxwind_mph")]
        public decimal MaxWindMph { get; set; }

        [JsonProperty("maxwind_kph")]
        public decimal MaxWindKph { get; set; }

        [JsonProperty("totalprecip_mm")]
        public decimal TotalPrecipMm { get; set; }

        [JsonProperty("totalprecip_in")]
        public decimal TotalPrecipIn { get; set; }

        [JsonProperty("totalsnow_cm")]
        public decimal TotalSnowCm { get; set; }

        [JsonProperty("avgvis_km")]
        public decimal AvgVisibilityKm { get; set; }

        [JsonProperty("avgvis_miles")]
        public decimal AvgVisibilityMiles { get; set; }

        [JsonProperty("avghumidity")]
        public int AvgHumidity { get; set; }

        [JsonProperty("daily_will_it_rain")]
        public int DailyWillItRain { get; set; }

        [JsonProperty("daily_chance_of_rain")]
        public int DailyChanceOfRain { get; set; }

        [JsonProperty("daily_will_it_snow")]
        public int DailyWillItSnow { get; set; }

        [JsonProperty("daily_chance_of_snow")]
        public int DailyChanceOfSnow { get; set; }

        [JsonProperty("condition")]
        public WeatherConditionApiData? Condition { get; set; }

        [JsonProperty("uv")]
        public decimal UvIndex { get; set; }
    }
}
