namespace CompaniesHouse.Extensions;

using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// The shared send/deserialize pipeline used by every sub-client: non-5xx responses are always
/// returned as a <see cref="CompaniesHouseClientResponse{T}"/> (including 404s, with
/// <c>Data == default</c>); 5xx responses raise <see cref="CompaniesHouseApiException"/>.
/// </summary>
public static class HttpResponseMessageExtensions
{
    /// <summary>
    /// Deserializes the response body (for success status codes) and wraps it, along with
    /// transport metadata, in a <see cref="CompaniesHouseClientResponse{T}"/>.
    /// </summary>
    public static async Task<CompaniesHouseClientResponse<T>> ToCompaniesHouseClientResponseAsync<T>(
        this HttpResponseMessage response, CancellationToken cancellationToken = default)
    {
        await response.EnsureNotServerErrorAsync().ConfigureAwait(false);

        var data = response.IsSuccessStatusCode
            ? await response.Content.ReadFromJsonAsync<T>(CompaniesHouseJsonSerializerOptions.Default, cancellationToken).ConfigureAwait(false)
            : default;

        return new CompaniesHouseClientResponse<T>(
            data,
            (int)response.StatusCode,
            response.ReasonPhrase,
            response.Headers.RetryAfter?.Delta,
            response.Headers);
    }

    /// <summary>
    /// Throws <see cref="CompaniesHouseApiException"/> for genuine server errors (5xx); returns
    /// normally for everything else, including expected 4xx responses.
    /// </summary>
    public static Task EnsureNotServerErrorAsync(this HttpResponseMessage response)
    {
        if ((int)response.StatusCode >= 500)
        {
            throw new CompaniesHouseApiException(
                (int)response.StatusCode,
                response.ReasonPhrase,
                response.Headers.RetryAfter?.Delta);
        }

        return Task.CompletedTask;
    }
}

