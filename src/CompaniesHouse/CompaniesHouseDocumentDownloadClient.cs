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

        public async Task<CompaniesHouseResponse<DocumentDownload>> DownloadDocumentAsync(string documentId, CancellationToken cancellationToken = default)
        {
            var requestUri = _documentUriBuilder.Build(documentId);
            var response = await _httpClient.GetAsync(requestUri, cancellationToken).ConfigureAwait(false);

            var statusCode = (int)response.StatusCode;
            var reasonPhrase = response.ReasonPhrase;

            return statusCode switch
            {
                >= 200 and < 300 => new CompaniesHouseResponse<DocumentDownload>.Success(
                    new DocumentDownload
                    {
                        Content = await response.Content.ReadAsStreamAsync(cancellationToken),
                        ContentLength = response.Content.Headers.ContentLength,
                        ContentType = response.Content.Headers.ContentType?.MediaType
                    },
                    statusCode,
                    reasonPhrase,
                    response.Headers),

                404 => new CompaniesHouseResponse<DocumentDownload>.NotFound(statusCode, reasonPhrase),

                429 => new CompaniesHouseResponse<DocumentDownload>.RateLimited(
                    response.Headers.RetryAfter?.Delta,
                    statusCode,
                    reasonPhrase),

                401 or 403 => new CompaniesHouseResponse<DocumentDownload>.Unauthorized(statusCode, reasonPhrase),

                >= 500 => new CompaniesHouseResponse<DocumentDownload>.ServerError(
                    response.Headers.RetryAfter?.Delta,
                    statusCode,
                    reasonPhrase),

                _ => new CompaniesHouseResponse<DocumentDownload>.ClientError(statusCode, reasonPhrase),
            };
        }
    }
}
