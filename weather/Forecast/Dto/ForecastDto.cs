namespace Weather.Forecast.Dto
{
    /// <summary>
    /// Данные о прогнозе погоды
    /// </summary>
    public class ForecastDto
    {
        /// <summary>
        /// Место положение
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Посуточные прогнозы
        /// </summary>
        public IReadOnlyCollection<DailyForecastDto> Daily { get; set; }
    }
}
