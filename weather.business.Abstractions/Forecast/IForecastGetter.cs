using Weather.Business.Abstractions.Forecast.Models;

namespace Weather.Business.Abstractions.Forecast
{
    public interface IForecastGetter
    {
        Task<ForecastModel> GetForecastAsync(int dayCount, double lat, double lon, CancellationToken cancellationToken = default);
    }
}
