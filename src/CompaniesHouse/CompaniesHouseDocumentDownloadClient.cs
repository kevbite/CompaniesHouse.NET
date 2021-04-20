using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.Response.Document;
using CompaniesHouse.UriBuilders;

namespace CompaniesHouse
{
    public class CompaniesHouseDocumentDownloadClient : ICompaniesHouseDocumentDownloadClient
    {
        private readonly HttpClient _httpClient;
        private readonly IDocumentUriBuilder _documentUriBuilder;

        public CompaniesHouseDocumentDownloadClient(HttpClient httpClient, IDocumentUriBuilder documentUriBuilder)
        {
            _httpClient = httpClient;
            _documentUriBuilder = documentUriBuilder;
        }

        public async Task<CompaniesHouseClientResponse<DocumentDownload>> DownloadDocumentAsync(string documentId, CancellationToken cancellationToken = default)
        {
            var requestUri = _documentUriBuilder.Build(documentId);
            var response = await _httpClient.GetAsync(requestUri, cancellationToken).ConfigureAwait(false);

            if (response.StatusCode != HttpStatusCode.NotFound)
                response.EnsureSuccessStatusCode();

            var data = response.IsSuccessStatusCode
                ? new DocumentDownload
                {
                    Content = await response.Content.ReadAsStreamAsync(),
                    ContentLength = response.Content.Headers.ContentLength,
                    ContentType = response.Content.Headers.ContentType.MediaType
                }
                : null;

            return new CompaniesHouseClientResponse<DocumentDownload>(data);
        }
    }
}