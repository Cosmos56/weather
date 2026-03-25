using Weather.Business.Abstractions.Forecast.Models;

namespace Weather.Business.Abstractions.Forecast
{
    public interface IForecastGetter
    {
        Task<ForecastModel> GetAsync();
    }
}
