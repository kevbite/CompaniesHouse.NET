using System.Net;
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

        public async Task<CompaniesHouseClientResponse<Charges>> GetChargesListAsync(string companyNumber, int startIndex, int pageSize, CancellationToken cancellationToken = default)
        {
            var requestUri = _chargesUriBuilder.Build(companyNumber, startIndex, pageSize);
            var response = await _httpClient.GetAsync(requestUri, cancellationToken).ConfigureAwait(false);

            if (response.StatusCode != HttpStatusCode.NotFound)
                response.EnsureSuccessStatusCode2();

            var data = response.IsSuccessStatusCode
                ? await response.Content.ReadAsJsonAsync<Charges>()
                : null;

            return new CompaniesHouseClientResponse<Charges>(data);
        }

        public async Task<CompaniesHouseClientResponse<Charge>> GetChargeByIdAsync(string companyNumber, string chargeId, CancellationToken cancellationToken = default)
        {
            var requestUri = _chargesUriBuilder.Build(companyNumber, chargeId);
            var response = await _httpClient.GetAsync(requestUri, cancellationToken).ConfigureAwait(false);

            if (response.StatusCode != HttpStatusCode.NotFound)
                response.EnsureSuccessStatusCode2();

            var data = response.IsSuccessStatusCode
                ? await response.Content.ReadAsJsonAsync<Charge>()
                : null;

            return new CompaniesHouseClientResponse<Charge>(data);
        }
    }
}