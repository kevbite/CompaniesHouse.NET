using CompaniesHouse.Response.PersonsWithSignificantControl;
using CompaniesHouse.UriBuilders;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace CompaniesHouse
{
    using CompaniesHouse.Extensions;

    public class CompaniesHousePersonsWithSignificantControlClient : ICompaniesHousePersonsWithSignificantControlClient
    {
        private readonly HttpClient _httpClient;
        private readonly IPersonsWithSignificantControlBuilder _personsWithSignificantControlBuilder;

        public CompaniesHousePersonsWithSignificantControlClient(HttpClient httpClient, IPersonsWithSignificantControlBuilder personsWithSignificantControlBuilder)
        {
            _httpClient = httpClient;
            _personsWithSignificantControlBuilder = personsWithSignificantControlBuilder;
        }

        public async Task<CompaniesHouseResponse<PersonsWithSignificantControl>> GetPersonsWithSignificantControlAsync(string companyNumber, int startIndex, int pageSize, CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestUri = _personsWithSignificantControlBuilder.Build(companyNumber, startIndex, pageSize);

            var response = await _httpClient.GetAsync(requestUri, cancellationToken).ConfigureAwait(false);

            return await response.ToCompaniesHouseResponseAsync<PersonsWithSignificantControl>(cancellationToken).ConfigureAwait(false);
        }
    }
}
