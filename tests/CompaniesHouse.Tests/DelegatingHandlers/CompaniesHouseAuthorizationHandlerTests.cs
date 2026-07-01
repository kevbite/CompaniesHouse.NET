using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.DelegatingHandlers;
using Moq;
using Moq.Protected;
using Shouldly;
using Xunit;

namespace CompaniesHouse.Tests.DelegatingHandlers
{
    public class CompaniesHouseAuthorizationHandlerTests
    {
        private CompaniesHouseAuthorizationHandler _handler;
        private string _apiKey;
        private HttpRequestMessage _actual;

        public CompaniesHouseAuthorizationHandlerTests()
        {
            var innerHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            innerHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .Callback((HttpRequestMessage r, CancellationToken c) => _actual = r)
                .ReturnsAsync(new HttpResponseMessage());

            _apiKey = "42c8154e-982d-4a62-913d-89aafb320dbc";
            _handler = new CompaniesHouseAuthorizationHandler(new StaticApiKeyProvider(_apiKey))
            {
                InnerHandler = innerHandler.Object
            };
            var client = new HttpClient(_handler);
            client.GetAsync("http://liberislabs.com/").GetAwaiter().GetResult();
        }

        [Fact]
        public void ThenAuthorizationHeaderIsCorrect()
        {
            _actual.Headers.Authorization.Scheme.ShouldBe("Basic");
            _actual.Headers.Authorization.Parameter.ShouldBe("NDJjODE1NGUtOTgyZC00YTYyLTkxM2QtODlhYWZiMzIwZGJj");
        }
        
    }
}
