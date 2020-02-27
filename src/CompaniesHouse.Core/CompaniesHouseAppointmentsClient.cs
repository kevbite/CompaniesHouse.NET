using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.Response.Appointments;

namespace CompaniesHouse
{
    public class CompaniesHouseAppointmentsClient : ICompaniesHouseAppointmentsClient
    {
        private readonly HttpClient _httpClient;

        public CompaniesHouseAppointmentsClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CompaniesHouseClientResponse<Appointments>> GetAppointmentsAsync(string officerId, int startIndex, int pageSize, CancellationToken cancellationToken)
        {
            var requestUri = $"officers/{officerId}/appointments?items_per_page={pageSize}&start_index={startIndex}";

            var response = await _httpClient.GetAsync(requestUri, cancellationToken).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsJsonAsync<Appointments>().ConfigureAwait(false);

            return new CompaniesHouseClientResponse<Appointments>(result);
        }
    }
}