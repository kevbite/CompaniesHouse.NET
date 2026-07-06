using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.Response.CompanyProfile;
using CompaniesHouse.UriBuilders;

namespace CompaniesHouse
{
    using CompaniesHouse.Extensions;

    public class CompaniesHouseCompanyProfileClient : ICompaniesHouseCompanyProfileClient
    {
        private readonly HttpClient _httpClient;
        private readonly ICompanyProfileUriBuilder _companyProfileUriBuilder;

        public CompaniesHouseCompanyProfileClient(HttpClient httpClient, ICompanyProfileUriBuilder companyProfileUriBuilder)
        {
            _httpClient = httpClient;
            _companyProfileUriBuilder = companyProfileUriBuilder;
        }

        public async Task<CompaniesHouseResponse<CompanyProfile>> GetCompanyProfileAsync(string companyNumber, CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestUri = _companyProfileUriBuilder.Build(companyNumber);

            var response = await _httpClient.GetAsync(requestUri, cancellationToken).ConfigureAwait(false);

            return await response.ToCompaniesHouseResponseAsync<CompanyProfile>(cancellationToken).ConfigureAwait(false);
        }
    }
}