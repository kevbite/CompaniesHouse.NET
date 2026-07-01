namespace CompaniesHouse.Tests.Extensions
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using CompaniesHouse.Extensions;
    using Shouldly;
    using Xunit;

    public class HttpResponseMessageExtensionsTests
    {
        [Fact]
        public void GivenAnHttpResponse_WhenTheStatusCodeIsSuccess_ThenEnsureSuccessStatusCode2ReturnsTheHttpResponse()
        {
            for (var statusCode = 200; statusCode < 299; statusCode++)
            {
                var sut = new HttpResponseMessage((HttpStatusCode)200);
                var responseMessage = sut.EnsureSuccessStatusCode2();
                responseMessage.ShouldBe(sut);
            }
        }

        [Theory]
        [InlineData(410, "Gone", 0, null)]
        [InlineData(429, "Too Many Requests", 300, null)]
        [InlineData(503, "Service Unavailable", 0, "2015-10-08T12:34:56.000+1")]
        [InlineData(503, "Service Unavailable", -1, null)]
        public void GivenAnHttpResponse_WhenTheStatusCodeIsNotSuccess_ThenEnsureSuccessStatusCode2ThrowsHttpRequestExceptionWithData(
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

            var exception = Should.Throw<HttpRequestException>(() => sut.EnsureSuccessStatusCode2());
            exception.Data["StatusCode"].ShouldBe(statusCode);
            exception.Data["ReasonPhrase"].ShouldBe(reasonPhrase);

            if (retryAfterSeconds >= 0 || !string.IsNullOrWhiteSpace(retryAfterDate))
            {
                exception.Data["RetryAfter"].ShouldBe(
                    string.IsNullOrWhiteSpace(retryAfterDate)
                        ? retryAfterSeconds.ToString()
                        : retryAfterDateTimeOffset.ToString("R"));
            }
            else
            {
                exception.Data["RetryAfter"].ShouldBeNull();
            }
        }
    }
}
