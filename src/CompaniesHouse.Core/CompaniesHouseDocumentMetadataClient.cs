using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.Core.Response.Document;
using CompaniesHouse.Core.UriBuilders;

namespace CompaniesHouse.Core
{
    public class CompaniesHouseDocumentMetadataClient : ICompaniesHouseDocumentMetadataClient
    {
        private readonly HttpClient _httpClient;
        private readonly IDocumentUriBuilder _documentUriBuilder;

        public CompaniesHouseDocumentMetadataClient(HttpClient httpClient, IDocumentUriBuilder documentUriBuilder)
        {
            _httpClient = httpClient;
            _documentUriBuilder = documentUriBuilder;
        }

        public async Task<CompaniesHouseClientResponse<DocumentMetadata>> GetDocumentMetadataAsync(string documentId, CancellationToken caneCancellationToken = default)
        {
            var requestUri = _documentUriBuilder.Build(documentId);
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