using Weather.Infrastructure.AspNetCore.Extensions;
using Weather.Infrastructure.DependencyInjection;
using Weather.Infrastructure.Http;
using Weather.Infrastructure.Logging;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.RegisterByDIAttribute("Weather.*");
builder.Services
    .AddHttpClient<WebClientBase>(client =>
    {
        client.Timeout = TimeSpan.FromSeconds(int.TryParse(builder.Configuration.GetSection("WEATHER_API:Timeout").Value, out int timeout) ? timeout : 15);
    })
    .ConfigurePrimaryHttpMessageHandler(() => new SocketsHttpHandler
    {
        AutomaticDecompression = System.Net.DecompressionMethods.All,
    });

builder.Logging.AddProvider(new FileLoggerProvider("logs/app.log"));

var app = builder.Build();
app.UseStartRedirect();
app.UsePing();
app.UseDefaultCors();
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseDefaultExceptionHandler();
app.MapControllers();
app.Run();
