using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.Response.Appointments;
using CompaniesHouse.UriBuilders;

namespace CompaniesHouse
{
    using CompaniesHouse.Extensions;

    public class CompaniesHouseAppointmentsClient : ICompaniesHouseAppointmentsClient
    {
        private readonly HttpClient _httpClient;
        private readonly IAppointmentsUriBuilder _appointmentsUriBuilder;

        public CompaniesHouseAppointmentsClient(HttpClient httpClient, IAppointmentsUriBuilder appointmentsUriBuilder)
        {
            _httpClient = httpClient;
            _appointmentsUriBuilder = appointmentsUriBuilder;
        }

        public async Task<CompaniesHouseClientResponse<Appointments>> GetAppointmentsAsync(string officerId, int startIndex, int pageSize, CancellationToken cancellationToken)
        {
            var requestUri = _appointmentsUriBuilder.Build(officerId, startIndex, pageSize);

            var response = await _httpClient.GetAsync(requestUri, cancellationToken).ConfigureAwait(false);

            return await response.ToCompaniesHouseClientResponseAsync<Appointments>(cancellationToken).ConfigureAwait(false);
        }
    }
}