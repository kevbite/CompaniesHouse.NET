using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.Response.Insolvency;

namespace CompaniesHouse
{
    public class CompaniesHouseCompanyInsolvencyInformationClient : ICompaniesHouseCompanyInsolvencyInformationClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CompaniesHouseCompanyInsolvencyInformationClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<CompaniesHouseClientResponse<CompanyInsolvencyInformation>> GetCompanyInsolvencyInformationAsync(string companyNumber, CancellationToken cancellationToken = default (CancellationToken))
        {
            using (var httpClient = _httpClientFactory.CreateHttpClient())
            {
                var requestUri = $"company/{companyNumber}/insolvency";

                var response = await httpClient.GetAsync(requestUri, cancellationToken).ConfigureAwait(false);
                
                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadAsAsync<CompanyInsolvencyInformation>(cancellationToken).ConfigureAwait(false);

                return new CompaniesHouseClientResponse<CompanyInsolvencyInformation>(result);
            }
        }
    }
}