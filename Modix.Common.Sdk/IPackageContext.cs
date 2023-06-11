using System;
using System.Collections.Generic;
using System.Text;

namespace Modix.Common.Sdk
{
    public interface IPackageContext : IServiceProvider
    {
        bool IsLoaded { get; }
        PackageMetadata Metadata { get; }
        IPackage GetPackage(string id);
    }
}
