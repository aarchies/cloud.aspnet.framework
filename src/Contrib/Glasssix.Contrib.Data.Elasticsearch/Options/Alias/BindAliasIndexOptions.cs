using System;
using System.Collections.Generic;

namespace Glasssix.Contrib.Data.Elasticsearch.Options.Alias
{
    public class BindAliasIndexOptions
    {
        public BindAliasIndexOptions(string alias, string indexName) : this(alias)
        {
            if (string.IsNullOrEmpty(indexName))
                throw new ArgumentException("indexName cannot be empty", nameof(indexName));

            IndexNames = new[] { indexName };
        }

        public BindAliasIndexOptions(string alias, IEnumerable<string> indexNames) : this(alias)
        {
            //ArgumentNullException.ThrowIfNull(nameof(indexNames));
            IndexNames = indexNames;
        }

        private BindAliasIndexOptions(string alias) => Alias = alias;

        public string Alias { get; }
        public IEnumerable<string> IndexNames { get; } = default!;
    }
}