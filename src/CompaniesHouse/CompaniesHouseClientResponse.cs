using System.Net.Http.Headers;

namespace CompaniesHouse
{
    /// <summary>
    /// Wraps the result of a Companies House API call, exposing transport metadata (status
    /// code, reason phrase, retry-after, headers) alongside the deserialized <see cref="Data"/>.
    /// </summary>
    public class CompaniesHouseClientResponse<T>
    {
        public CompaniesHouseClientResponse(T? data, int statusCode, string? reasonPhrase, System.TimeSpan? retryAfter, HttpResponseHeaders? headers)
        {
            Data = data;
            StatusCode = statusCode;
            ReasonPhrase = reasonPhrase;
            RetryAfter = retryAfter;
            Headers = headers;
        }

        /// <summary>The deserialized response body, or <c>default</c> for non-success responses.</summary>
        public T? Data { get; }

        /// <summary>The HTTP status code of the response.</summary>
        public int StatusCode { get; }

        /// <summary>The HTTP reason phrase of the response, if any.</summary>
        public string? ReasonPhrase { get; }

        /// <summary>The value of the <c>Retry-After</c> header, if present (see #181/#182).</summary>
        public System.TimeSpan? RetryAfter { get; }

        /// <summary>Whether the response status code was in the 2xx range.</summary>
        public bool IsSuccess => StatusCode is >= 200 and < 300;

        /// <summary>The response headers, exposed read-only.</summary>
        public HttpResponseHeaders? Headers { get; }
    }
}
