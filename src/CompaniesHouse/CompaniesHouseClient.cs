using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.Request;
using CompaniesHouse.Response.Appointments;
using CompaniesHouse.Response.Charges;
using CompaniesHouse.Response.CompanyFiling;
using CompaniesHouse.Response.CompanyProfile;
using CompaniesHouse.Response.DisqualifiedOfficers;
using CompaniesHouse.Response.Insolvency;
using CompaniesHouse.Response.Officers;
using CompaniesHouse.Response.PersonsWithSignificantControl;
using CompaniesHouse.Response.Registers;
using CompaniesHouse.Response.RegisteredOfficeAddress;
using CompaniesHouse.Response.Search.AllSearch;
using CompaniesHouse.Response.Search.AdvancedCompanySearch;
using CompaniesHouse.Response.Search.CompaniesAlphabeticallySearch;
using CompaniesHouse.Response.Search.CompanySearch;
using CompaniesHouse.Response.Search.DisqualifiedOfficersSearch;
using CompaniesHouse.Response.Search.DissolvedCompaniesSearch;
using CompaniesHouse.Response.Search.OfficerSearch;
using CompaniesHouse.UriBuilders;
using Officer = CompaniesHouse.Response.Officers.Officer;

namespace CompaniesHouse
{
    public class CompaniesHouseClient : ICompaniesHouseClient, IDisposable
    {
        private readonly ICompaniesHouseSearchClient _companiesHouseSearchClient;
        private readonly ICompaniesHouseCompanyProfileClient _companiesHouseCompanyProfileClient;
        private readonly ICompaniesHouseCompanyFilingHistoryClient _companiesHouseCompanyFilingHistoryClient;
        private readonly ICompaniesHouseOfficersClient _companiesHouseOfficersClient;
        private readonly ICompaniesHouseCompanyInsolvencyInformationClient _companiesHouseCompanyInsolvencyInformationClient;
        private readonly ICompaniesHouseAppointmentsClient _companiesHouseCompanyAppointmentsClient;
        private readonly ICompaniesHousePersonsWithSignificantControlClient _companiesHousePersonsWithSignificantControlClient;
        private readonly ICompaniesHouseChargesClient _companiesHouseChargesClient;
        private readonly ICompaniesHouseRegisteredOfficeAddressClient _companiesHouseRegisteredOfficeAddressClient;
        private readonly ICompaniesHouseOfficerByAppointmentClient _companiesHouseOfficerByAppointmentClient;
        private readonly ICompaniesHouseRegistersClient _companiesHouseRegistersClient;
        private readonly ICompaniesHouseDisqualifiedOfficerDetailsClient _companiesHouseDisqualifiedOfficerDetailsClient;
        private readonly HttpClient _httpClient;

        public CompaniesHouseClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _companiesHouseSearchClient = new CompaniesHouseSearchClient(_httpClient, new SearchUriBuilderFactory());
            _companiesHouseCompanyProfileClient = new CompaniesHouseCompanyProfileClient(_httpClient, new CompanyProfileUriBuilder());
            _companiesHouseCompanyFilingHistoryClient = new CompaniesHouseCompanyFilingHistoryClient(_httpClient, new CompanyFilingHistoryUriBuilder());
            _companiesHouseOfficersClient = new CompaniesHouseOfficersClient(_httpClient, new OfficersUriBuilder());
            _companiesHouseCompanyInsolvencyInformationClient = new CompaniesHouseCompanyInsolvencyInformationClient(_httpClient, new CompanyInsolvencyInformationUriBuilder());
            _companiesHouseCompanyAppointmentsClient = new CompaniesHouseAppointmentsClient(_httpClient, new AppointmentsUriBuilder());
            _companiesHousePersonsWithSignificantControlClient = new CompaniesHousePersonsWithSignificantControlClient(_httpClient, new PersonsWithSignificantControlBuilder());
            _companiesHouseChargesClient = new CompaniesHouseChargesClient(_httpClient, new ChargesUriBuilder());
            _companiesHouseRegisteredOfficeAddressClient = new CompaniesHouseRegisteredOfficeAddressClient(_httpClient, new RegisteredOfficeAddressUriBuilder());
            _companiesHouseOfficerByAppointmentClient = new CompaniesHouseOfficerByByAppointmentClient(_httpClient, new OfficersAppointmentUriBuilder());
            _companiesHouseRegistersClient = new CompaniesHouseRegistersClient(_httpClient, new CompanyRegistersUriBuilder());
            _companiesHouseDisqualifiedOfficerDetailsClient = new CompaniesHouseDisqualifiedOfficerDetailsClient(_httpClient, new DisqualifiedOfficerUriBuilder());
        }

        public CompaniesHouseClient(ICompaniesHouseSettings settings)
            : this(new HttpClientFactory(settings).CreateHttpClient())
        {
        }

        public Task<CompaniesHouseResponse<CompanySearch>> SearchCompanyAsync(SearchCompanyRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _companiesHouseSearchClient.SearchAsync<SearchCompanyRequest, CompanySearch>(request, cancellationToken);
        }

        public Task<CompaniesHouseResponse<OfficerSearch>> SearchOfficerAsync(SearchOfficerRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _companiesHouseSearchClient.SearchAsync<SearchOfficerRequest, OfficerSearch>(request, cancellationToken);
        }

        public Task<CompaniesHouseResponse<DisqualifiedOfficerSearch>> SearchDisqualifiedOfficerAsync(SearchDisqualifiedOfficerRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _companiesHouseSearchClient.SearchAsync<SearchDisqualifiedOfficerRequest, DisqualifiedOfficerSearch>(request, cancellationToken);
        }

