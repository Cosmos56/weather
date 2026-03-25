namespace weather.Forecast.Dto
{
    /// <summary>
    /// Прогноз по часам
    /// </summary>
    public class HourlyForecastDto
    {
        /// <summary>
        /// Дата и время
        /// </summary>
        public TimeOnly Time { get; set; }

        /// <summary>
        /// Температура в градусах цельсия
        /// </summary>
        public int Temperature { get; set; }

        /// <summary>
        /// Погодные условия
        /// </summary>
        public string Condition { get; set; }
    }
}
