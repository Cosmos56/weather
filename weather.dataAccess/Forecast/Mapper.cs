
using Weather.DataAccess.Abstractions.Forecast.Models;
using Weather.Weatherapi.Clients.Abstractoins.Forecast.Models;

namespace Weather.DataAccess.Forecast
{
    internal static class Mapper
    {
        public static ForecastDaoModel ToDaoModel(this WeatherForecastResponseApiData apiData)
        {
            return new ForecastDaoModel();
        }
    }
}
