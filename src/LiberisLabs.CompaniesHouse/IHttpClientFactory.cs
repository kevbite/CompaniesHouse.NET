using System.Net.Http;

namespace LiberisLabs.CompaniesHouse
{
    public interface IHttpClientFactory
    {
        HttpClient CreateHttpClient();
    }
}