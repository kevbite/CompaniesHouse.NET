using System.Threading.Tasks;
using CompaniesHouse.Request;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Xunit;

namespace CompaniesHouse.ScenarioTests
{
    public class SearchingCompaniesUsingMicrosoftServiceContainerTests
    {
        [Fact]
        public async Task CanResolveCompaniesHouseClients()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddCompaniesHouseClient(Keys.ApiKey);
            
            var serviceProvider = serviceCollection.BuildServiceProvider();
            using var scope = serviceProvider.CreateScope();

            var client = scope.ServiceProvider.GetRequiredService<ICompaniesHouseClient>();

            var response = await client.SearchCompanyAsync(new SearchCompanyRequest {Query = "Boon & Moil"});
            
            response.Data.Companies.ShouldNotBeEmpty();
        }
    }
}