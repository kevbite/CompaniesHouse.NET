using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
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
            scope.ServiceProvider.GetService<ICompaniesHouseSearchCompaniesAlphabeticallyClient>().ShouldNotBeNull();
            scope.ServiceProvider.GetService<ICompaniesHouseSearchDissolvedCompaniesClient>().ShouldNotBeNull();
            scope.ServiceProvider.GetService<ICompaniesHouseAdvancedCompanySearchClient>().ShouldNotBeNull();
            scope.ServiceProvider.GetService<ICompaniesHouseCompanyProfileClient>().ShouldNotBeNull();
            scope.ServiceProvider.GetService<ICompaniesHouseCompanyFilingHistoryClient>().ShouldNotBeNull();
            scope.ServiceProvider.GetService<ICompaniesHouseOfficersClient>().ShouldNotBeNull();
            scope.ServiceProvider.GetService<ICompaniesHouseCompanyInsolvencyInformationClient>().ShouldNotBeNull();
            scope.ServiceProvider.GetService<ICompaniesHouseCompanyInsolvencyInformationClient>().ShouldNotBeNull();
            scope.ServiceProvider.GetService<ICompaniesHouseAppointmentsClient>().ShouldNotBeNull();
            scope.ServiceProvider.GetService<ICompaniesHousePersonsWithSignificantControlClient>().ShouldNotBeNull();
            scope.ServiceProvider.GetService<ICompaniesHouseChargesClient>().ShouldNotBeNull();
            scope.ServiceProvider.GetService<ICompaniesHouseRegisteredOfficeAddressClient>().ShouldNotBeNull();
        }

        [Fact]
        public void AddCompaniesHouseClient_FromConfiguration_BindsOptions()
        {
            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string?>
                {
                    ["CompaniesHouse:ApiKey"] = "ConfiguredApiKey",
                    ["CompaniesHouse:BaseUri"] = "https://example.test/",
                })
                .Build();

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddCompaniesHouseClient(configuration);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var options = serviceProvider.GetRequiredService<IOptions<CompaniesHouseClientOptions>>().Value;

            options.ApiKey.ShouldBe("ConfiguredApiKey");
            options.BaseUri.ShouldBe(new Uri("https://example.test/"));
        }

        [Fact]
        public void AddCompaniesHouseClient_MissingApiKey_FailsValidationOnStart()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddCompaniesHouseClient(options => options.ApiKey = string.Empty);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            Should.Throw<OptionsValidationException>(() =>
                serviceProvider.GetRequiredService<IOptions<CompaniesHouseClientOptions>>().Value);
        }

        [Fact]
        public void AddCompaniesHouseClient_Named_ResolvesKeyedServices()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddCompaniesHouseClient("first", "FirstApiKey");
            serviceCollection.AddCompaniesHouseClient("second", "SecondApiKey");

            var serviceProvider = serviceCollection.BuildServiceProvider();
            using var scope = serviceProvider.CreateScope();

            var first = scope.ServiceProvider.GetRequiredKeyedService<ICompaniesHouseClient>("first");
            var second = scope.ServiceProvider.GetRequiredKeyedService<ICompaniesHouseClient>("second");

            first.ShouldNotBeNull();
            second.ShouldNotBeNull();
            first.ShouldNotBeSameAs(second);

            scope.ServiceProvider.GetRequiredKeyedService<ICompaniesHouseSearchCompanyClient>("first").ShouldNotBeNull();
            scope.ServiceProvider.GetRequiredKeyedService<ICompaniesHouseSearchCompaniesAlphabeticallyClient>("first").ShouldNotBeNull();
            scope.ServiceProvider.GetRequiredKeyedService<ICompaniesHouseAdvancedCompanySearchClient>("second").ShouldNotBeNull();
            scope.ServiceProvider.GetRequiredKeyedService<ICompaniesHouseChargesClient>("second").ShouldNotBeNull();
            scope.ServiceProvider.GetRequiredKeyedService<ICompaniesHouseRegisteredOfficeAddressClient>("second").ShouldNotBeNull();
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

        [Fact]
        public void AddCompaniesHouseDocumentClient_Named_ResolvesKeyedServices()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddCompaniesHouseDocumentClient("first", "FirstApiKey");
            serviceCollection.AddCompaniesHouseDocumentClient("second", "SecondApiKey");

            var serviceProvider = serviceCollection.BuildServiceProvider();
            using var scope = serviceProvider.CreateScope();

            var first = scope.ServiceProvider.GetRequiredKeyedService<ICompaniesHouseDocumentClient>("first");
            var second = scope.ServiceProvider.GetRequiredKeyedService<ICompaniesHouseDocumentClient>("second");

            first.ShouldNotBeNull();
            second.ShouldNotBeNull();
            first.ShouldNotBeSameAs(second);

            scope.ServiceProvider.GetRequiredKeyedService<ICompaniesHouseDocumentMetadataClient>("first").ShouldNotBeNull();
            scope.ServiceProvider.GetRequiredKeyedService<ICompaniesHouseDocumentDownloadClient>("second").ShouldNotBeNull();
        }
    }
}