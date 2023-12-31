using Glasssix.Contrib.Data.Elasticsearch.Options.Document;

namespace Glasssix.Contrib.Data.Elasticsearch.Options.Document.Update
{
    public class UpdateDocumentRequest<TDocument> : DocumentOptions where TDocument : class
    {
        public UpdateDocumentRequest(string indexName, TDocument document, string? documentId = null) : base(indexName)
            => Request = new UpdateDocumentBaseRequest<TDocument>(document, documentId);

        public UpdateDocumentRequest(string indexName, object partialDocument, string? documentId = null) : base(indexName)
            => Request = new UpdateDocumentBaseRequest<TDocument>(partialDocument, documentId);

        public UpdateDocumentBaseRequest<TDocument> Request { get; }
    }
}