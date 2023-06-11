using System;
using System.Collections.Generic;
using System.Text;

namespace Universal.Common.Sdk
{
    internal class PackageContext : IPackageContext, IDisposable
    {
        public PackageContext(string filePath)
        {
            
        }

        public bool IsLoaded { get; set; }

        public PackageMetadata Metadata { get; }

        public IPackage GetPackage(string id)
        {
            throw new NotImplementedException();
        }

        public object GetService(Type serviceType)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
