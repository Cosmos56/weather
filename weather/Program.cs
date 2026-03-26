using Weather.Infrastructure.AspNetCore.Extensions;
using Weather.Infrastructure.DependencyInjection;
using Weather.Weatherapi.Clients;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// регистрация DI контейнера по атрибутам
builder.Services.RegisterByDIAttribute("Weather.*");

builder.Services
    .AddHttpClient<BaseWebClient>(client =>
    {
        client.Timeout = TimeSpan.FromSeconds(15);
    })
    .ConfigurePrimaryHttpMessageHandler(() => new SocketsHttpHandler
    {
        AutomaticDecompression = System.Net.DecompressionMethods.All,
    }); ;

var app = builder.Build();

app.UseStartRedirect();

app.UsePing();

app.UseDefaultCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseDefaultExceptionHandler();

app.MapControllers();

app.Run();
