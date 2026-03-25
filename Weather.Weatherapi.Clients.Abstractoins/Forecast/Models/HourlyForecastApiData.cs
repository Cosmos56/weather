using Newtonsoft.Json;

namespace Weather.Weatherapi.Clients.Abstractoins.Forecast.Models
{
    /// <summary>
    /// Почасовой прогноз
    /// </summary>
    public class HourlyForecastApiData
    {
        [JsonProperty("time_epoch")]
        public long TimeEpoch { get; set; }

        [JsonProperty("time")]
        public string? Time { get; set; }

        [JsonProperty("temp_c")]
        public decimal TemperatureCelsius { get; set; }

        [JsonProperty("temp_f")]
        public decimal TemperatureFahrenheit { get; set; }

        [JsonProperty("is_day")]
        public int IsDay { get; set; }

        [JsonProperty("condition")]
        public WeatherConditionApiData? Condition { get; set; }

        [JsonProperty("wind_mph")]
        public decimal WindMph { get; set; }

        [JsonProperty("wind_kph")]
        public decimal WindKph { get; set; }

        [JsonProperty("wind_degree")]
        public int WindDegree { get; set; }

        [JsonProperty("wind_dir")]
        public string? WindDirection { get; set; }

        [JsonProperty("pressure_mb")]
        public decimal PressureMb { get; set; }

        [JsonProperty("pressure_in")]
        public decimal PressureIn { get; set; }

        [JsonProperty("precip_mm")]
        public decimal PrecipMm { get; set; }

        [JsonProperty("precip_in")]
        public decimal PrecipIn { get; set; }

        [JsonProperty("snow_cm")]
        public decimal SnowCm { get; set; }

        [JsonProperty("humidity")]
        public int Humidity { get; set; }

        [JsonProperty("cloud")]
        public int Cloud { get; set; }

        [JsonProperty("feelslike_c")]
        public decimal FeelsLikeCelsius { get; set; }

        [JsonProperty("feelslike_f")]
        public decimal FeelsLikeFahrenheit { get; set; }

        [JsonProperty("windchill_c")]
        public decimal WindChillCelsius { get; set; }

        [JsonProperty("windchill_f")]
        public decimal WindChillFahrenheit { get; set; }

        [JsonProperty("heatindex_c")]
        public decimal HeatIndexCelsius { get; set; }

        [JsonProperty("heatindex_f")]
        public decimal HeatIndexFahrenheit { get; set; }

        [JsonProperty("dewpoint_c")]
        public decimal DewPointCelsius { get; set; }

        [JsonProperty("dewpoint_f")]
        public decimal DewPointFahrenheit { get; set; }

        [JsonProperty("will_it_rain")]
        public int WillItRain { get; set; }

        [JsonProperty("chance_of_rain")]
        public int ChanceOfRain { get; set; }

        [JsonProperty("will_it_snow")]
        public int WillItSnow { get; set; }

        [JsonProperty("chance_of_snow")]
        public int ChanceOfSnow { get; set; }

        [JsonProperty("vis_km")]
        public decimal VisibilityKm { get; set; }

        [JsonProperty("vis_miles")]
        public decimal VisibilityMiles { get; set; }

        [JsonProperty("gust_mph")]
        public decimal GustMph { get; set; }

        [JsonProperty("gust_kph")]
        public decimal GustKph { get; set; }

        [JsonProperty("uv")]
        public decimal UvIndex { get; set; }
    }
}
