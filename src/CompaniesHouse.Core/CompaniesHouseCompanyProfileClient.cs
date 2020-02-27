using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.Core.Response.CompanyProfile;
using CompaniesHouse.Core.UriBuilders;

namespace CompaniesHouse.Core
{
    public class CompaniesHouseCompanyProfileClient : ICompaniesHouseCompanyProfileClient
    {
        private readonly HttpClient _httpClient;
        private readonly ICompanyProfileUriBuilder _companyProfileUriBuilder;

        public CompaniesHouseCompanyProfileClient(HttpClient httpClient, ICompanyProfileUriBuilder companyProfileUriBuilder)
        {
            _httpClient = httpClient;
            _companyProfileUriBuilder = companyProfileUriBuilder;
        }

        public async Task<CompaniesHouseClientResponse<CompanyProfile>> GetCompanyProfileAsync(string companyNumber, CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestUri = _companyProfileUriBuilder.Build(companyNumber);

            var response = await _httpClient.GetAsync(requestUri, cancellationToken).ConfigureAwait(false);

            // Return a null profile on 404s, but raise exception for all other error codes
            if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
                response.EnsureSuccessStatusCode();

            CompanyProfile result = response.IsSuccessStatusCode
                ? await response.Content.ReadAsJsonAsync<CompanyProfile>().ConfigureAwait(false)
                : null;

            return new CompaniesHouseClientResponse<CompanyProfile>(result);
        }
    }
}