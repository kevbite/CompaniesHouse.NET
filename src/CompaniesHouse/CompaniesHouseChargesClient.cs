using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.Response.Charges;
using CompaniesHouse.UriBuilders;

namespace CompaniesHouse
{
    using CompaniesHouse.Extensions;

    public class CompaniesHouseChargesClient : ICompaniesHouseChargesClient
    {
        private readonly HttpClient _httpClient;
        private readonly IChargesUriBuilder _chargesUriBuilder;

        public CompaniesHouseChargesClient(HttpClient httpClient, IChargesUriBuilder chargesUriBuilder)
        {
            _httpClient = httpClient;
            _chargesUriBuilder = chargesUriBuilder;
        }

        public async Task<CompaniesHouseResponse<Charges>> GetChargesListAsync(string companyNumber, int startIndex, int pageSize, CancellationToken cancellationToken = default)
        {
            var requestUri = _chargesUriBuilder.Build(companyNumber, startIndex, pageSize);
            var response = await _httpClient.GetAsync(requestUri, cancellationToken).ConfigureAwait(false);

            return await response.ToCompaniesHouseResponseAsync<Charges>(cancellationToken).ConfigureAwait(false);
        }

        public async Task<CompaniesHouseResponse<Charge>> GetChargeByIdAsync(string companyNumber, string chargeId, CancellationToken cancellationToken = default)
        {
            var requestUri = _chargesUriBuilder.Build(companyNumber, chargeId);
            var response = await _httpClient.GetAsync(requestUri, cancellationToken).ConfigureAwait(false);

            return await response.ToCompaniesHouseResponseAsync<Charge>(cancellationToken).ConfigureAwait(false);
        }
    }
}