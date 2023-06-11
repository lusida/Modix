using System;
using System.Collections.Generic;
using System.Text;

namespace Modix.Common
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class InjectionAttribute : DetectionAttribute
    {
        public InjectionAttribute(
            ServiceLifetime lifetime = ServiceLifetime.Singleton) : this(null, lifetime) { }

        public InjectionAttribute(
            Type? serviceType, ServiceLifetime lifetime = ServiceLifetime.Singleton)
        {
            this.ServiceType = serviceType;
            this.Lifetime = lifetime;
        }

        public Type? ServiceType { get; }
        public ServiceLifetime Lifetime { get; }
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class InjectionAttribute<T> : InjectionAttribute where T : class
    {
        public InjectionAttribute(
            ServiceLifetime lifetime = ServiceLifetime.Singleton) : base(typeof(T), lifetime) { }
    }
}
