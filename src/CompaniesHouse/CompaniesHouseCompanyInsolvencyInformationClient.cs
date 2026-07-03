using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.Response.Insolvency;
using CompaniesHouse.UriBuilders;

namespace CompaniesHouse
{
    using CompaniesHouse.Extensions;

    public class CompaniesHouseCompanyInsolvencyInformationClient : ICompaniesHouseCompanyInsolvencyInformationClient
    {
        private readonly HttpClient _httpClient;
        private readonly ICompanyInsolvencyInformationUriBuilder _uriBuilder;

        public CompaniesHouseCompanyInsolvencyInformationClient(HttpClient httpClient, ICompanyInsolvencyInformationUriBuilder uriBuilder)
        {
            _httpClient = httpClient;
            _uriBuilder = uriBuilder;
        }

        public async Task<CompaniesHouseResponse<CompanyInsolvencyInformation>> GetCompanyInsolvencyInformationAsync(string companyNumber, CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestUri = _uriBuilder.Build(companyNumber);

            var response = await _httpClient.GetAsync(requestUri, cancellationToken).ConfigureAwait(false);

            return await response.ToCompaniesHouseResponseAsync<CompanyInsolvencyInformation>(cancellationToken).ConfigureAwait(false);
        }
    }
}