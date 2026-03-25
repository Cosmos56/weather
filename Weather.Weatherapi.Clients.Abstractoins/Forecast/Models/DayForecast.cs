using System.Text.Json.Serialization;

namespace Weather.Weatherapi.Clients.Abstractoins.Forecast.Models
{
    /// <summary>
    /// Сводка погоды за день
    /// </summary>
    public class DayForecast
    {
        [JsonPropertyName("maxtemp_c")]
        public decimal MaxTempCelsius { get; set; }

        [JsonPropertyName("maxtemp_f")]
        public decimal MaxTempFahrenheit { get; set; }

        [JsonPropertyName("mintemp_c")]
        public decimal MinTempCelsius { get; set; }

        [JsonPropertyName("mintemp_f")]
        public decimal MinTempFahrenheit { get; set; }

        [JsonPropertyName("avgtemp_c")]
        public decimal AvgTempCelsius { get; set; }

        [JsonPropertyName("avgtemp_f")]
        public decimal AvgTempFahrenheit { get; set; }

        [JsonPropertyName("maxwind_mph")]
        public decimal MaxWindMph { get; set; }

        [JsonPropertyName("maxwind_kph")]
        public decimal MaxWindKph { get; set; }

        [JsonPropertyName("totalprecip_mm")]
        public decimal TotalPrecipMm { get; set; }

        [JsonPropertyName("totalprecip_in")]
        public decimal TotalPrecipIn { get; set; }

        [JsonPropertyName("totalsnow_cm")]
        public decimal TotalSnowCm { get; set; }

        [JsonPropertyName("avgvis_km")]
        public decimal AvgVisibilityKm { get; set; }

        [JsonPropertyName("avgvis_miles")]
        public decimal AvgVisibilityMiles { get; set; }

        [JsonPropertyName("avghumidity")]
        public int AvgHumidity { get; set; }

        [JsonPropertyName("daily_will_it_rain")]
        public int DailyWillItRain { get; set; }

        [JsonPropertyName("daily_chance_of_rain")]
        public int DailyChanceOfRain { get; set; }

        [JsonPropertyName("daily_will_it_snow")]
        public int DailyWillItSnow { get; set; }

        [JsonPropertyName("daily_chance_of_snow")]
        public int DailyChanceOfSnow { get; set; }

        [JsonPropertyName("condition")]
        public WeatherCondition? Condition { get; set; }

        [JsonPropertyName("uv")]
        public decimal UvIndex { get; set; }
    }
}
