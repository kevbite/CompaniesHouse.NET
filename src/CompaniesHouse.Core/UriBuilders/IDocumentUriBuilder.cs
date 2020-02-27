namespace CompaniesHouse.Core.UriBuilders
{
    public interface IDocumentUriBuilder
    {
        IDocumentUriBuilder WithContent();
        string Build(string documentId);
    }
}