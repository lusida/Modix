using System;
using System.Collections.Generic;
using System.Text;

namespace Universal.Common
{
    public abstract class InjectionProvider<TAttribute>
        : IInjectionProvider where TAttribute : DetectionAttribute
    {
        protected InjectionProvider()
        {
            this.AttributeType = typeof(TAttribute);
        }

        public Type AttributeType { get; }

        public virtual void Configure(InjectionEventArgs e)
        {
            if(e.Attribute is TAttribute attribute)
            {
                this.Configure(attribute, e);
            }
        }

        protected abstract void Configure(TAttribute attribute, InjectionEventArgs e);
    }
}
