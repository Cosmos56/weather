using Weather.Infrastructure.DependencyInjection;

namespace Weather.Weatherapi.Clients
{
    [InjectAsTransient(typeof(BaseWebClient))]
    public class BaseWebClient(HttpClient httpClient)
    {
        public async Task<string> GetAsync(string url, CancellationToken cancellationToken)
        {
            using var responseMessage = await httpClient.GetAsync(url, cancellationToken: cancellationToken);
            var response = await responseMessage.Content.ReadAsStringAsync(cancellationToken);
            if (responseMessage.IsSuccessStatusCode)
                return response;

            var requestPartWithoutKey = url.Split("key")[0];
            throw new HttpRequestException($"Ошибка в {nameof(BaseWebClient)}.{nameof(GetAsync)}. " +
                                           $"HTTP STATUS CODE: {(int)responseMessage.StatusCode} {responseMessage.StatusCode}. " +
                                           $"REQUEST:{requestPartWithoutKey}. " +
                                           $"RESPONSE:{response}.");
        }
    }
}