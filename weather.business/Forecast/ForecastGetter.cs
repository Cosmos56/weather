using Weather.Business.Abstractions.Forecast;
using Weather.Business.Abstractions.Forecast.Models;
using Weather.Infrastructure.DependencyInjection;

namespace Weather.Business.Forecast
{
    [InjectAsSingleton(typeof(IForecastGetter))]
    public class ForecastGetter : IForecastGetter
    {
        public Task<ForecastModel> GetAsync()
        {
            throw new NotImplementedException();
        }
    }
}
