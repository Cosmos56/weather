
namespace Weather.Infrastructure.Http
{
    public class WebClientBase(HttpClient httpClient)
    {
        public async Task<string> GetAsync(string url, int tryCount, int retryDelay, CancellationToken cancellationToken)
        {
            var responseMessage = await httpClient.GetAsync(url, cancellationToken);
            while (tryCount > 0 && !responseMessage.IsSuccessStatusCode)
            {
                await Task.Delay(retryDelay);
                responseMessage = await httpClient.GetAsync(url, cancellationToken);
                tryCount--;
            }
            var response = await responseMessage.Content.ReadAsStringAsync(cancellationToken);
            return responseMessage.IsSuccessStatusCode ?
                response :
                throw new HttpRequestException($"Ошибка в {nameof(WebClientBase)}.{nameof(GetAsync)}. " +
                                           $"HTTP STATUS CODE: {(int)responseMessage.StatusCode} {responseMessage.StatusCode}. " +
                                           $"REQUEST:{url.Split("key")[0]}. " +
                                           $"RESPONSE:{response}.");
        }
    }
}