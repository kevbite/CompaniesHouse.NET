using System.Threading.Tasks;

namespace CompaniesHouse;

public class StaticApiKeyProvider : IApiKeyProvider
{
    private readonly string _apiKey;
    public StaticApiKeyProvider(string apiKey)
        => _apiKey = apiKey;

    public Task<string> GetApiKey()
        => Task.FromResult(_apiKey);
}