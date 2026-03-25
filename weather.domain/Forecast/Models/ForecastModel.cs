namespace Weather.Domain.Forecast.Models
{
    /// <summary>
    /// Данные о прогнозе погоды
    /// </summary>
    public class ForecastModel
    {
        /// <summary>
        /// Место положение
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Посуточные прогнозы
        /// </summary>
        public IReadOnlyCollection<DailyForecastModel> Daily { get; set; }
    }
}