        public Task<CompaniesHouseResponse<AllSearch>> SearchAllAsync(SearchAllRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _companiesHouseSearchClient.SearchAsync<SearchAllRequest, AllSearch>(request, cancellationToken);
        }

        public Task<CompaniesHouseResponse<CompaniesAlphabeticallySearch>> SearchCompaniesAlphabeticallyAsync(SearchCompaniesAlphabeticallyRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _companiesHouseSearchClient.SearchAsync<SearchCompaniesAlphabeticallyRequest, CompaniesAlphabeticallySearch>(request, cancellationToken);
        }

        public Task<CompaniesHouseResponse<DissolvedCompaniesSearch>> SearchDissolvedCompaniesAsync(SearchDissolvedCompaniesRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _companiesHouseSearchClient.SearchAsync<SearchDissolvedCompaniesRequest, DissolvedCompaniesSearch>(request, cancellationToken);
        }

        public Task<CompaniesHouseResponse<AdvancedCompanySearch>> AdvancedCompanySearchAsync(AdvancedCompanySearchRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _companiesHouseSearchClient.SearchAsync<AdvancedCompanySearchRequest, AdvancedCompanySearch>(request, cancellationToken);
        }

        public Task<CompaniesHouseResponse<CompanyProfile>> GetCompanyProfileAsync(string companyNumber, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _companiesHouseCompanyProfileClient.GetCompanyProfileAsync(companyNumber, cancellationToken);
        }

        public Task<CompaniesHouseResponse<CompanyFilingHistory>> GetCompanyFilingHistoryAsync(string companyNumber, int startIndex = 0, int pageSize = 25, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _companiesHouseCompanyFilingHistoryClient.GetCompanyFilingHistoryAsync(companyNumber, startIndex, pageSize, cancellationToken);
        }

        public Task<CompaniesHouseResponse<FilingHistoryItem>> GetFilingHistoryByTransactionAsync(string companyNumber, string transactionId, CancellationToken cancellationToken = default)
        {
            return _companiesHouseCompanyFilingHistoryClient.GetFilingHistoryByTransactionAsync(companyNumber, transactionId, cancellationToken);
        }

        // Companies House defaults officer lists to 35 items, unlike several other paged endpoints.
        public Task<CompaniesHouseResponse<Officers>> GetOfficersAsync(
            string companyNumber,
            int startIndex = 0,
            int pageSize = 35,
            string? registerType = null,
            bool? registerView = null,
            string? orderBy = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return _companiesHouseOfficersClient.GetOfficersAsync(companyNumber, startIndex, pageSize, registerType, registerView, orderBy, cancellationToken);
        }

        public Task<CompaniesHouseResponse<CompanyInsolvencyInformation>> GetCompanyInsolvencyInformationAsync(string companyNumber, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _companiesHouseCompanyInsolvencyInformationClient.GetCompanyInsolvencyInformationAsync(companyNumber, cancellationToken);
        }

        public Task<CompaniesHouseResponse<Appointments>> GetAppointmentsAsync(string officerId, int startIndex = 0, int pageSize = 25, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _companiesHouseCompanyAppointmentsClient.GetAppointmentsAsync(officerId, startIndex, pageSize,
                cancellationToken);
        }

        public Task<CompaniesHouseResponse<PersonsWithSignificantControl>> GetPersonsWithSignificantControlAsync(string companyNumber, int startIndex = 0, int pageSize = 25, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _companiesHousePersonsWithSignificantControlClient.GetPersonsWithSignificantControlAsync(companyNumber, startIndex, pageSize, cancellationToken);
        }

        public Task<CompaniesHouseResponse<Charges>> GetChargesListAsync(string companyNumber, int startIndex = 0, int pageSize = 25, CancellationToken cancellationToken = default)
        {
            return _companiesHouseChargesClient.GetChargesListAsync(companyNumber, startIndex, pageSize, cancellationToken);
        }

        public Task<CompaniesHouseResponse<Charge>> GetChargeByIdAsync(string companyNumber, string chargeId, CancellationToken cancellationToken = default)
        {
            return _companiesHouseChargesClient.GetChargeByIdAsync(companyNumber, chargeId, cancellationToken);
        }

        public Task<CompaniesHouseResponse<OfficeAddress>> GetRegisteredOfficeAddress(string companyNumber, CancellationToken cancellationToken = default)
        {
            return _companiesHouseRegisteredOfficeAddressClient.GetRegisteredOfficeAddress(companyNumber, cancellationToken);
        }

        public Task<CompaniesHouseResponse<Officer>> GetOfficerByAppointmentIdAsync(string companyNumber, string appointmentId, CancellationToken cancellationToken = default)
        {
            return _companiesHouseOfficerByAppointmentClient.GetOfficerByAppointmentIdAsync(companyNumber, appointmentId, cancellationToken);
        }

        public Task<CompaniesHouseResponse<CompanyRegisters>> GetCompanyRegistersAsync(string companyNumber, CancellationToken cancellationToken = default)
        {
            return _companiesHouseRegistersClient.GetCompanyRegistersAsync(companyNumber, cancellationToken);
        }

        public Task<CompaniesHouseResponse<NaturalDisqualification>> GetNaturalDisqualificationAsync(string officerId, CancellationToken cancellationToken = default)
        {
            return _companiesHouseDisqualifiedOfficerDetailsClient.GetNaturalDisqualificationAsync(officerId, cancellationToken);
        }

        public Task<CompaniesHouseResponse<CorporateDisqualification>> GetCorporateDisqualificationAsync(string officerId, CancellationToken cancellationToken = default)
        {
            return _companiesHouseDisqualifiedOfficerDetailsClient.GetCorporateDisqualificationAsync(officerId, cancellationToken);
        }

        public void Dispose() => _httpClient.Dispose();
    }
}
