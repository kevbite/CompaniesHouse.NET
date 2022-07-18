namespace CompaniesHouse.Extensions;

using System.Net.Http;

public static class HttpResponseMessageExtensions
{
    public static HttpResponseMessage EnsureSuccessStatusCode2(this HttpResponseMessage responseMessage)
    {
        try
        {
            responseMessage.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException e)
        {
            e.Data["StatusCode"] = (int)responseMessage.StatusCode;
            e.Data["ReasonPhrase"] = responseMessage.ReasonPhrase;
            e.Data["RetryAfter"] = responseMessage.Headers?.RetryAfter?.ToString();
            throw;
        }

        return responseMessage;
    }
}
