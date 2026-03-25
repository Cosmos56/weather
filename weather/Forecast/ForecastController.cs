using Microsoft.AspNetCore.Mvc;
using Weather.Business.Abstractions.Forecast;

namespace Weather.Forecast
{
    [ApiController]
    [Route("api/[controller]")]
    public class ForecastController(IForecastGetter getter) : ControllerBase
    {
        /// <summary>
        /// ѕолучить прогноз за указаное количество дней
        /// </summary>
        /// <param name="dayCount">дальность прогноза</param>
        /// <param name="lat">широта, по умолчанию ћосква</param>
        /// <param name="lon">долгота, по умолчанию ћосква</param>
        /// <returns></returns>
        [HttpGet("days")]
        public async Task<IActionResult> GetDaysForecast(int dayCount, double lat = 55.75, double lon = 37.61, CancellationToken cancellationToken = default)
        {
            var result = await getter.GetForecast(dayCount, lat, lon, cancellationToken);
            return Ok(result.ToDto());
        }
    }
}
