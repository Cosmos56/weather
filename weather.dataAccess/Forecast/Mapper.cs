
using Microsoft.VisualBasic;
using System.Globalization;
using Weather.DataAccess.Abstractions.Forecast.Models;
using Weather.Weatherapi.Clients.Abstractoins.Forecast.Models;

namespace Weather.DataAccess.Forecast
{
    internal static class Mapper
    {
        public static ForecastDaoModel ToDaoModel(this WeatherForecastResponseApiData? apiData)
        {
            if (apiData == null)
                throw new Exception("Нет данных.");

            return new ForecastDaoModel
            { 
                Location = apiData.Location?.Name ?? throw new Exception("Наименование местоположения пусто"),
                Daily = apiData.ToDaily()
            };
        }

        private static IReadOnlyCollection<DailyForecastDaoModel> ToDaily(this WeatherForecastResponseApiData? apiData)
        {
            var result = new List<DailyForecastDaoModel>();

            if (apiData?.Forecast?.ForecastDays == null)
                throw new Exception("ForecastDays is empty.");

            if (!DateTime.TryParse(apiData.Current?.LastUpdated, out var currentDate))
                throw new Exception("LastUpdated TryParse error.");

            foreach (var dayData in apiData.Forecast.ForecastDays)
            {
                if (!DateTime.TryParse(dayData.Date, out var date))
                    throw new Exception("LastUpdated TryParse error.");

                var daily = new DailyForecastDaoModel
                {
                    Date = DateOnly.FromDateTime(date),
                    Temperature = Convert.ToInt32(dayData.Day?.AvgTempCelsius ?? throw new Exception("Day AvgTempCelsius is empty")) ,
                    FeelsLike = date.Day == currentDate.Day ? Convert.ToInt32(apiData.Current?.FeelsLikeCelsius) : null,
                    Condition = dayData.Day.Condition?.Text ?? throw new Exception("Day Condition is empty"),
                    Hourly = dayData.Hourly?.Select(ToHourly).ToList() ?? throw new Exception("Day Hourly is empty")
                };
                result.Add(daily);
            }
            return result;
        }

        private static HourlyForecastDaoModel ToHourly(this HourlyForecastApiData hourlyData)
        {
            if (hourlyData == null)
                throw new Exception("hourlyData is empty.");

            if (!DateTime.TryParse(hourlyData.Time, out var currentDate))
                throw new Exception("hourlyData.Time TryParse error.");

            return new HourlyForecastDaoModel
            {
                Time = TimeOnly.FromDateTime(currentDate),
                Temperature = Convert.ToInt32(hourlyData.TemperatureCelsius),
                Condition = hourlyData.Condition?.Text ?? throw new Exception("hourlyData Condition is empty")
            };
        }
    }
}
