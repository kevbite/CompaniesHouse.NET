namespace CompaniesHouse.Tests.Extensions
{
    using System;
    using System.Net.Http.Json;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using CompaniesHouse.Extensions;
    using Shouldly;
    using Xunit;

    public class HttpResponseMessageExtensionsTests
    {
        [Theory]
        [InlineData(200)]
        [InlineData(201)]
        [InlineData(204)]
        public async Task GivenAnHttpResponse_WhenTheStatusCodeIs2xx_ThenReturnsSuccess(int statusCode)
        {
            var sut = new HttpResponseMessage((HttpStatusCode)statusCode)
            {
                Content = JsonContent.Create(new TestPayload { Value = "ok" })
            };

            var response = await sut.ToCompaniesHouseResponseAsync<TestPayload>();

            var success = response.ShouldBeOfType<CompaniesHouseResponse<TestPayload>.Success>();
            success.Data.ShouldNotBeNull();
            success.Data.Value.ShouldBe("ok");
            success.StatusCode.ShouldBe(statusCode);
            success.Headers.ShouldBe(sut.Headers);
        }

        [Fact]
        public async Task GivenAnHttpResponse_WhenTheStatusCodeIs404_ThenReturnsNotFound()
        {
            var sut = new HttpResponseMessage(HttpStatusCode.NotFound) { ReasonPhrase = "Not Found" };

            var response = await sut.ToCompaniesHouseResponseAsync<TestPayload>();

            var notFound = response.ShouldBeOfType<CompaniesHouseResponse<TestPayload>.NotFound>();
            notFound.StatusCode.ShouldBe(404);
            notFound.ReasonPhrase.ShouldBe("Not Found");
        }

        [Fact]
        public async Task GivenAnHttpResponse_WhenTheStatusCodeIs429_ThenReturnsRateLimited()
        {
            var sut = new HttpResponseMessage((HttpStatusCode)429) { ReasonPhrase = "Too Many Requests" };
            sut.Headers.RetryAfter = new RetryConditionHeaderValue(TimeSpan.FromSeconds(300));

            var response = await sut.ToCompaniesHouseResponseAsync<TestPayload>();

            var rateLimited = response.ShouldBeOfType<CompaniesHouseResponse<TestPayload>.RateLimited>();
            rateLimited.StatusCode.ShouldBe(429);
            rateLimited.RetryAfter.ShouldBe(TimeSpan.FromSeconds(300));
        }

        [Fact]
        public async Task GivenAnHttpResponse_WhenTheStatusCodeIs429WithNoRetryAfter_ThenReturnsRateLimitedWithNullRetryAfter()
        {
            var sut = new HttpResponseMessage((HttpStatusCode)429) { ReasonPhrase = "Too Many Requests" };

            var response = await sut.ToCompaniesHouseResponseAsync<TestPayload>();

            var rateLimited = response.ShouldBeOfType<CompaniesHouseResponse<TestPayload>.RateLimited>();
            rateLimited.RetryAfter.ShouldBeNull();
        }

        [Theory]
        [InlineData(401)]
        [InlineData(403)]
        public async Task GivenAnHttpResponse_WhenTheStatusCodeIs401Or403_ThenReturnsUnauthorized(int statusCode)
        {
            var sut = new HttpResponseMessage((HttpStatusCode)statusCode);

            var response = await sut.ToCompaniesHouseResponseAsync<TestPayload>();

            var unauthorized = response.ShouldBeOfType<CompaniesHouseResponse<TestPayload>.Unauthorized>();
            unauthorized.StatusCode.ShouldBe(statusCode);
        }

        [Theory]
        [InlineData(500)]
        [InlineData(503)]
        public async Task GivenAnHttpResponse_WhenTheStatusCodeIs5xx_ThenReturnsServerError(int statusCode)
        {
            var sut = new HttpResponseMessage((HttpStatusCode)statusCode) { ReasonPhrase = "Server Error" };

            var response = await sut.ToCompaniesHouseResponseAsync<TestPayload>();

            var serverError = response.ShouldBeOfType<CompaniesHouseResponse<TestPayload>.ServerError>();
            serverError.StatusCode.ShouldBe(statusCode);
            serverError.RetryAfter.ShouldBeNull();
        }

        [Fact]
        public async Task GivenAnHttpResponse_WhenThe5xxResponseHasRetryAfter_ThenServerErrorIncludesRetryAfter()
        {
            var sut = new HttpResponseMessage(HttpStatusCode.ServiceUnavailable);
            sut.Headers.RetryAfter = new RetryConditionHeaderValue(TimeSpan.FromSeconds(60));

            var response = await sut.ToCompaniesHouseResponseAsync<TestPayload>();

            var serverError = response.ShouldBeOfType<CompaniesHouseResponse<TestPayload>.ServerError>();
            serverError.RetryAfter.ShouldBe(TimeSpan.FromSeconds(60));
        }

        [Theory]
        [InlineData(400)]
        [InlineData(410)]
        [InlineData(422)]
        public async Task GivenAnHttpResponse_WhenTheStatusCodeIsOther4xx_ThenReturnsClientError(int statusCode)
        {
            var sut = new HttpResponseMessage((HttpStatusCode)statusCode);

            var response = await sut.ToCompaniesHouseResponseAsync<TestPayload>();

            var clientError = response.ShouldBeOfType<CompaniesHouseResponse<TestPayload>.ClientError>();
            clientError.StatusCode.ShouldBe(statusCode);
        }

        [Fact]
        public async Task GivenANonSuccessResponse_WhenAccessingData_ThenThrowsInvalidOperationException()
        {
            var sut = new HttpResponseMessage(HttpStatusCode.NotFound) { ReasonPhrase = "Not Found" };

            var response = await sut.ToCompaniesHouseResponseAsync<TestPayload>();

            Should.Throw<InvalidOperationException>(() => _ = response.Data);
        }

        private sealed class TestPayload
        {
            public string? Value { get; set; }
        }
    }
}

