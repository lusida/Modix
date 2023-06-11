using System;
using System.Collections.Generic;
using System.Runtime.Loader;
using System.Text;

namespace Universal.Common
{
    public interface IInjectionBuilder
    {
        IServiceCollection Services { get; }
        Func<AssemblyLoadContext> LoadContextFactory { get; set; }
        void AddProvider(IInjectionProvider provider);
        void AddBaseDirectory();
        void AddDirectory(string directory);
        void AddSearchPattern(string pattern);
    }
}
