namespace Weather.DataAccess.Abstractions.Forecast.Models
{
    /// <summary>
    /// Данные о прогнозе погоды
    /// </summary>
    public class ForecastDaoModel
    {
        /// <summary>
        /// Место положение
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Посуточные прогнозы
        /// </summary>
        public IReadOnlyCollection<DailyForecastDaoModel> Daily { get; set; }
    }
}
