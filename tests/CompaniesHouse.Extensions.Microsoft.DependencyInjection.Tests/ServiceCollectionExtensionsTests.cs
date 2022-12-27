using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace CompaniesHouse.Extensions.Microsoft.DependencyInjection.Tests
{
    public class ServiceCollectionExtensionsTests
    {
        [Test]
        public void CanResolveCompaniesHouseClients()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddCompaniesHouseClient("ApiKey");
            
            var serviceProvider = serviceCollection.BuildServiceProvider();
            using var scope = serviceProvider.CreateScope();

            Assert.NotNull(scope.ServiceProvider.GetService<ICompaniesHouseClient>());
            Assert.NotNull(scope.ServiceProvider.GetService<ICompaniesHouseSearchCompanyClient>());
            Assert.NotNull(scope.ServiceProvider.GetService<ICompaniesHouseSearchOfficerClient>());
            Assert.NotNull(scope.ServiceProvider.GetService<ICompaniesHouseSearchDisqualifiedOfficerClient>());
            Assert.NotNull(scope.ServiceProvider.GetService<ICompaniesHouseSearchAllClient>());
            Assert.NotNull(scope.ServiceProvider.GetService<ICompaniesHouseCompanyProfileClient>());
            Assert.NotNull(scope.ServiceProvider.GetService<ICompaniesHouseCompanyFilingHistoryClient>());
            Assert.NotNull(scope.ServiceProvider.GetService<ICompaniesHouseOfficersClient>());
            Assert.NotNull(scope.ServiceProvider.GetService<ICompaniesHouseCompanyInsolvencyInformationClient>());
            Assert.NotNull(scope.ServiceProvider.GetService<ICompaniesHouseCompanyInsolvencyInformationClient>());
            Assert.NotNull(scope.ServiceProvider.GetService<ICompaniesHouseAppointmentsClient>());
            Assert.NotNull(scope.ServiceProvider.GetService<ICompaniesHousePersonsWithSignificantControlClient>());
        }

        [Test]
        public void CanResolveCompaniesHouseDocumentClients()
        {
            
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddCompaniesHouseDocumentClient("ApiKey");
            
            var serviceProvider = serviceCollection.BuildServiceProvider();
            using var scope = serviceProvider.CreateScope();

            Assert.NotNull(scope.ServiceProvider.GetService<ICompaniesHouseDocumentClient>());
            Assert.NotNull(scope.ServiceProvider.GetService<ICompaniesHouseDocumentDownloadClient>());
            Assert.NotNull(scope.ServiceProvider.GetService<ICompaniesHouseDocumentMetadataClient>());
        }
    }
}