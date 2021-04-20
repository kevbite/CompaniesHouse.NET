using System;

namespace CompaniesHouse.UriBuilders
{
    public interface IDocumentUriBuilder
    {
        Uri Build(string documentId);
    }
}