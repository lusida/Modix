using System;
using System.Collections.Generic;
using System.Text;

namespace Universal.Common.Sdk
{
    public class PackageMetadata
    {
        public PackageMetadata(
            string id, 
            string title, 
            string? description, 
            IReadOnlyDictionary<string, string> dependencies)
        {
            this.Id = id;
            this.Title = title;
            this.Description = description;
            this.Dependencies = dependencies;
        }

        public string Id { get; }
        public string Title { get; }
        public string? Description { get; }
        public IReadOnlyDictionary<string, string> Dependencies { get; }
        public string FilePath { get; internal set; } = null!;
    }
}
