using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.Response.RegisteredOfficeAddress;
using CompaniesHouse.UriBuilders;

namespace CompaniesHouse
{
    using CompaniesHouse.Extensions;

    public class CompaniesHouseRegisteredOfficeAddressClient : ICompaniesHouseRegisteredOfficeAddressClient
    {
        private readonly HttpClient _httpClient;
        private readonly IRegisteredOfficeAddressUriBuilder _registeredOfficeAddressUriBuilder;

        public CompaniesHouseRegisteredOfficeAddressClient(HttpClient httpClient, IRegisteredOfficeAddressUriBuilder registeredOfficeAddressUriBuilder)
        {
            _httpClient = httpClient;
            _registeredOfficeAddressUriBuilder = registeredOfficeAddressUriBuilder;
        }

        public async Task<CompaniesHouseClientResponse<OfficeAddress>> GetRegisteredOfficeAddress(string companyNumber, CancellationToken cancellationToken = default)
        {
            var requestUri = _registeredOfficeAddressUriBuilder.Build(companyNumber);
            var response = await _httpClient.GetAsync(requestUri, cancellationToken).ConfigureAwait(false);

            if (response.StatusCode != HttpStatusCode.NotFound)
                response.EnsureSuccessStatusCode2();

            var data = response.IsSuccessStatusCode
                ? await response.Content.ReadAsJsonAsync<OfficeAddress>()
                : null;

            return new CompaniesHouseClientResponse<OfficeAddress>(data);
        }
    }
}