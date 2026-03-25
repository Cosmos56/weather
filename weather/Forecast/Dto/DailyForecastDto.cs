namespace weather.Forecast.Dto
{
    /// <summary>
    /// Данные о прогнозе погоды
    /// </summary>
    public class DailyForecastDto
    {
        /// <summary>
        /// Дата
        /// </summary>
        public DateOnly Date { get; set; }

        /// <summary>
        /// Температура в градусах цельсия
        /// </summary>
        public int Temperature { get; set; }

        /// <summary>
        /// Ощущается как
        /// </summary>
        public int? FeelsLike { get; set; }

        /// <summary>
        /// Погодные условия
        /// </summary>
        public string Condition { get; set; }

        /// <summary>
        /// Почасовой прогноз
        /// </summary>
        public IReadOnlyCollection<HourlyForecastDto> Hourly { get; set; }
    }
}
