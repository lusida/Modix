using System;
using System.Collections.Generic;
using System.Text;

namespace Universal.Common
{
    public interface IInjectionProvider
    {
        Type AttributeType { get; }
        void Configure(InjectionEventArgs e);
    }
}
