namespace Weather.Infrastructure.Http
{
    public record ApiWebSettings
    {
        public string Host { get; init; }

        public Dictionary<string, string> UrlCredentials { get; init; }
    }
}
