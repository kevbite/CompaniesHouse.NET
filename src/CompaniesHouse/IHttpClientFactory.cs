using System.Net.Http;

namespace CompaniesHouse
{
    public interface IHttpClientFactory
    {
        HttpClient CreateHttpClient();
    }
}