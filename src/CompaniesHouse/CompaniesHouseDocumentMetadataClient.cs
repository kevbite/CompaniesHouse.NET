using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.Response.DocumentMetadata;
using CompaniesHouse.UriBuilders;

namespace CompaniesHouse
{
    public class CompaniesHouseDocumentMetadataClient : ICompaniesHouseDocumentMetadataClient
    {
        private readonly HttpClient _httpClient;
        private readonly IDocumentMetadataUriBuilder _documentMetadataUriBuilder;

        public CompaniesHouseDocumentMetadataClient(HttpClient httpClient, IDocumentMetadataUriBuilder documentMetadataUriBuilder)
        {
            _httpClient = httpClient;
            _documentMetadataUriBuilder = documentMetadataUriBuilder;
        }

        public async Task<CompaniesHouseClientResponse<DocumentMetadata>> GetDocumentMetadataAsync(string documentId, CancellationToken caneCancellationToken = default)
        {
            var requestUri = _documentMetadataUriBuilder.Build(documentId);
            var response = await _httpClient.GetAsync(requestUri, caneCancellationToken).ConfigureAwait(false);

            if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
                response.EnsureSuccessStatusCode();

            var result = response.IsSuccessStatusCode
                ? await response.Content.ReadAsJsonAsync<DocumentMetadata>().ConfigureAwait(false)
                : null;

            return new CompaniesHouseClientResponse<DocumentMetadata>(result);
        }
    }
}