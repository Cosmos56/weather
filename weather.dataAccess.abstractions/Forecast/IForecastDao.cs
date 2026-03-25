using Weather.DataAccess.Abstractions.Forecast.Models;

namespace Weather.DataAccess.Abstractions.Forecast
{
    public interface IForecastDao
    {
        Task<ForecastDaoModel> GetForecast(int dayCount, double lat, double lon, CancellationToken cancellationToken);
    }
}
