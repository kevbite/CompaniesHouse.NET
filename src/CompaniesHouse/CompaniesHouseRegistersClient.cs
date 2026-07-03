using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.Response.Registers;
using CompaniesHouse.UriBuilders;

namespace CompaniesHouse
{
    using CompaniesHouse.Extensions;

    public class CompaniesHouseRegistersClient : ICompaniesHouseRegistersClient
    {
        private readonly HttpClient _httpClient;
        private readonly ICompanyRegistersUriBuilder _companyRegistersUriBuilder;

        public CompaniesHouseRegistersClient(HttpClient httpClient, ICompanyRegistersUriBuilder companyRegistersUriBuilder)
        {
            _httpClient = httpClient;
            _companyRegistersUriBuilder = companyRegistersUriBuilder;
        }

        public async Task<CompaniesHouseResponse<CompanyRegisters>> GetCompanyRegistersAsync(string companyNumber, CancellationToken cancellationToken = default)
        {
            var requestUri = _companyRegistersUriBuilder.Build(companyNumber);
            var response = await _httpClient.GetAsync(requestUri, cancellationToken).ConfigureAwait(false);

            return await response.ToCompaniesHouseResponseAsync<CompanyRegisters>(cancellationToken).ConfigureAwait(false);
        }
    }
}
