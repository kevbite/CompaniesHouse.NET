using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.Response.Officers;
using CompaniesHouse.UriBuilders;

namespace CompaniesHouse
{
    public class CompaniesHouseOfficerByByAppointmentClient : ICompaniesHouseOfficerByAppointmentClient
    {
        private readonly HttpClient _httpClient;
        private readonly IOfficersAppointmentUriBuilder _officersAppointmentUriBuilder;

        public CompaniesHouseOfficerByByAppointmentClient(HttpClient httpClient, IOfficersAppointmentUriBuilder officersAppointmentUriBuilder)
        {
            _httpClient = httpClient;
            _officersAppointmentUriBuilder = officersAppointmentUriBuilder;
        }

        public async Task<CompaniesHouseClientResponse<Officer>> GetOfficerByAppointmentIdAsync(string companyNumber, string appointmentId, CancellationToken cancellationToken = default)
        {
            var requestUri = _officersAppointmentUriBuilder.Build(companyNumber, appointmentId);

            var response = await _httpClient.GetAsync(requestUri, cancellationToken).ConfigureAwait(false);

            // Return a null profile on 404s, but raise exception for all other error codes
            if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
                response.EnsureSuccessStatusCode();

            var result = response.IsSuccessStatusCode
                ? await response.Content.ReadAsJsonAsync<Officer>().ConfigureAwait(false)
                : null;

            return new CompaniesHouseClientResponse<Officer>(result);
        }
    }
}