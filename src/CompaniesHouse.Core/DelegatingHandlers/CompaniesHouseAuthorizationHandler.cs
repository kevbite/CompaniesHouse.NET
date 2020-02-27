using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CompaniesHouse.DelegatingHandlers
{
    public class CompaniesHouseAuthorizationHandler : DelegatingHandler
    {
        private readonly string _apiKey;

        public CompaniesHouseAuthorizationHandler(string apiKey)
        {
            _apiKey = apiKey;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Base64Encode(_apiKey));

            return base.SendAsync(request, cancellationToken);
        }

        private string Base64Encode(string apiKey)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(apiKey));
        }
    }
}
