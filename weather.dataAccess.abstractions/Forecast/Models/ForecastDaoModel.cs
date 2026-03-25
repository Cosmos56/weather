namespace Weather.DataAccess.Abstractions.Forecast.Models
{
    /// <summary>
    /// Данные о прогнозе погоды
    /// </summary>
    public record ForecastDaoModel
    {
        /// <summary>
        /// Место положение
        /// </summary>
        public string Location { get; init; }

        /// <summary>
        /// Посуточные прогнозы
        /// </summary>
        public IReadOnlyCollection<DailyForecastDaoModel> Daily { get; init; }
    }
}
