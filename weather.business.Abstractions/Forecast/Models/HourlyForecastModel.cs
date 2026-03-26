namespace Weather.Business.Abstractions.Forecast.Models
{
    /// <summary>
    /// Прогноз по часам
    /// </summary>
    public record HourlyForecastModel
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
        public ConditionDataModel Condition { get; init; }
    }
}
