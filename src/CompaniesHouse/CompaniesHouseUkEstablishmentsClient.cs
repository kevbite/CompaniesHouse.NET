using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.Response.UkEstablishments;
using CompaniesHouse.UriBuilders;

namespace CompaniesHouse
{
    using CompaniesHouse.Extensions;

    public class CompaniesHouseUkEstablishmentsClient : ICompaniesHouseUkEstablishmentsClient
    {
        private readonly HttpClient _httpClient;
        private readonly ICompanyUkEstablishmentsUriBuilder _uriBuilder;

        public CompaniesHouseUkEstablishmentsClient(HttpClient httpClient, ICompanyUkEstablishmentsUriBuilder uriBuilder)
        {
            _httpClient = httpClient;
            _uriBuilder = uriBuilder;
        }

        public async Task<CompaniesHouseResponse<CompanyUkEstablishments>> GetCompanyUkEstablishmentsAsync(string companyNumber, CancellationToken cancellationToken = default)
        {
            var requestUri = _uriBuilder.Build(companyNumber);
            var response = await _httpClient.GetAsync(requestUri, cancellationToken).ConfigureAwait(false);
            return await response.ToCompaniesHouseResponseAsync<CompanyUkEstablishments>(cancellationToken).ConfigureAwait(false);
        }
    }
}
