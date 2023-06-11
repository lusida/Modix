using System;
using System.Collections.Generic;
using System.Runtime.Loader;
using System.Text;

namespace Universal.Common
{
    internal class InjectionBuilder : IInjectionBuilder
    {
        public InjectionBuilder(IServiceCollection services)
        {
            this.Services = services;

            this.Directorices = new List<string>();

            this.SearchPatterns = new List<string>();

            this.Providers = new Dictionary<Type, IInjectionProvider>();

            this.LoadContextFactory = this.GetDefaultAssemblyLoadContext;

            this.AddProvider(new DefaultInjectionProvider());
        }

        public List<string> SearchPatterns { get; }
        public List<string> Directorices { get; }
        public IServiceCollection Services { get; }
        public IDictionary<Type, IInjectionProvider> Providers { get; }
        public Func<AssemblyLoadContext> LoadContextFactory { get; set; }

        private AssemblyLoadContext GetDefaultAssemblyLoadContext()
        {
            return AssemblyLoadContext.Default;
        }

        public void AddDirectory(string directory)
        {
            this.Directorices.Add(directory);
        }

        public void AddBaseDirectory()
        {
            this.Directorices.Add(AppContext.BaseDirectory);
        }

        public void AddProvider(IInjectionProvider provider)
        {
            this.Providers.Add(provider.AttributeType, provider);
        }

        public void AddSearchPattern(string pattern)
        {
            this.SearchPatterns.Add(pattern);
        }
    }
}
