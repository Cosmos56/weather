using Weather.DataAccess.Abstractions.Forecast.Models;
using Weather.Weatherapi.Clients.Abstractoins.Forecast.Models;

namespace Weather.DataAccess.Forecast
{
    internal static class Mapper
    {
        public static ForecastDaoModel ToDaoModel(this WeatherForecastResponseApiData? apiData)
        {
            if (apiData == null)
                throw new Exception("No data");

            return new ForecastDaoModel
            { 
                Location = apiData.Location?.Name ?? throw new Exception("Location is empty"),
                Daily = apiData.ToDaily()
            };
        }

        private static IReadOnlyCollection<DailyForecastDaoModel> ToDaily(this WeatherForecastResponseApiData? apiData)
        {
            var result = new List<DailyForecastDaoModel>();

            if (apiData?.Forecast?.ForecastDays == null)
                throw new Exception("ForecastDays is empty.");

            if (!DateTime.TryParse(apiData.Current?.LastUpdated, out var currentDate))
                throw new Exception("Current LastUpdated TryParse error.");

            foreach (var dayData in apiData.Forecast.ForecastDays)
            {
                if (!DateTime.TryParse(dayData.Date, out var date))
                    throw new Exception("Date TryParse error.");

                var daily = new DailyForecastDaoModel
                {
                    Date = DateOnly.FromDateTime(date),
                    Temperature = date.Day == currentDate.Day 
                        ? Convert.ToInt32(apiData.Current?.TemperatureCelsius ?? throw new Exception("Day Current TemperatureCelsius is empty")) 
                        : Convert.ToInt32(dayData.Day?.AvgTempCelsius ?? throw new Exception("Day AvgTempCelsius is empty")) ,
                    FeelsLike = date.Day == currentDate.Day ? Convert.ToInt32(apiData.Current?.FeelsLikeCelsius) : null,
                    Condition = new ConditionDataDaoModel 
                        { 
                            Text = dayData.Day.Condition?.Text ?? throw new Exception("Day Condition is empty"), 
                            Icon = dayData.Day.Condition?.IconUrl ?? throw new Exception("Day Condition Icon is empty")
                        },
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
                Condition = new ConditionDataDaoModel
                {
                    Text = hourlyData.Condition?.Text ?? throw new Exception("hourlyData Condition is empty"),
                    Icon = hourlyData.Condition?.IconUrl ?? throw new Exception("hourlyData Condition Icon is empty")
                },
            };
        }
    }
}
