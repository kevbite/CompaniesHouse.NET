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
        private readonly IApiKeyProvider _apiKeyProvider;

        public CompaniesHouseAuthorizationHandler(IApiKeyProvider apiKeyProvider)
        {
            _apiKeyProvider = apiKeyProvider;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var apiKey = await _apiKeyProvider.GetApiKey();
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Base64Encode(apiKey));

            return await base.SendAsync(request, cancellationToken);
        }

        private string Base64Encode(string apiKey)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(apiKey));
        }
    }
}
