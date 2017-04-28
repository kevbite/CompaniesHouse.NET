using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.Response.Insolvency;
using Newtonsoft.Json;

namespace CompaniesHouse
{
    public class CompaniesHouseCompanyInsolvencyInformationClient : ICompaniesHouseCompanyInsolvencyInformationClient
    {
        private readonly HttpClient _httpClient;

        public CompaniesHouseCompanyInsolvencyInformationClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CompaniesHouseClientResponse<CompanyInsolvencyInformation>> GetCompanyInsolvencyInformationAsync(string companyNumber, CancellationToken cancellationToken = default (CancellationToken))
        {
            var requestUri = $"company/{companyNumber}/insolvency";

            var response = await _httpClient.GetAsync(requestUri, cancellationToken).ConfigureAwait(false);
                
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsJsonAsync<CompanyInsolvencyInformation>().ConfigureAwait(false);

            return new CompaniesHouseClientResponse<CompanyInsolvencyInformation>(result);
        }
    }

    public static class HttpContentExtensions
    {
        public static async Task<T> ReadAsJsonAsync<T>(this HttpContent content)
        {
            var input = await content.ReadAsStringAsync()
                .ConfigureAwait(false);

            var obj = JsonConvert.DeserializeObject<T>(input);

            return obj;
        }
    }
}