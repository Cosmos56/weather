using System.Net;
using Weather.Infrastructure.AspNetCore.Extensions;
using Weather.Infrastructure.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddHttpClient<WebClient>(client =>
{
    client.Timeout = TimeSpan.FromSeconds(30);
});

// регистрация DI контейнера по атрибутам
builder.Services.RegisterByDIAttribute("Weather.*");

var app = builder.Build();

app.UseStartRedirect();

app.UsePing();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseDefaultExceptionHandler();

app.MapControllers();

app.Run();
