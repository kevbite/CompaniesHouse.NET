using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.Response.DocumentMetadata;

namespace CompaniesHouse
{
    public class CompaniesHouseDocumentMetadataClient : ICompaniesHouseDocumentMetadataClient
    {
        private readonly HttpClient _httpClient;

        public CompaniesHouseDocumentMetadataClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CompaniesHouseClientResponse<DocumentMetadata>> GetDocumentMetadataAsync(string documentId, CancellationToken caneCancellationToken = default)
        {
            var response = await _httpClient.GetAsync($"document/{documentId}", caneCancellationToken).ConfigureAwait(false);

            if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
                response.EnsureSuccessStatusCode();

            var result = response.IsSuccessStatusCode
                ? await response.Content.ReadAsJsonAsync<DocumentMetadata>().ConfigureAwait(false)
                : null;

            return new CompaniesHouseClientResponse<DocumentMetadata>(result);
        }
    }
}