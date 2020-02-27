namespace CompaniesHouse.UriBuilders
{
    public class DocumentUriBuilder : IDocumentUriBuilder
    {
        private string _withContent;

        public IDocumentUriBuilder WithContent()
        {
            _withContent = "/content";
            return this;
        }

        public string Build(string documentId) => $"{CompaniesHouseUris.DocumentApi}/document/{documentId}{_withContent}";
    }
}