using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Modix.Common.Sdk
{
    public interface IPackage
    {
        Task LoadAsync(CancellationToken cancellationToken=default);
        Task UnloadAsync(CancellationToken cancellationToken=default);
    }
}
