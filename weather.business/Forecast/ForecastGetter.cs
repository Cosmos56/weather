using Weather.Business.Abstractions.Forecast;
using Weather.Business.Abstractions.Forecast.Models;
using Weather.DataAccess.Abstractions.Forecast;
using Weather.Infrastructure.DependencyInjection;

namespace Weather.Business.Forecast
{
    [InjectAsTransient(typeof(IForecastGetter))]
    internal class ForecastGetter(IForecastDao dao) : IForecastGetter
    {
        public async Task<ForecastModel> GetForecastAsync(int dayCount, double lat, double lon, CancellationToken cancellationToken = default)
        {
            var result = await dao.GetForecastAsync(dayCount, lat, lon, cancellationToken);
            return result.ToModel();
        }
    }
}
