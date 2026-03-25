using Weather.Infrastructure.DependencyInjection;

namespace Weather.Weatherapi.Clients
{
    [InjectAsSingleton(typeof(WebClient))]
    public class WebClient(HttpClient httpClient)
    {
        public async Task<string> GetAsync(string url, CancellationToken cancellationToken)
        {
            using var request = new HttpRequestMessage(HttpMethod.Get, url);
            using var responseMessage = await httpClient.SendAsync(request, cancellationToken: cancellationToken);
            var response = await responseMessage.Content.ReadAsStringAsync(cancellationToken);
            if (responseMessage.IsSuccessStatusCode)
            {
                return response;
            }

            var requestPartWithoutKey = url.Split("key")[0];
            throw new HttpRequestException($"Ошибка в {nameof(GetAsync)}. " +
                                           $"HTTP STATUS CODE: {(int)responseMessage.StatusCode} {responseMessage.StatusCode}. " +
                                           $"REQUEST:{requestPartWithoutKey}. " +
                                           $"RESPONSE:{response}.");
        }
    }
}