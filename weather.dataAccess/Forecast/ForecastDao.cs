using Weather.DataAccess.Abstractions.Forecast;
using Weather.DataAccess.Abstractions.Forecast.Models;
using Weather.Infrastructure.DependencyInjection;
using Weather.Weatherapi.Clients.Abstractoins.Forecast;

namespace Weather.DataAccess.Forecast
{
    [InjectAsSingleton(typeof(IForecastDao))]
    internal class ForecastDao(IWeatherapiClient weatherapiClient) : IForecastDao
    {
        public async Task<ForecastDaoModel> GetForecast(int dayCount, double lat, double lon, CancellationToken cancellationToken)
        {
            var result = await weatherapiClient.GetForecast(dayCount, lat, lon, cancellationToken);
            return result.ToDaoModel();
        }
    }
}
