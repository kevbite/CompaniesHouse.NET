using System;
using System.Net.Http.Headers;

namespace CompaniesHouse
{
    /// <summary>
    /// Discriminated union representing every HTTP outcome of a Companies House API
    /// call. Transport failures (network errors, DNS, timeout) surface as
    /// <see cref="System.Net.Http.HttpRequestException"/> from the underlying HttpClient.
    /// </summary>
    public abstract class CompaniesHouseResponse<T>
    {
        private CompaniesHouseResponse(int statusCode, string? reasonPhrase)
        {
            StatusCode = statusCode;
            ReasonPhrase = reasonPhrase;
        }

        /// <summary>The HTTP status code of the response.</summary>
        public int StatusCode { get; }

        /// <summary>The HTTP reason phrase, if any.</summary>
        public string? ReasonPhrase { get; }

        /// <summary>
        /// Returns the deserialized response body when this is a <see cref="Success"/>
        /// response. Throws <see cref="InvalidOperationException"/> for any other subtype,
        /// making the error explicit rather than silently returning null.
        /// Use pattern matching when you need to handle non-success outcomes.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the response is not <see cref="Success"/>.
        /// </exception>
        public T Data => this is Success s
            ? s.Data
            : throw new InvalidOperationException(
                $"Cannot access Data on a {GetType().Name} response (HTTP {StatusCode}).");

        /// <summary>A 2xx response whose body deserialized successfully.</summary>
        public sealed class Success : CompaniesHouseResponse<T>
        {
            public Success(T data, int statusCode, string? reasonPhrase, HttpResponseHeaders headers)
                : base(statusCode, reasonPhrase)
            {
                Data = data;
                Headers = headers;
            }

            /// <summary>The deserialized response body. Never null on this subtype.</summary>
            public new T Data { get; }

            /// <summary>The full set of response headers.</summary>
            public HttpResponseHeaders Headers { get; }
        }

        /// <summary>
        /// A 404 response — the requested resource does not exist or is not
        /// accessible with the provided credentials.
        /// </summary>
        public sealed class NotFound : CompaniesHouseResponse<T>
        {
            public NotFound(int statusCode, string? reasonPhrase) : base(statusCode, reasonPhrase) { }
        }

        /// <summary>
        /// A 429 response — the client has been rate-limited. Check
        /// <see cref="RetryAfter"/> before retrying.
        /// </summary>
        public sealed class RateLimited : CompaniesHouseResponse<T>
        {
            public RateLimited(TimeSpan? retryAfter, int statusCode, string? reasonPhrase)
                : base(statusCode, reasonPhrase) => RetryAfter = retryAfter;

            /// <summary>How long to wait before retrying, if the server supplied the header.</summary>
            public TimeSpan? RetryAfter { get; }
        }

        /// <summary>
        /// A 401/403 response — the API key is missing, wrong, or lacks permission.
        /// </summary>
        public sealed class Unauthorized : CompaniesHouseResponse<T>
        {
            public Unauthorized(int statusCode, string? reasonPhrase) : base(statusCode, reasonPhrase) { }
        }

        /// <summary>
        /// Any other 4xx response not covered by the more specific subtypes.
        /// </summary>
        public sealed class ClientError : CompaniesHouseResponse<T>
        {
            public ClientError(int statusCode, string? reasonPhrase) : base(statusCode, reasonPhrase) { }
        }

        /// <summary>
        /// A 5xx response — the server encountered an error. May carry a
        /// <see cref="RetryAfter"/> hint (e.g. 503 with <c>Retry-After</c>).
        /// </summary>
        public sealed class ServerError : CompaniesHouseResponse<T>
        {
            public ServerError(TimeSpan? retryAfter, int statusCode, string? reasonPhrase)
                : base(statusCode, reasonPhrase) => RetryAfter = retryAfter;

            /// <summary>How long to wait before retrying, if the server supplied the header.</summary>
            public TimeSpan? RetryAfter { get; }
        }
    }
}
