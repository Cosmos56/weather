namespace Weather.DataAccess.Abstractions.Forecast.Models
{
    /// <summary>
    /// Прогноз по часам
    /// </summary>
    public record HourlyForecastDaoModel
    {
        /// <summary>
        /// Дата и время
        /// </summary>
        public TimeOnly Time { get; init; }

        /// <summary>
        /// Температура в градусах цельсия
        /// </summary>
        public int Temperature { get; init; }

        /// <summary>
        /// Погодные условия
        /// </summary>
        public string Condition { get; init; }
    }
}
