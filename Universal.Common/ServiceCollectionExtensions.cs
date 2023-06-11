using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Universal.Common
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInjection(
            this IServiceCollection services, Action<IInjectionBuilder>? builder = null)
        {
            var options = new InjectionBuilder(services);

            builder?.Invoke(options);

            if (options.SearchPatterns.Count > 0)
            {
                var context = options.LoadContextFactory();

                foreach (var directory in options.Directorices)
                {
                    var info = new DirectoryInfo(directory);

                    if (info.Exists)
                    {
                        foreach (var pattern in options.SearchPatterns)
                        {
                            var files = info.GetFiles(pattern);

                            foreach (var file in files)
                            {
                                var assembly = context.LoadFromAssemblyPath(file.FullName);

                                services.AddAssembly(assembly, options);
                            }
                        }
                    }
                }
            }

            return services;
        }

        private static void AddAssembly(
            this IServiceCollection services, Assembly assembly, InjectionBuilder options)
        {
            foreach (var type in assembly.DefinedTypes)
            {
                var attributes = type.GetCustomAttributes<DetectionAttribute>();

                var arg = new InjectionEventArgs(
                    attributes.Count() > 1, type, services);

                foreach (var attribute in attributes)
                {
                    var attributeType = attribute.GetType();

                    if (attributeType.IsGenericType)
                    {
                        attributeType = attributeType.BaseType;
                    }

                    if (options.Providers.TryGetValue(attributeType, out var provider))
                    {
                        arg.Attribute = attribute;

                        provider.Configure(arg);
                    }
                }
            }
        }
    }
}
