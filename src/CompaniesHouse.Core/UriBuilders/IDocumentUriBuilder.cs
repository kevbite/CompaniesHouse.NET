namespace CompaniesHouse.UriBuilders
{
    public interface IDocumentUriBuilder
    {
        IDocumentUriBuilder WithContent();
        string Build(string documentId);
    }
}