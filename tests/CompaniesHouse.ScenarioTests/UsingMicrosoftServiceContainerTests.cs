using System.Threading.Tasks;
using CompaniesHouse.Request;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;

namespace CompaniesHouse.ScenarioTests
{
    public class SearchingCompaniesUsingMicrosoftServiceContainerTests
    {
        [Test]
        public async Task CanResolveCompaniesHouseClients()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddCompaniesHouseClient(Keys.ApiKey);
            
            var serviceProvider = serviceCollection.BuildServiceProvider();
            using var scope = serviceProvider.CreateScope();

            var client = scope.ServiceProvider.GetService<ICompaniesHouseClient>();

            var response = await client.SearchCompanyAsync(new SearchCompanyRequest {Query = "Boon & Moil"});
            
            Assert.IsNotEmpty(response.Data.Companies);
        }
    }
}