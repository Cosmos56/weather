using Weather.Infrastructure.DependencyInjection;
using Weather.Infrastructure.Http;
using Weather.Weatherapi.Clients.Abstractoins.Forecast;
using Weather.Weatherapi.Clients.Abstractoins.Forecast.Models;

namespace Weather.Weatherapi.Clients.Forecast
{
    [InjectAsTransient(typeof(IWeatherapiClient))]
    internal class WeatherapiClient : ApiWebClientBase, IWeatherapiClient
    {
        public WeatherapiClient(WebClientBase webClient, ApiWebSettingsGetter settingsGetter) 
            : base(
                  webClient,
                  settingsGetter,
                  "WEATHER_API"
                  )
        {
        }

        public Task<WeatherForecastResponseApiData> GetForecastAsync(int dayCount, double lat, double lon, CancellationToken cancellationToken)
        {
            const string Method = "/v1/forecast.json";
            var paramtrs = $"?lang=ru&days={dayCount}&q={lat.ToString().Replace(",", ".")},{lon.ToString().Replace(",", ".")}";
            return GetAsync<WeatherForecastResponseApiData> ($"{Method + paramtrs}", cancellationToken);
        }
    }
}
