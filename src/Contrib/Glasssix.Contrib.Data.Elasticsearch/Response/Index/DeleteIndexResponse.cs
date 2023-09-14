using Glasssix.Contrib.Data.Elasticsearch.Response;
using Nest;

namespace Glasssix.Contrib.Data.Elasticsearch.Response.Index
{
    public class DeleteIndexResponse : ResponseBase
    {
        public DeleteIndexResponse(Nest.DeleteIndexResponse deleteIndexResponse) : base(deleteIndexResponse)
        {
        }

        public DeleteIndexResponse(BulkAliasResponse bulkAliasResponse) : base(bulkAliasResponse)
        {
        }

        public DeleteIndexResponse(string message) : base(false, message)
        {
        }
    }
}