using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CompaniesHouse.Tests
{
    public class TooManyRequestsHttpMessageHandler : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new HttpResponseMessage((HttpStatusCode)429)
            {
                Content = new StringContent("", Encoding.UTF8, "application/json")
            });
        }
    }
}