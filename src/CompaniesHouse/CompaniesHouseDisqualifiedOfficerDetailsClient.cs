using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.Response.DisqualifiedOfficers;
using CompaniesHouse.UriBuilders;

namespace CompaniesHouse
{
    using CompaniesHouse.Extensions;

    public class CompaniesHouseDisqualifiedOfficerDetailsClient : ICompaniesHouseDisqualifiedOfficerDetailsClient
    {
        private readonly HttpClient _httpClient;
        private readonly IDisqualifiedOfficerUriBuilder _disqualifiedOfficerUriBuilder;

        public CompaniesHouseDisqualifiedOfficerDetailsClient(HttpClient httpClient, IDisqualifiedOfficerUriBuilder disqualifiedOfficerUriBuilder)
        {
            _httpClient = httpClient;
            _disqualifiedOfficerUriBuilder = disqualifiedOfficerUriBuilder;
        }

        public async Task<CompaniesHouseResponse<NaturalDisqualification>> GetNaturalDisqualificationAsync(string officerId, CancellationToken cancellationToken = default)
        {
            var requestUri = _disqualifiedOfficerUriBuilder.BuildNatural(officerId);
            var response = await _httpClient.GetAsync(requestUri, cancellationToken).ConfigureAwait(false);

            return await response.ToCompaniesHouseResponseAsync<NaturalDisqualification>(cancellationToken).ConfigureAwait(false);
        }

        public async Task<CompaniesHouseResponse<CorporateDisqualification>> GetCorporateDisqualificationAsync(string officerId, CancellationToken cancellationToken = default)
        {
            var requestUri = _disqualifiedOfficerUriBuilder.BuildCorporate(officerId);
            var response = await _httpClient.GetAsync(requestUri, cancellationToken).ConfigureAwait(false);

            return await response.ToCompaniesHouseResponseAsync<CorporateDisqualification>(cancellationToken).ConfigureAwait(false);
        }
    }
}
