namespace CompaniesHouse.Tests.Extensions
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using CompaniesHouse.Extensions;
    using NUnit.Framework;

    [TestFixture]
    public class HttpResponseMessageExtensionsTests
    {
        [Test]
        public void GivenAnHttpResponse_WhenTheStatusCodeIsSuccess_ThenEnsureSuccessStatusCode2ReturnsTheHttpResponse()
        {
            for (var statusCode = 200; statusCode < 299; statusCode++)
            {
                var sut = new HttpResponseMessage((HttpStatusCode)200);
                var responseMessage = sut.EnsureSuccessStatusCode2();
                Assert.AreEqual(responseMessage, sut);
            }
        }

        [TestCase(410, "Gone", 0, null)]
        [TestCase(429, "Too Many Requests", 300, null)]
        [TestCase(503, "Service Unavailable", 0, "2015-10-08T12:34:56.000+1")]
        [TestCase(503, "Service Unavailable", -1, null)]
        public void GivenAnHttpResponse_WhenTheStatusCodeIsNotSuccess_ThenEnsureSuccessStatusCode2ThrowsHttpRequestExceptionWithData(
            int statusCode,
            string reasonPhrase,
            int retryAfterSeconds,
            string retryAfterDate)
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

            var exception = Assert.Throws<HttpRequestException>(() => sut.EnsureSuccessStatusCode2());
            Assert.AreEqual(statusCode, exception.Data["StatusCode"]);
            Assert.AreEqual(reasonPhrase, exception.Data["ReasonPhrase"]);

            if (retryAfterSeconds >= 0 || !string.IsNullOrWhiteSpace(retryAfterDate))
            {
                Assert.AreEqual(string.IsNullOrWhiteSpace(retryAfterDate)
                        ? retryAfterSeconds.ToString()
                        : retryAfterDateTimeOffset.ToString("R"),
                    exception.Data["RetryAfter"]);
            }
            else
            {
                Assert.AreEqual(null, exception.Data["RetryAfter"]);
            }
        }
    }
}
