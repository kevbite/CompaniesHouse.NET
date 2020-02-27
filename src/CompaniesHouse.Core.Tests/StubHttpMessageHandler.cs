using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CompaniesHouse.Tests
{
    public class StubHttpMessageHandler : HttpMessageHandler
    {
        private readonly Uri _catchUri;
        private readonly string _response;
        private readonly string _mediaType;

        public StubHttpMessageHandler(Uri catchUri, string response, string mediaType = "application/json")
        {
            _catchUri = catchUri;
            _response = response;
            _mediaType = mediaType;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.RequestUri != _catchUri) throw new Exception("Uri did not match");

            return Task.FromResult(new HttpResponseMessage
            {
                Content = new StringContent(_response, Encoding.UTF8, _mediaType)
            });
        }
    }
}