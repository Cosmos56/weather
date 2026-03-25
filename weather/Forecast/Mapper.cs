using weather.Forecast.Dto;
using Weather.Business.Abstractions.Forecast.Models;

namespace Weather.Forecast
{
    public static class Mapper
    {
        public static ForecastDto ToDto(this ForecastModel domain)
        {
            if (domain == null) throw new ArgumentNullException(nameof(domain));

            return new ForecastDto
            {
                Location = domain.Location,
                Daily = domain.Daily?.Select(d => d.ToDto()).ToList()
                    ?? new List<DailyForecastDto>()
            };
        }

        private static DailyForecastDto ToDto(this DailyForecastModel domain)
        {
            if (domain == null) throw new ArgumentNullException(nameof(domain));

            return new DailyForecastDto
            {
                Date = domain.Date,
                Temperature = domain.Temperature,
                FeelsLike = domain.FeelsLike,
                Condition = domain.Condition,
                Hourly = domain.Hourly?.Select(h => h.ToDto()).ToList()
                    ?? new List<HourlyForecastDto>()
            };
        }

        private static HourlyForecastDto ToDto(this HourlyForecastModel domain)
        {
            if (domain == null) throw new ArgumentNullException(nameof(domain));

            return new HourlyForecastDto
            {
                Time = domain.Time,
                Temperature = domain.Temperature,
                Condition = domain.Condition
            };
        }
    }
}
