using Weather.Weatherapi.Clients.Abstractoins.Forecast.Models;

namespace Weather.Weatherapi.Clients.Abstractoins.Forecast
{
    public interface IWeatherapiClient
    {
        Task<WeatherForecastResponse> GetForecast(int dayCount, double lat, double lon, CancellationToken cancellationToken);
    }
}
