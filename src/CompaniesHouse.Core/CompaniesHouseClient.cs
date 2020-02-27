using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.Core.Request;
using CompaniesHouse.Core.Response.Appointments;
using CompaniesHouse.Core.Response.CompanyFiling;
using CompaniesHouse.Core.Response.CompanyProfile;
using CompaniesHouse.Core.Response.Document;
using CompaniesHouse.Core.Response.Insolvency;
using CompaniesHouse.Core.Response.Officers;
using CompaniesHouse.Core.Response.PersonsWithSignificantControl;
using CompaniesHouse.Core.Response.Search.AllSearch;
using CompaniesHouse.Core.Response.Search.CompanySearch;
using CompaniesHouse.Core.Response.Search.DisqualifiedOfficersSearch;
using CompaniesHouse.Core.Response.Search.OfficerSearch;
using CompaniesHouse.Core.UriBuilders;

namespace CompaniesHouse.Core
{
    public class CompaniesHouseClient : ICompaniesHouseClient, IDisposable
    {
        private readonly ICompaniesHouseSearchClient _companiesHouseSearchClient;
        private readonly ICompaniesHouseCompanyProfileClient _companiesHouseCompanyProfileClient;
        private readonly ICompaniesHouseCompanyFilingHistoryClient _companiesHouseCompanyFilingHistoryClient;
        private readonly ICompaniesHouseOfficersClient _companiesHouseOfficersClient;
        private readonly ICompaniesHouseCompanyInsolvencyInformationClient _companiesHouseCompanyInsolvencyInformationClient;
        private readonly ICompaniesHouseAppointmentsClient _companiesHouseCompanyAppointmentsClient;
        private readonly ICompaniesHouseDocumentMetadataClient _companiesHouseDocumentMetadataClient;
        private readonly ICompaniesHouseDocumentClient _companiesHouseDocumentClient;
        private readonly ICompaniesHousePersonsWithSignificantControlClient _companiesHousePersonsWithSignificantControlClient;

        private readonly HttpClient _httpClient;

        public CompaniesHouseClient(ICompaniesHouseSettings settings)
        {
            var httpClientFactory = new HttpClientFactory(settings);
            _httpClient = httpClientFactory.CreateHttpClient();

            _companiesHouseSearchClient = new CompaniesHouseSearchClient(_httpClient, new SearchUriBuilderFactory());
            _companiesHouseCompanyProfileClient = new CompaniesHouseCompanyProfileClient(_httpClient, new CompanyProfileUriBuilder());
            _companiesHouseCompanyFilingHistoryClient = new CompaniesHouseCompanyFilingHistoryClient(_httpClient, new CompanyFilingHistoryUriBuilder());
            _companiesHouseOfficersClient = new CompaniesHouseOfficersClient(_httpClient, new OfficersUriBuilder());
            _companiesHouseCompanyInsolvencyInformationClient = new CompaniesHouseCompanyInsolvencyInformationClient(_httpClient);
            _companiesHouseCompanyAppointmentsClient = new CompaniesHouseAppointmentsClient(_httpClient);
            var documentUriBuilder = new DocumentUriBuilder();
            _companiesHouseDocumentMetadataClient = new CompaniesHouseDocumentMetadataClient(_httpClient, documentUriBuilder);
            _companiesHouseDocumentClient = new CompaniesHouseDocumentClient(_httpClient, documentUriBuilder);
			_companiesHousePersonsWithSignificantControlClient = new CompaniesHousePersonsWithSignificantControlClient(_httpClient, new PersonsWithSignificantControlBuilder());
        }

        public Task<CompaniesHouseClientResponse<CompanySearch>> SearchCompanyAsync(SearchRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _companiesHouseSearchClient.SearchAsync<CompanySearch>(request, cancellationToken);
        }

        public Task<CompaniesHouseClientResponse<OfficerSearch>> SearchOfficerAsync(SearchRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _companiesHouseSearchClient.SearchAsync<OfficerSearch>(request, cancellationToken);
        }

        public Task<CompaniesHouseClientResponse<DisqualifiedOfficerSearch>> SearchDisqualifiedOfficerAsync(SearchRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _companiesHouseSearchClient.SearchAsync<DisqualifiedOfficerSearch>(request, cancellationToken);
        }

        public Task<CompaniesHouseClientResponse<AllSearch>> SearchAllAsync(SearchRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _companiesHouseSearchClient.SearchAsync<AllSearch>(request, cancellationToken);
        }

        public Task<CompaniesHouseClientResponse<CompanyProfile>> GetCompanyProfileAsync(string companyNumber, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _companiesHouseCompanyProfileClient.GetCompanyProfileAsync(companyNumber, cancellationToken);
        }

        public Task<CompaniesHouseClientResponse<CompanyFilingHistory>> GetCompanyFilingHistoryAsync(string companyNumber, int startIndex = 0, int pageSize = 25, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _companiesHouseCompanyFilingHistoryClient.GetCompanyFilingHistoryAsync(companyNumber, startIndex, pageSize, cancellationToken);
        }

        public Task<CompaniesHouseClientResponse<Officers>> GetOfficersAsync(string companyNumber, int startIndex = 0, int pageSize = 25, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _companiesHouseOfficersClient.GetOfficersAsync(companyNumber, startIndex, pageSize, cancellationToken);
        }

        public Task<CompaniesHouseClientResponse<CompanyInsolvencyInformation>> GetCompanyInsolvencyInformationAsync(string companyNumber, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _companiesHouseCompanyInsolvencyInformationClient.GetCompanyInsolvencyInformationAsync(companyNumber, cancellationToken);
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }

        public Task<CompaniesHouseClientResponse<Appointments>> GetAppointmentsAsync(string officerId, int startIndex = 0, int pageSize = 25, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _companiesHouseCompanyAppointmentsClient.GetAppointmentsAsync(officerId, startIndex, pageSize,
                cancellationToken);
        }

        public Task<CompaniesHouseClientResponse<DocumentMetadata>> GetDocumentMetadataAsync(string documentId, CancellationToken caneCancellationToken = default)
        {
            return _companiesHouseDocumentMetadataClient.GetDocumentMetadataAsync(documentId, caneCancellationToken);
        }

        public Task<CompaniesHouseClientResponse<DocumentDownload>> DownloadDocumentAsync(string documentId, CancellationToken cancellationToken = default)
        {
            return _companiesHouseDocumentClient.DownloadDocumentAsync(documentId, cancellationToken);
        }
		
		public Task<CompaniesHouseClientResponse<PersonsWithSignificantControl>> GetPersonsWithSignificantControlAsync(string companyNumber, int startIndex = 0, int pageSize = 25, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _companiesHousePersonsWithSignificantControlClient.GetPersonsWithSignificantControlAsync(companyNumber, startIndex, pageSize, cancellationToken);
        }
    }
}
