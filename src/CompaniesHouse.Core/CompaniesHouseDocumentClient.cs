using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.Core.Response.Document;
using CompaniesHouse.Core.UriBuilders;

namespace CompaniesHouse.Core
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

        public async Task<CompaniesHouseClientResponse<DocumentDownload>> DownloadDocumentAsync(string documentId, CancellationToken cancellationToken = default)
        {
            var requestUri = _documentUriBuilder.WithContent().Build(documentId);
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