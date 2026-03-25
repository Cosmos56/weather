
using Weather.Business.Abstractions.Forecast.Models;
using Weather.DataAccess.Abstractions.Forecast.Models;

namespace Weather.Business.Forecast
{
    internal static class Mapper
    {
        public static ForecastModel ToModel(this ForecastDaoModel? dao)
        {
            if (dao == null)
                return null!;

            return new ForecastModel
            {
                Location = dao.Location,
                Daily = dao.Daily?.Select(d => d.ToModel()).ToArray()
                    ?? Array.Empty<DailyForecastModel>()
            };
        }

        public static DailyForecastModel ToModel(this DailyForecastDaoModel? dao)
        {
            if (dao == null)
                return null!;

            return new DailyForecastModel
            {
                Date = dao.Date,
                Temperature = dao.Temperature,
                FeelsLike = dao.FeelsLike,
                Condition = dao.Condition,
                Hourly = dao.Hourly?.Select(h => h.ToModel()).ToArray()
                    ?? Array.Empty<HourlyForecastModel>()
            };
        }

        public static HourlyForecastModel ToModel(this HourlyForecastDaoModel? dao)
        {
            if (dao == null)
                return null!;

            return new HourlyForecastModel
            {
                Time = dao.Time,
                Temperature = dao.Temperature,
                Condition = dao.Condition
            };
        }
    }
}
