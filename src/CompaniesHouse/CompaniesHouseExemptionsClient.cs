using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.Response.Exemptions;
using CompaniesHouse.UriBuilders;

namespace CompaniesHouse
{
    using CompaniesHouse.Extensions;

    public class CompaniesHouseExemptionsClient : ICompaniesHouseExemptionsClient
    {
        private readonly HttpClient _httpClient;
        private readonly ICompanyExemptionsUriBuilder _uriBuilder;

        public CompaniesHouseExemptionsClient(HttpClient httpClient, ICompanyExemptionsUriBuilder uriBuilder)
        {
            _httpClient = httpClient;
            _uriBuilder = uriBuilder;
        }

        public async Task<CompaniesHouseResponse<CompanyExemptions>> GetCompanyExemptionsAsync(string companyNumber, CancellationToken cancellationToken = default)
        {
            var requestUri = _uriBuilder.Build(companyNumber);
            var response = await _httpClient.GetAsync(requestUri, cancellationToken).ConfigureAwait(false);
            return await response.ToCompaniesHouseResponseAsync<CompanyExemptions>(cancellationToken).ConfigureAwait(false);
        }
    }
}
