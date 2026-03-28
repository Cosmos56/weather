using Microsoft.Extensions.Configuration;
using Weather.Infrastructure.DependencyInjection;
using Weather.Weatherapi.Clients.Abstractoins.Forecast;
using Weather.Weatherapi.Clients.Abstractoins.Forecast.Models;

namespace Weather.Weatherapi.Clients.Forecast
{
    [InjectAsTransient(typeof(IWeatherapiClient))]
    internal class WeatherapiClient(BaseWebClient webClient, IConfiguration config) : IWeatherapiClient
    {
        private readonly string? host = config.GetSection("WeatherApi:Host").Value;
        private readonly string? apiKey = Environment.GetEnvironmentVariable("WEATHER_API_KEY");

        public async Task<WeatherForecastResponseApiData> GetForecast(int dayCount, double lat, double lon, CancellationToken cancellationToken)
        {
            const string Method = "/v1/forecast.json";
            var paramtrs = $"?lang=ru&days={dayCount}&q={lat.ToString().Replace(",", ".")},{lon.ToString().Replace(",", ".")}&key={apiKey}";
            var response = await webClient.GetAsync($"{host + Method + paramtrs}", cancellationToken);
            var result = response.FromJsonString<WeatherForecastResponseApiData>();
            return result;
        }
    }
}
