using Universal.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Universal.Common
{
    public class InjectionEventArgs
    {
        internal InjectionEventArgs(
            bool isMany, Type type, IServiceCollection services)
        {
            this.Type = type;

            this.IsMany = isMany;

            this.Services = services;
        }

        public Type Type { get; }
        public bool IsMany { get; }
        public DetectionAttribute Attribute { get; internal set; } = null!;
        public IServiceCollection Services { get; }
        public Func<IServiceProvider, object>? AddFactory { get; internal set; }
    }
}
