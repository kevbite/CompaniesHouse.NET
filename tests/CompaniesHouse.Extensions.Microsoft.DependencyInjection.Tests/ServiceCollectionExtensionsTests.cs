using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Xunit;

namespace CompaniesHouse.Extensions.Microsoft.DependencyInjection.Tests
{
    public class ServiceCollectionExtensionsTests
    {
        [Fact]
        public void CanResolveCompaniesHouseClients()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddCompaniesHouseClient("ApiKey");
            
            var serviceProvider = serviceCollection.BuildServiceProvider();
            using var scope = serviceProvider.CreateScope();

            scope.ServiceProvider.GetService<ICompaniesHouseClient>().ShouldNotBeNull();
            scope.ServiceProvider.GetService<ICompaniesHouseSearchCompanyClient>().ShouldNotBeNull();
            scope.ServiceProvider.GetService<ICompaniesHouseSearchOfficerClient>().ShouldNotBeNull();
            scope.ServiceProvider.GetService<ICompaniesHouseSearchDisqualifiedOfficerClient>().ShouldNotBeNull();
            scope.ServiceProvider.GetService<ICompaniesHouseSearchAllClient>().ShouldNotBeNull();
            scope.ServiceProvider.GetService<ICompaniesHouseCompanyProfileClient>().ShouldNotBeNull();
            scope.ServiceProvider.GetService<ICompaniesHouseCompanyFilingHistoryClient>().ShouldNotBeNull();
            scope.ServiceProvider.GetService<ICompaniesHouseOfficersClient>().ShouldNotBeNull();
            scope.ServiceProvider.GetService<ICompaniesHouseCompanyInsolvencyInformationClient>().ShouldNotBeNull();
            scope.ServiceProvider.GetService<ICompaniesHouseCompanyInsolvencyInformationClient>().ShouldNotBeNull();
            scope.ServiceProvider.GetService<ICompaniesHouseAppointmentsClient>().ShouldNotBeNull();
            scope.ServiceProvider.GetService<ICompaniesHousePersonsWithSignificantControlClient>().ShouldNotBeNull();
        }

        [Fact]
        public void CanResolveCompaniesHouseDocumentClients()
        {
            
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddCompaniesHouseDocumentClient("ApiKey");
            
            var serviceProvider = serviceCollection.BuildServiceProvider();
            using var scope = serviceProvider.CreateScope();

            scope.ServiceProvider.GetService<ICompaniesHouseDocumentClient>().ShouldNotBeNull();
            scope.ServiceProvider.GetService<ICompaniesHouseDocumentDownloadClient>().ShouldNotBeNull();
            scope.ServiceProvider.GetService<ICompaniesHouseDocumentMetadataClient>().ShouldNotBeNull();
        }
    }
}