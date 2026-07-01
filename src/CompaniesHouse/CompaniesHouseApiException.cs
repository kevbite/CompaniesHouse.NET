using System;

namespace CompaniesHouse
{
    /// <summary>
    /// Thrown for genuine transport/server failures (5xx) so callers can rely on a
    /// <see cref="CompaniesHouseClientResponse{T}"/> being returned for every other outcome
    /// (including expected 4xx responses such as 404).
    /// </summary>
    public sealed class CompaniesHouseApiException : Exception
    {
        public CompaniesHouseApiException(int statusCode, string? reasonPhrase, TimeSpan? retryAfter)
            : base($"Companies House API request failed with status code {statusCode} ({reasonPhrase}).")
        {
            StatusCode = statusCode;
            ReasonPhrase = reasonPhrase;
            RetryAfter = retryAfter;
        }

        /// <summary>The HTTP status code returned by the API.</summary>
        public int StatusCode { get; }

        /// <summary>The HTTP reason phrase returned by the API, if any.</summary>
        public string? ReasonPhrase { get; }

        /// <summary>The value of the <c>Retry-After</c> header, if present.</summary>
        public TimeSpan? RetryAfter { get; }
    }
}
