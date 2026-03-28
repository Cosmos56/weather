using Weather.Business.Abstractions.Forecast;
using Weather.Business.Abstractions.Forecast.Models;
using Weather.DataAccess.Abstractions.Forecast;
using Weather.Infrastructure.DependencyInjection;

namespace Weather.Business.Forecast
{
    [InjectAsTransient(typeof(IForecastGetter))]
    internal class ForecastGetter(IForecastDao dao) : IForecastGetter
    {
        public async Task<ForecastModel> GetForecast(int dayCount, double lat, double lon, CancellationToken cancellationToken = default)
        {
            var result = await dao.GetForecast(dayCount, lat, lon, cancellationToken);
            return result.ToModel();
        }
    }
}
