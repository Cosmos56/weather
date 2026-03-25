using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Reflection;

namespace Weather.Infrastructure.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterByDIAttribute(this IServiceCollection services, string assemblySearchPattern)
        {
            var assemblyPath = new Uri(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!).LocalPath;
            var installer = new DIInstaller(services);
            installer.RegisterByDIAttribute(assemblyPath, assemblySearchPattern);
            installer.Initialize();
            return services;
        }
    }
}
