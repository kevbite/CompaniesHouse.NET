using System;

namespace CompaniesHouse.UriBuilders
{
    public class DocumentContentUriBuilder : IDocumentUriBuilder
    {
        public Uri Build(string documentId) => 
            new($"/document/{Uri.EscapeDataString(documentId)}/content", UriKind.Relative);
    }
}