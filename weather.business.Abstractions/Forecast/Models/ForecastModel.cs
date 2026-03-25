namespace Weather.Business.Abstractions.Forecast.Models
{
    /// <summary>
    /// Данные о прогнозе погоды
    /// </summary>
    public record ForecastModel
    {
        /// <summary>
        /// Место положение
        /// </summary>
        public string Location { get; init; }

        /// <summary>
        /// Посуточные прогнозы
        /// </summary>
        public IReadOnlyCollection<DailyForecastModel> Daily { get; init; }
    }
}
