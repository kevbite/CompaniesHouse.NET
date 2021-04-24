using System;

namespace CompaniesHouse.UriBuilders
{
    public class DocumentMetadataUriBuilder : IDocumentUriBuilder
    {
        public Uri Build(string documentId) => 
            new($"/document/{Uri.EscapeDataString(documentId)}", UriKind.Relative);
    }
}