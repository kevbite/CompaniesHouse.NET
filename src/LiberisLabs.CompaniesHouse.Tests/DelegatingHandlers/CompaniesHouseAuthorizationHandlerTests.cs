using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using LiberisLabs.CompaniesHouse.DelegatingHandlers;
using Moq;
using Moq.Protected;
using NUnit.Framework;

namespace LiberisLabs.CompaniesHouse.Tests.DelegatingHandlers
{
    [TestFixture]
    public class CompaniesHouseAuthorizationHandlerTests
    {
        private CompaniesHouseAuthorizationHandler _handler;
        private string _apiKey;
        private HttpRequestMessage _actual;

        [TestFixtureSetUp]
        public void GivenACompaniesHouseAuthorizationHandler()
        {
            var innerHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            innerHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .Callback((HttpRequestMessage r, CancellationToken c) => _actual = r)
                .ReturnsAsync(new HttpResponseMessage());

            _apiKey = "42c8154e-982d-4a62-913d-89aafb320dbc";
            _handler = new CompaniesHouseAuthorizationHandler(_apiKey)
            {
                InnerHandler = innerHandler.Object
            };
        }

        [SetUp]
        public void When()
        {
            var client = new HttpClient(_handler);
            client.GetAsync("http://liberislabs.com/");
        }

        [Test]
        public void ThenAuthorizationHeaderIsCorrect()
        {
            Assert.That(_actual.Headers.Authorization.Scheme, Is.EqualTo("Basic"));
            Assert.That(_actual.Headers.Authorization.Parameter, Is.EqualTo("NDJjODE1NGUtOTgyZC00YTYyLTkxM2QtODlhYWZiMzIwZGJj"));
        }
        
    }
}
