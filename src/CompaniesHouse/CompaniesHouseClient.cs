﻿using System.Net.Http;
using CompaniesHouse.Request;
using CompaniesHouse.Response.Appointments;
using CompaniesHouse.Response.Charges;
using CompaniesHouse.Response.CompanyFiling;
using CompaniesHouse.Response.CompanyProfile;
using CompaniesHouse.Response.Insolvency;
using CompaniesHouse.Response.Officers;
using CompaniesHouse.Response.PersonsWithSignificantControl;
using CompaniesHouse.Response.RegisteredOfficeAddress;
using CompaniesHouse.Response.Search.AllSearch;
using CompaniesHouse.Response.Search.CompanySearch;
using CompaniesHouse.Response.Search.DisqualifiedOfficersSearch;
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
        private readonly HttpClient _httpClient;

        public CompaniesHouseClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _companiesHouseSearchClient = new CompaniesHouseSearchClient(_httpClient, new SearchUriBuilderFactory());
            _companiesHouseCompanyProfileClient = new CompaniesHouseCompanyProfileClient(_httpClient, new CompanyProfileUriBuilder());
            _companiesHouseCompanyFilingHistoryClient = new CompaniesHouseCompanyFilingHistoryClient(_httpClient, new CompanyFilingHistoryUriBuilder());
            _companiesHouseOfficersClient = new CompaniesHouseOfficersClient(_httpClient, new OfficersUriBuilder());
            _companiesHouseCompanyInsolvencyInformationClient = new CompaniesHouseCompanyInsolvencyInformationClient(_httpClient);
            _companiesHouseCompanyAppointmentsClient = new CompaniesHouseAppointmentsClient(_httpClient);
            _companiesHousePersonsWithSignificantControlClient = new CompaniesHousePersonsWithSignificantControlClient(_httpClient, new PersonsWithSignificantControlBuilder());
            _companiesHouseChargesClient = new CompaniesHouseChargesClient(_httpClient, new ChargesUriBuilder());
            _companiesHouseRegisteredOfficeAddressClient = new CompaniesHouseRegisteredOfficeAddressClient(_httpClient, new RegisteredOfficeAddressUriBuilder());
            _companiesHouseOfficerByAppointmentClient = new CompaniesHouseOfficerByByAppointmentClient(_httpClient, new OfficersAppointmentUriBuilder());
        }
        
        public CompaniesHouseClient(ICompaniesHouseSettings settings)
            :this(new HttpClientFactory(settings).CreateHttpClient())
        {
        }

        public Task<CompaniesHouseClientResponse<CompanySearch>> SearchCompanyAsync(SearchCompanyRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _companiesHouseSearchClient.SearchAsync<SearchCompanyRequest, CompanySearch>(request, cancellationToken);
        }
        
        public Task<CompaniesHouseClientResponse<CompanySearch>> SearchCompanyAdvancedAsync(AdvancedSearchCompanyRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _companiesHouseSearchClient.SearchAsync<AdvancedSearchCompanyRequest, CompanySearch>(request, cancellationToken);
        }

        public Task<CompaniesHouseClientResponse<OfficerSearch>> SearchOfficerAsync(SearchOfficerRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _companiesHouseSearchClient.SearchAsync<SearchOfficerRequest, OfficerSearch>(request, cancellationToken);
        }

        public Task<CompaniesHouseClientResponse<DisqualifiedOfficerSearch>> SearchDisqualifiedOfficerAsync(SearchDisqualifiedOfficerRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _companiesHouseSearchClient.SearchAsync<SearchDisqualifiedOfficerRequest, DisqualifiedOfficerSearch>(request, cancellationToken);
        }

        public Task<CompaniesHouseClientResponse<AllSearch>> SearchAllAsync(SearchAllRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _companiesHouseSearchClient.SearchAsync<SearchAllRequest, AllSearch>(request, cancellationToken);
        }

        public Task<CompaniesHouseClientResponse<CompanyProfile>> GetCompanyProfileAsync(string companyNumber, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _companiesHouseCompanyProfileClient.GetCompanyProfileAsync(companyNumber, cancellationToken);
        }

        public Task<CompaniesHouseClientResponse<CompanyFilingHistory>> GetCompanyFilingHistoryAsync(string companyNumber, int startIndex = 0, int pageSize = 25, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _companiesHouseCompanyFilingHistoryClient.GetCompanyFilingHistoryAsync(companyNumber, startIndex, pageSize, cancellationToken);
        }
        
        public Task<CompaniesHouseClientResponse<FilingHistoryItem>> GetFilingHistoryByTransactionAsync(string companyNumber, string transactionId, CancellationToken cancellationToken = default)
        {
            return _companiesHouseCompanyFilingHistoryClient.GetFilingHistoryByTransactionAsync(companyNumber, transactionId, cancellationToken);
        }

        public Task<CompaniesHouseClientResponse<Officers>> GetOfficersAsync(string companyNumber, int startIndex = 0, int pageSize = 25, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _companiesHouseOfficersClient.GetOfficersAsync(companyNumber, startIndex, pageSize, cancellationToken);
        }

        public Task<CompaniesHouseClientResponse<CompanyInsolvencyInformation>> GetCompanyInsolvencyInformationAsync(string companyNumber, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _companiesHouseCompanyInsolvencyInformationClient.GetCompanyInsolvencyInformationAsync(companyNumber, cancellationToken);
        }

        public Task<CompaniesHouseClientResponse<Appointments>> GetAppointmentsAsync(string officerId, int startIndex = 0, int pageSize = 25, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _companiesHouseCompanyAppointmentsClient.GetAppointmentsAsync(officerId, startIndex, pageSize,
                cancellationToken);
        }

        public Task<CompaniesHouseClientResponse<PersonsWithSignificantControl>> GetPersonsWithSignificantControlAsync(string companyNumber, int startIndex = 0, int pageSize = 25, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _companiesHousePersonsWithSignificantControlClient.GetPersonsWithSignificantControlAsync(companyNumber, startIndex, pageSize, cancellationToken);
        }

        public Task<CompaniesHouseClientResponse<Charges>> GetChargesListAsync(string companyNumber, int startIndex = 0, int pageSize = 25, CancellationToken cancellationToken = default)
        {
            return _companiesHouseChargesClient.GetChargesListAsync(companyNumber,startIndex, pageSize, cancellationToken);
        }

        public Task<CompaniesHouseClientResponse<Charge>> GetChargeByIdAsync(string companyNumber, string chargeId, CancellationToken cancellationToken = default)
        {
            return _companiesHouseChargesClient.GetChargeByIdAsync(companyNumber, chargeId, cancellationToken);
        }

        public Task<CompaniesHouseClientResponse<OfficeAddress>> GetRegisteredOfficeAddress(string companyNumber, CancellationToken cancellationToken = default)
        {
            return _companiesHouseRegisteredOfficeAddressClient.GetRegisteredOfficeAddress(companyNumber, cancellationToken);
        }

        public Task<CompaniesHouseClientResponse<Officer>> GetOfficerByAppointmentIdAsync(string companyNumber, string appointmentId, CancellationToken cancellationToken = default)
        {
            return _companiesHouseOfficerByAppointmentClient.GetOfficerByAppointmentIdAsync(companyNumber, appointmentId, cancellationToken);
        }

        public void Dispose() => _httpClient.Dispose();
    }
}
