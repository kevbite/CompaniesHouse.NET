using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using CompaniesHouse.UriBuilders;

namespace CompaniesHouse
{
    public class CompaniesHouseDocumentClient : ICompaniesHouseDocumentClient
    {
        private readonly HttpClient _httpClient;
        private readonly IDocumentUriBuilder _documentUriBuilder;

        public CompaniesHouseDocumentClient(HttpClient httpClient, IDocumentUriBuilder documentUriBuilder)
        {
            _httpClient = httpClient;
            _documentUriBuilder = documentUriBuilder;
        }

        public async Task<CompaniesHouseClientResponse<Stream>> DownloadDocumentAsync(string documentId)
        {
            var requestUri = _documentUriBuilder.WithContent().Build(documentId);
            var data = await _httpClient.GetStreamAsync(requestUri).ConfigureAwait(false);

            return new CompaniesHouseClientResponse<Stream>(data);
        }
    }
}