
using System;
using CompaniesHouse;
using CompaniesHouse.DelegatingHandlers;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Extensions to adding companies house client to the service collection
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Registers the companies house client
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="baseUri">The Base Uri of the API</param>        
        /// <param name="apiKey">The Api Key</param>        
        /// <returns>Service collection</returns>
        public static IServiceCollection AddCompaniesHouseClient(this IServiceCollection services, Uri baseUri, string apiKey)
        {
            services.TryAddTransient(provider => new CompaniesHouseAuthorizationHandler(apiKey));

            services.AddHttpClient<ICompaniesHouseClient, CompaniesHouseClient>(cfg => cfg.BaseAddress = baseUri)
                .AddHttpMessageHandler<CompaniesHouseAuthorizationHandler>();

            services.TryAddTransient<ICompaniesHouseSearchCompanyClient>(provider => provider.GetService<ICompaniesHouseClient>());
            services.TryAddTransient<ICompaniesHouseSearchOfficerClient>(provider => provider.GetService<ICompaniesHouseClient>());
            services.TryAddTransient<ICompaniesHouseSearchDisqualifiedOfficerClient>(provider => provider.GetService<ICompaniesHouseClient>());
            services.TryAddTransient<ICompaniesHouseSearchAllClient>(provider => provider.GetService<ICompaniesHouseClient>());
            services.TryAddTransient<ICompaniesHouseCompanyProfileClient>(provider => provider.GetService<ICompaniesHouseClient>());
            services.TryAddTransient<ICompaniesHouseCompanyFilingHistoryClient>(provider => provider.GetService<ICompaniesHouseClient>());
            services.TryAddTransient<ICompaniesHouseOfficersClient>(provider => provider.GetService<ICompaniesHouseClient>());
            services.TryAddTransient<ICompaniesHouseCompanyInsolvencyInformationClient>(provider => provider.GetService<ICompaniesHouseClient>());
            services.TryAddTransient<ICompaniesHouseAppointmentsClient>(provider => provider.GetService<ICompaniesHouseClient>());
            services.TryAddTransient<ICompaniesHousePersonsWithSignificantControlClient>(provider => provider.GetService<ICompaniesHouseClient>());
            services.TryAddTransient<ICompaniesHouseChargesClient>(provider => provider.GetService<ICompaniesHouseClient>());
            
            return services;
        }
        
        /// <summary>
        /// Registers the companies house client
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="apiKey">The Api Key</param>        
        /// <returns>Service collection</returns>
        public static IServiceCollection AddCompaniesHouseClient(this IServiceCollection services, string apiKey)
        {
            return services.AddCompaniesHouseClient(CompaniesHouseUris.Default, apiKey);
        }

        /// <summary>
        /// Registers the companies house document client
        /// </summary>
        /// <param name="services"></param>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        public static IServiceCollection AddCompaniesHouseDocumentClient(this IServiceCollection services, string apiKey)
        {
            return services.AddCompaniesHouseDocumentClient(CompaniesHouseUris.DocumentApi, apiKey);
        }

        /// <summary>
        /// Registers the companies house document client to the service collection
        /// </summary>
        /// <param name="services"></param>
        /// <param name="baseUri"></param>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        public static IServiceCollection AddCompaniesHouseDocumentClient(this IServiceCollection services, Uri baseUri, string apiKey)
        {
            services.TryAddTransient(provider => new CompaniesHouseAuthorizationHandler(apiKey));
            
            services.AddHttpClient<ICompaniesHouseDocumentClient, CompaniesHouseDocumentClient>(cfg => cfg.BaseAddress = baseUri)
                .AddHttpMessageHandler<CompaniesHouseAuthorizationHandler>();
            
            services.TryAddTransient<ICompaniesHouseDocumentMetadataClient>(provider => provider.GetService<ICompaniesHouseDocumentClient>());
            services.TryAddTransient<ICompaniesHouseDocumentDownloadClient>(provider => provider.GetService<ICompaniesHouseDocumentClient>());

            return services;
        }

    }
}