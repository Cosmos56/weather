using Microsoft.Extensions.Configuration;
using Weather.Infrastructure.DependencyInjection;

namespace Weather.Infrastructure.Http
{
    [InjectAsTransient(typeof(ApiWebSettingsGetter))]
    public class ApiWebSettingsGetter(IConfiguration configuration)
    {
        public ApiWebSettings Get(string name)
        {
            return new ApiWebSettings
            {
                Host = configuration.GetSection($"{name}:Host").Value,
                UrlCredentials = new Dictionary<string, string> { { "key", Environment.GetEnvironmentVariable($"{name}_KEY") } }
            };
        }
    }
}
