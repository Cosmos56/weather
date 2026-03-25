using Weather.Infrastructure.DependencyInjection;
using Weather.Weatherapi.Clients.Abstractoins.Forecast;
using Weather.Weatherapi.Clients.Abstractoins.Forecast.Models;

namespace Weather.Weatherapi.Clients.Forecast
{
    [InjectAsSingleton(typeof(IWeatherapiClient))]
    internal class WeatherapiClient(WebClient webClient) : IWeatherapiClient
    {
        private const string Key = "fa8b3df74d4042b9aa7135114252304";
        private const string Host = "http://api.weatherapi.com";
        public async Task<WeatherForecastResponseApiData> GetForecast(int dayCount, double lat, double lon, CancellationToken cancellationToken)
        {
            const string Method = "/v1/forecast.json";
            var paramtrs = $"?lang=ru&days={dayCount}&q={lat.ToString().Replace(",", ".")},{lon.ToString().Replace(",", ".")}&key={Key}";
            var response = await webClient.GetAsync($"{Host+Method+paramtrs}", cancellationToken);
            var result = response.FromJsonString<WeatherForecastResponseApiData>();
            return result;
        }
    }
}
