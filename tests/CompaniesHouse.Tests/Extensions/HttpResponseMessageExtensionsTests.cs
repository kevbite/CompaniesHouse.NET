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
        [Fact]
        public async Task GivenAnHttpResponse_WhenTheStatusCodeIsSuccess_ThenToCompaniesHouseClientResponseAsyncReturnsTheWrappedResponse()
        {
            for (var statusCode = 200; statusCode < 299; statusCode++)
            {
                var sut = new HttpResponseMessage((HttpStatusCode)statusCode)
                {
                    Content = JsonContent.Create(new TestPayload { Value = "ok" })
                };

                var response = await sut.ToCompaniesHouseClientResponseAsync<TestPayload>();

                response.Data.ShouldNotBeNull();
                response.Data.Value.ShouldBe("ok");
                response.StatusCode.ShouldBe(statusCode);
                response.IsSuccess.ShouldBeTrue();
                response.Headers.ShouldBe(sut.Headers);
            }
        }

        [Theory]
        [InlineData(410, "Gone", 0, null)]
        [InlineData(429, "Too Many Requests", 300, null)]
        public async Task GivenAnHttpResponse_WhenTheStatusCodeIsNotServerError_ThenToCompaniesHouseClientResponseAsyncReturnsMetadataWithoutData(
            int statusCode,
            string reasonPhrase,
            int retryAfterSeconds,
            string? retryAfterDate)
        {
            var sut = new HttpResponseMessage((HttpStatusCode)statusCode) { ReasonPhrase = reasonPhrase };
            var retryAfterDateTimeOffset = DateTimeOffset.MinValue;
            if (!string.IsNullOrWhiteSpace(retryAfterDate))
            {
                retryAfterDateTimeOffset = DateTimeOffset.Parse(retryAfterDate);
            }

            if (retryAfterSeconds >= 0 || !string.IsNullOrWhiteSpace(retryAfterDate))
            {
                sut.Headers.RetryAfter = string.IsNullOrWhiteSpace(retryAfterDate)
                ? new RetryConditionHeaderValue(TimeSpan.FromSeconds(retryAfterSeconds))
                : new RetryConditionHeaderValue(retryAfterDateTimeOffset);
            }

            var response = await sut.ToCompaniesHouseClientResponseAsync<TestPayload>();

            response.Data.ShouldBeNull();
            response.StatusCode.ShouldBe(statusCode);
            response.ReasonPhrase.ShouldBe(reasonPhrase);
            response.IsSuccess.ShouldBeFalse();
            response.RetryAfter.ShouldBe(
                string.IsNullOrWhiteSpace(retryAfterDate)
                    ? TimeSpan.FromSeconds(retryAfterSeconds)
                    : null);
        }

        [Theory]
        [InlineData(503, "Service Unavailable", 0, null)]
        [InlineData(503, "Service Unavailable", -1, "2015-10-08T12:34:56.000+1")]
        [InlineData(503, "Service Unavailable", -1, null)]
        public void GivenAnHttpResponse_WhenTheStatusCodeIsServerError_ThenEnsureNotServerErrorAsyncThrowsCompaniesHouseApiException(
            int statusCode,
            string reasonPhrase,
            int retryAfterSeconds,
            string? retryAfterDate)
        {
            var sut = new HttpResponseMessage((HttpStatusCode)statusCode) { ReasonPhrase = reasonPhrase };
            var retryAfterDateTimeOffset = DateTimeOffset.MinValue;
            if (!string.IsNullOrWhiteSpace(retryAfterDate))
            {
                retryAfterDateTimeOffset = DateTimeOffset.Parse(retryAfterDate);
            }

            if (retryAfterSeconds >= 0 || !string.IsNullOrWhiteSpace(retryAfterDate))
            {
                sut.Headers.RetryAfter = string.IsNullOrWhiteSpace(retryAfterDate)
                    ? new RetryConditionHeaderValue(TimeSpan.FromSeconds(retryAfterSeconds))
                    : new RetryConditionHeaderValue(retryAfterDateTimeOffset);
            }

            var exception = Should.Throw<CompaniesHouseApiException>(() => sut.EnsureNotServerErrorAsync().GetAwaiter().GetResult());
            exception.StatusCode.ShouldBe(statusCode);
            exception.ReasonPhrase.ShouldBe(reasonPhrase);
            exception.RetryAfter.ShouldBe(
                string.IsNullOrWhiteSpace(retryAfterDate)
                    ? retryAfterSeconds >= 0 ? TimeSpan.FromSeconds(retryAfterSeconds) : null
                    : null);
        }

        private sealed class TestPayload
        {
            public string? Value { get; set; }
        }
    }
}
