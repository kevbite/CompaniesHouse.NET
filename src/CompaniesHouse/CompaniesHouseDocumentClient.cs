using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.Response.Document;
using CompaniesHouse.UriBuilders;

namespace CompaniesHouse
{
    public class CompaniesHouseDocumentClient : ICompaniesHouseDocumentClient, IDisposable
    {
        private readonly ICompaniesHouseDocumentMetadataClient _companiesHouseDocumentMetadataClient;
        private readonly CompaniesHouseDocumentDownloadClient _companiesHouseDocumentDownloadClient;
        private readonly HttpClient _httpClient;
        
        public CompaniesHouseDocumentClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _companiesHouseDocumentMetadataClient = new CompaniesHouseDocumentMetadataClient(_httpClient, new DocumentMetadataUriBuilder());
            _companiesHouseDocumentDownloadClient = new CompaniesHouseDocumentDownloadClient(_httpClient, new DocumentContentUriBuilder());
        }

        public CompaniesHouseDocumentClient(ICompaniesHouseSettings settings) 
            : this(new HttpClientFactory(settings).CreateHttpClient())
        {
            
        }
        
        public Task<CompaniesHouseClientResponse<DocumentMetadata>> GetDocumentMetadataAsync(string documentId, CancellationToken caneCancellationToken = default)
        {
            return _companiesHouseDocumentMetadataClient.GetDocumentMetadataAsync(documentId, caneCancellationToken);
        }

        public Task<CompaniesHouseClientResponse<DocumentDownload>> DownloadDocumentAsync(string documentId, CancellationToken cancellationToken = default)
        {
            return _companiesHouseDocumentDownloadClient.DownloadDocumentAsync(documentId, cancellationToken);
        }

        public void Dispose() => _httpClient.Dispose();
    }
}