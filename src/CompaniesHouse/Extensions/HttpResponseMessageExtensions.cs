namespace CompaniesHouse.Extensions;

using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// The shared send/deserialize pipeline used by every sub-client: all HTTP responses
/// are returned as a <see cref="CompaniesHouseResponse{T}"/> subtype.
/// Transport failures (network errors, DNS, timeout) propagate as <see cref="System.Net.Http.HttpRequestException"/>.
/// </summary>
public static class HttpResponseMessageExtensions
{
    /// <summary>
    /// Classifies the <see cref="HttpResponseMessage"/> and returns the appropriate
    /// <see cref="CompaniesHouseResponse{T}"/> subtype.
    /// </summary>
    public static async Task<CompaniesHouseResponse<T>> ToCompaniesHouseResponseAsync<T>(
        this HttpResponseMessage response, CancellationToken cancellationToken = default)
    {
        var statusCode = (int)response.StatusCode;
        var reasonPhrase = response.ReasonPhrase;

        return statusCode switch
        {
            >= 200 and < 300 => new CompaniesHouseResponse<T>.Success(
                await response.Content.ReadFromJsonAsync<T>(CompaniesHouseJsonSerializerOptions.Default, cancellationToken).ConfigureAwait(false),
                statusCode,
                reasonPhrase,
                response.Headers),

            404 => new CompaniesHouseResponse<T>.NotFound(statusCode, reasonPhrase),

            429 => new CompaniesHouseResponse<T>.RateLimited(
                response.Headers.RetryAfter?.Delta,
                statusCode,
                reasonPhrase),

            401 or 403 => new CompaniesHouseResponse<T>.Unauthorized(statusCode, reasonPhrase),

            >= 500 => new CompaniesHouseResponse<T>.ServerError(
                response.Headers.RetryAfter?.Delta,
                statusCode,
                reasonPhrase),

            _ => new CompaniesHouseResponse<T>.ClientError(statusCode, reasonPhrase),
        };
    }
}

