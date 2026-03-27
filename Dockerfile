# Многоэтапная сборка для .NET API
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS api-builder

WORKDIR /src

# Копируем файлы решения
COPY ["weather.sln", "./"]
COPY ["weather/Weather.csproj", "weather/"]
COPY ["weather.business/Weather.Business.csproj", "weather.business/"]
COPY ["weather.business.Abstractions/Weather.Business.Abstractions.csproj", "weather.business.Abstractions/"]
COPY ["weather.dataAccess/Weather.DataAccess.csproj", "weather.dataAccess/"]
COPY ["weather.dataAccess.abstractions/Weather.DataAccess.Abstractions.csproj", "weather.dataAccess.abstractions/"]
COPY ["Weather.Infrastructure.AspNetCore/Weather.Infrastructure.AspNetCore.csproj", "Weather.Infrastructure.AspNetCore/"]
COPY ["Weather.Infrastructure.DependencyInjection/Weather.Infrastructure.DependencyInjection.csproj", "Weather.Infrastructure.DependencyInjection/"]
COPY ["Weather.Infrastructure.Logging/Weather.Infrastructure.Logging.csproj", "Weather.Infrastructure.Logging/"]
COPY ["Weather.Tests/Weather.Tests.csproj", "Weather.Tests/"]
COPY ["Weather.Weatherapi.Clients/Weather.Weatherapi.Clients.csproj", "Weather.Weatherapi.Clients/"]
COPY ["Weather.Weatherapi.Clients.Abstractoins/Weather.Weatherapi.Clients.Abstractoins.csproj", "Weather.Weatherapi.Clients.Abstractoins/"]

# Восстанавливаем зависимости
RUN dotnet restore "weather.sln"

# Копируем весь исходный код
COPY . .

# Собираем проект
WORKDIR "/src/weather"
RUN dotnet build "Weather.csproj" -c Release -o /app/build

# Публикуем проект
FROM api-builder AS publish
RUN dotnet publish "Weather.csproj" -c Release -o /app/publish /p:UseAppHost=false
# Финальный образ для API
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS api

WORKDIR /app

# Копируем опубликованные файлы
COPY --from=publish /app/publish .

# Создаем директорию для логов
RUN mkdir -p /app/logs

EXPOSE 8080

ENTRYPOINT ["dotnet", "Weather.dll"]