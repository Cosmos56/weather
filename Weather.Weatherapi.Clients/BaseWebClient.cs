
using System.Net;

namespace Weather.Weatherapi.Clients
{
    public class BaseWebClient(HttpClient httpClient)
    {
        public async Task<string> GetAsync(string url, CancellationToken cancellationToken)
        {
            var tryCount = 3;
            var halfSecond = 500;
            var responseMessage = await httpClient.GetAsync(url, cancellationToken);
            while (tryCount > 0 && !responseMessage.IsSuccessStatusCode)
            {
                await Task.Delay(halfSecond);
                responseMessage = await httpClient.GetAsync(url, cancellationToken);
                tryCount--;
            }
            var response = await responseMessage.Content.ReadAsStringAsync(cancellationToken);
            return responseMessage.IsSuccessStatusCode ?
                response :
                throw new HttpRequestException($"Ошибка в {nameof(BaseWebClient)}.{nameof(GetAsync)}. " +
                                           $"HTTP STATUS CODE: {(int)responseMessage.StatusCode} {responseMessage.StatusCode}. " +
                                           $"REQUEST:{url.Split("key")[0]}. " +
                                           $"RESPONSE:{response}.");
        }
    }
}