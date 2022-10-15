using System.Threading.Tasks;

namespace CompaniesHouse;

public interface IApiKeyProvider
{
    public Task<string> GetApiKey();
}