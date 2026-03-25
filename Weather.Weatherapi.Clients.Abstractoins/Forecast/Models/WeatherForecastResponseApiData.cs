using Newtonsoft.Json;

namespace Weather.Weatherapi.Clients.Abstractoins.Forecast.Models
{
    /// <summary>
    /// Корневой объект ответа WeatherAPI Forecast
    /// </summary>
    public class WeatherForecastResponseApiData
    {
        [JsonProperty("location")]
        public LocationApiData? Location { get; set; }

        [JsonProperty("current")]
        public CurrentWeatherApiData? Current { get; set; }

        [JsonProperty("forecast")]
        public ForecastApiData? Forecast { get; set; }
    }
}
