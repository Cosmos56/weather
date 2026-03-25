namespace Weather.DataAccess.Abstractions.Forecast.Models
{
    /// <summary>
    /// Данные о прогнозе погоды
    /// </summary>
    public class DailyForecastDaoModel
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
        public IReadOnlyCollection<HourlyForecastDaoModel> Hourly { get; set; }
    }
}
