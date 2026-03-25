using System.Text.Json.Serialization;

namespace Weather.Weatherapi.Clients.Abstractoins.Forecast.Models
{
    /// <summary>
    /// Почасовой прогноз
    /// </summary>
    public class HourlyForecast
    {
        [JsonPropertyName("time_epoch")]
        public long TimeEpoch { get; set; }

        [JsonPropertyName("time")]
        public string? Time { get; set; }

        [JsonPropertyName("temp_c")]
        public decimal TemperatureCelsius { get; set; }

        [JsonPropertyName("temp_f")]
        public decimal TemperatureFahrenheit { get; set; }

        [JsonPropertyName("is_day")]
        public int IsDay { get; set; }

        [JsonPropertyName("condition")]
        public WeatherCondition? Condition { get; set; }

        [JsonPropertyName("wind_mph")]
        public decimal WindMph { get; set; }

        [JsonPropertyName("wind_kph")]
        public decimal WindKph { get; set; }

        [JsonPropertyName("wind_degree")]
        public int WindDegree { get; set; }

        [JsonPropertyName("wind_dir")]
        public string? WindDirection { get; set; }

        [JsonPropertyName("pressure_mb")]
        public decimal PressureMb { get; set; }

        [JsonPropertyName("pressure_in")]
        public decimal PressureIn { get; set; }

        [JsonPropertyName("precip_mm")]
        public decimal PrecipMm { get; set; }

        [JsonPropertyName("precip_in")]
        public decimal PrecipIn { get; set; }

        [JsonPropertyName("snow_cm")]
        public decimal SnowCm { get; set; }

        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }

        [JsonPropertyName("cloud")]
        public int Cloud { get; set; }

        [JsonPropertyName("feelslike_c")]
        public decimal FeelsLikeCelsius { get; set; }

        [JsonPropertyName("feelslike_f")]
        public decimal FeelsLikeFahrenheit { get; set; }

        [JsonPropertyName("windchill_c")]
        public decimal WindChillCelsius { get; set; }

        [JsonPropertyName("windchill_f")]
        public decimal WindChillFahrenheit { get; set; }

        [JsonPropertyName("heatindex_c")]
        public decimal HeatIndexCelsius { get; set; }

        [JsonPropertyName("heatindex_f")]
        public decimal HeatIndexFahrenheit { get; set; }

        [JsonPropertyName("dewpoint_c")]
        public decimal DewPointCelsius { get; set; }

        [JsonPropertyName("dewpoint_f")]
        public decimal DewPointFahrenheit { get; set; }

        [JsonPropertyName("will_it_rain")]
        public int WillItRain { get; set; }

        [JsonPropertyName("chance_of_rain")]
        public int ChanceOfRain { get; set; }

        [JsonPropertyName("will_it_snow")]
        public int WillItSnow { get; set; }

        [JsonPropertyName("chance_of_snow")]
        public int ChanceOfSnow { get; set; }

        [JsonPropertyName("vis_km")]
        public decimal VisibilityKm { get; set; }

        [JsonPropertyName("vis_miles")]
        public decimal VisibilityMiles { get; set; }

        [JsonPropertyName("gust_mph")]
        public decimal GustMph { get; set; }

        [JsonPropertyName("gust_kph")]
        public decimal GustKph { get; set; }

        [JsonPropertyName("uv")]
        public decimal UvIndex { get; set; }
    }
}
