namespace CompaniesHouse.UriBuilders
{
    public class DocumentMetadataUriBuilder : IDocumentMetadataUriBuilder
    {
        public string Build(string documentId) => $"{CompaniesHouseUris.DocumentApi}/document/{documentId}";
    }
}