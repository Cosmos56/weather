using Weather.Infrastructure.DependencyInjection;
using Weather.Infrastructure.AspNetCore.Extensions;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

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
