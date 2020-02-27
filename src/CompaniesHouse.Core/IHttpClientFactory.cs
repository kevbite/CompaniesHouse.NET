using System.Net.Http;

namespace CompaniesHouse.Core
{
    public interface IHttpClientFactory
    {
        HttpClient CreateHttpClient();
    }
}