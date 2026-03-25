namespace Weather.Infrastructure.DependencyInjection
{
    public enum InjectionLifetime
    {
        Singleton = 1,

        PerScope = 2,

        Transient = 3,
    }
}