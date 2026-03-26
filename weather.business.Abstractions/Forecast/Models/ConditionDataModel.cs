
namespace Weather.Business.Abstractions.Forecast.Models
{
    public record ConditionDataModel
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
