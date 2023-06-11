using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Modix.Common.Sdk
{
    public interface IModule
    {
        int Order { get; }
        Task InitializeAsync(CancellationToken cancellationToken = default);
    }
}
