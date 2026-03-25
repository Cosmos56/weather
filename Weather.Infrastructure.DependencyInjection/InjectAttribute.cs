using System;

namespace Weather.Infrastructure.DependencyInjection
{
    [AttributeUsage(AttributeTargets.Class)]
    public class InjectAttribute : Attribute
    {
        protected InjectAttribute(InjectionLifetime lifetime, Type abstractType)
        {
            Lifetime = lifetime;
            AbstractType = abstractType;
        }

        public InjectionLifetime Lifetime { get; }

        public Type AbstractType { get; }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class InjectAsSingletonAttribute : InjectAttribute
    {
        public InjectAsSingletonAttribute(Type abstractType) : base(InjectionLifetime.Singleton, abstractType)
        {
        }
        
    }
}