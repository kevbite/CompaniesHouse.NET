using CompaniesHouse.Core.Response.PersonsWithSignificantControl;
using CompaniesHouse.Core.UriBuilders;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace CompaniesHouse.Core
{
    public class CompaniesHousePersonsWithSignificantControlClient : ICompaniesHousePersonsWithSignificantControlClient
    {
        private readonly HttpClient _httpClient;
        private readonly IPersonsWithSignificantControlBuilder _personsWithSignificantControlBuilder;

        public CompaniesHousePersonsWithSignificantControlClient(HttpClient httpClient, IPersonsWithSignificantControlBuilder personsWithSignificantControlBuilder)
        {
            _httpClient = httpClient;
            _personsWithSignificantControlBuilder = personsWithSignificantControlBuilder;
        }

        public async Task<CompaniesHouseClientResponse<PersonsWithSignificantControl>> GetPersonsWithSignificantControlAsync(string companyNumber, int startIndex, int pageSize, CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestUri = _personsWithSignificantControlBuilder.Build(companyNumber, startIndex, pageSize);

            var response = await _httpClient.GetAsync(requestUri, cancellationToken).ConfigureAwait(false);

            // Return a null profile on 404s, but raise exception for all other error codes
            if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
                response.EnsureSuccessStatusCode();

            var result = response.IsSuccessStatusCode
                ? await response.Content.ReadAsJsonAsync<PersonsWithSignificantControl>().ConfigureAwait(false)
                : null;

            return new CompaniesHouseClientResponse<PersonsWithSignificantControl>(result);
        }
    }
}
