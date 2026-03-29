
using Weather.Infrastructure.Json;

namespace Weather.Infrastructure.Http
{
    public abstract class ApiWebClientBase(
        WebClientBase webClient,
        ApiWebSettingsGetter settingsGetter, 
        string settingsName)
    {
        private int tryCount = 3;
        private int retryDelay = 500;

        protected async Task<TResponse> GetAsync<TResponse>(string url, CancellationToken cancellationToken)
        {
            var response = await webClient.GetAsync(GetUrl(url), tryCount, retryDelay, cancellationToken);
            return response.FromJsonString<TResponse>();
        }

        private string GetUrl(string url) 
        {
            var settings = settingsGetter.Get(settingsName);
            return settings.Host + url + string.Concat(settings.UrlCredentials.Select(x => "&" + x.Key + "=" + x.Value));
        }
    }
}
