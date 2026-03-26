
namespace Weather.Forecast.Dto
{
    public record ConditionDto
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
