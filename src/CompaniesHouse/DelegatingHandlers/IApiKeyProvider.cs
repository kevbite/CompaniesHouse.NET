using System.Threading.Tasks;

namespace CompaniesHouse.DelegatingHandlers;

public interface IApiKeyProvider
{
    public Task<string> GetApiKey();
}