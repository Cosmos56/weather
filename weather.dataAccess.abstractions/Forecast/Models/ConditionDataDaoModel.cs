
namespace Weather.DataAccess.Abstractions.Forecast.Models
{
    public record ConditionDataDaoModel
    {
        /// <summary>
        /// Погодные условия
        /// </summary>
        public string Text { get; init; }

        /// <summary>
        /// Url иконки
        /// </summary>
        public string Icon { get; init; }
    }
}
