using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Weather.Infrastructure.DependencyInjection;

internal class DIInstaller
{
    private bool initialized;

    private readonly IServiceCollection services;
    private readonly Dictionary<Type, List<Action<IServiceCollection>>> registrationActionDictionary;

    public DIInstaller(IServiceCollection services)
    {
        this.services = services;
        registrationActionDictionary = new Dictionary<Type, List<Action<IServiceCollection>>>();
    }

    public void Initialize()
    {
        if (initialized)
        {
            return;
        }

        foreach (var action in registrationActionDictionary.SelectMany(x => x.Value))
        {
            action(services);
        }

        initialized = true;
    }

    public void RegisterByDIAttribute(string assemblyPath, string assemblySearchPattern)
    {
        var assemblyByPatternList = AssemblyExtensions.GetAssemblyByPattern(assemblyPath, assemblySearchPattern);
        RegisterByDIAttribute(assemblyByPatternList);
    }


    private void RegisterByDIAttribute(params Assembly[] assemblyList)
    {
        var injectInfoList = assemblyList
            .SelectMany(assembly => assembly.GetTypes())
            .Where(type => type.IsDefined(typeof(InjectAttribute), inherit: false))
            .SelectMany(GetInterfaces);

        foreach (var (service, implementation, lifetime) in injectInfoList)
        {
            SetServiceToRegistration(service, serviceCollection => serviceCollection
                .Add(new ServiceDescriptor(service, implementation, lifetime)));

        }
    }

    private static (Type Service, Type Implementation, ServiceLifetime Lifetime)[] GetInterfaces(Type type)
    {
        var registrations = Attribute.GetCustomAttributes(type, typeof(InjectAttribute), false)
        .Cast<InjectAttribute>()
        .Select(injectAttribute => (
            Service: injectAttribute.AbstractType,
            Implementation: type,
            Lifetime: GetLifetime(injectAttribute))) 
        .ToArray();

        return registrations
            .Where(reg => reg.Service != null && reg.Service.IsAssignableFrom(reg.Implementation))
            .ToArray();
    }

    private static ServiceLifetime GetLifetime(InjectAttribute attr)
    {
        return attr.Lifetime switch
        {
            InjectionLifetime.Singleton => ServiceLifetime.Singleton,
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    private void SetServiceToRegistration(Type serviceType, Action<IServiceCollection> registerAction)
    {
        if (registrationActionDictionary.ContainsKey(serviceType) == false)
        {
            registrationActionDictionary.Add(serviceType, []);
        }
        registrationActionDictionary[serviceType].Add(registerAction);
    }
}