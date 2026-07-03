using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.Response.Officers;
using CompaniesHouse.UriBuilders;

namespace CompaniesHouse
{
    using CompaniesHouse.Extensions;

    public class CompaniesHouseOfficerByByAppointmentClient : ICompaniesHouseOfficerByAppointmentClient
    {
        private readonly HttpClient _httpClient;
        private readonly IOfficersAppointmentUriBuilder _officersAppointmentUriBuilder;

        public CompaniesHouseOfficerByByAppointmentClient(HttpClient httpClient, IOfficersAppointmentUriBuilder officersAppointmentUriBuilder)
        {
            _httpClient = httpClient;
            _officersAppointmentUriBuilder = officersAppointmentUriBuilder;
        }

        public async Task<CompaniesHouseResponse<Officer>> GetOfficerByAppointmentIdAsync(string companyNumber, string appointmentId, CancellationToken cancellationToken = default)
        {
            var requestUri = _officersAppointmentUriBuilder.Build(companyNumber, appointmentId);

            var response = await _httpClient.GetAsync(requestUri, cancellationToken).ConfigureAwait(false);

            return await response.ToCompaniesHouseResponseAsync<Officer>(cancellationToken).ConfigureAwait(false);
        }
    }
}