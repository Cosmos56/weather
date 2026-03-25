namespace Weather.Business.Abstractions.Forecast.Models
{
    /// <summary>
    /// Данные о прогнозе погоды
    /// </summary>
    public record DailyForecastModel
    {
        /// <summary>
        /// Дата
        /// </summary>
        public DateOnly Date { get; init; }

        /// <summary>
        /// Температура в градусах цельсия
        /// </summary>
        public int Temperature { get; init; }

        /// <summary>
        /// Ощущается как
        /// </summary>
        public int? FeelsLike { get; init; }

        /// <summary>
        /// Погодные условия
        /// </summary>
        public string Condition { get; init; }

        /// <summary>
        /// Почасовой прогноз
        /// </summary>
        public IReadOnlyCollection<HourlyForecastModel> Hourly { get; init; }
    }
}
