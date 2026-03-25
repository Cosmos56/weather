namespace Weather.Business.Abstractions.Forecast.Models
{
    /// <summary>
    /// Данные о прогнозе погоды
    /// </summary>
    public class DailyForecastModel
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
        public int FeelsLike { get; set; }

        /// <summary>
        /// Погодные условия
        /// </summary>
        public string Condition { get; set; }

        /// <summary>
        /// Почасовой прогноз
        /// </summary>
        public IReadOnlyCollection<HourlyForecastModel> Hourly { get; set; }
    }
}
