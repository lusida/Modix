using System;
using System.Collections.Generic;
using System.Text;

namespace Universal.Common
{
    internal class DefaultInjectionProvider : InjectionProvider<InjectionAttribute>
    {
        protected override void Configure(
            InjectionAttribute attribute, InjectionEventArgs e)
        {
            var serviceType = attribute.ServiceType ?? e.Type;

            if (e.IsMany && e.AddFactory != null)
            {
                e.Services.AddSingleton(serviceType, e.AddFactory);
            }
            else
            {
                switch (attribute.Lifetime)
                {
                    case ServiceLifetime.Transient:
                        {
                            e.Services.AddTransient(serviceType, e.Type);
                        }
                        break;
                    case ServiceLifetime.Scoped:
                        {
                            e.Services.AddScoped(serviceType, e.Type);
                        }
                        break;
                    case ServiceLifetime.Singleton:
                        {
                            e.Services.AddSingleton(serviceType, e.Type);
                        }
                        break;
                }

                if (e.IsMany && e.AddFactory == null)
                {
                    e.AddFactory = (provider) => provider.GetService(serviceType);
                }
            }
        }
    }
}
