using System;
using CompaniesHouse;
using CompaniesHouse.DelegatingHandlers;
using CompaniesHouse.Extensions.Microsoft.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Extensions to adding companies house client to the service collection
    /// </summary>
    public static class CompaniesHouseClientServiceCollectionExtensions
    {
        /// <summary>
        /// Registers the companies house client
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="apiKey">The Api Key</param>        
        /// <returns>Service collection</returns>
        public static IServiceCollection AddCompaniesHouseClient(this IServiceCollection services, string apiKey)
        {
            return services.AddCompaniesHouseClient(opt =>
            {
                opt.ApiKey = apiKey;
            });
        }
        
        /// <summary>
        /// Registers the companies house client
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="baseUri">The Base Uri of the API</param>        
        /// <param name="apiKey">The Api Key</param>        
        /// <returns>Service collection</returns>
        public static IServiceCollection AddCompaniesHouseClient(this IServiceCollection services, Uri baseUri,
            string apiKey)
        {
            return services.AddCompaniesHouseClient(opt =>
            {
                opt.BaseUri = baseUri;
                opt.ApiKey = apiKey;
            });
        }

        /// <summary>
        /// Registers the companies house client
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="configure">Companies house client options configuration</param>
        /// <returns>Service collection</returns>
        private static IServiceCollection AddCompaniesHouseClient(this IServiceCollection services,
            Action<CompaniesHouseClientOptions> configure)
        {
            return services.AddCompaniesHouseClient((provider, options) => configure(options));
        }

        /// <summary>
        /// Registers the companies house client
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="configure">Companies house client options configuration</param>
        /// <returns>Service collection</returns>
        public static IServiceCollection AddCompaniesHouseClient(this IServiceCollection services,
            Action<IServiceProvider, CompaniesHouseClientOptions> configure)
        {
            services.TryAddSingleton<CompaniesHouseClientOptions>(provider =>
            {
                var options = new CompaniesHouseClientOptions();
                configure.Invoke(provider, options);
                return options;
            });
            
            services.TryAddTransient<IApiKeyProvider>(provider =>
            {
                var options = provider.GetRequiredService<CompaniesHouseClientOptions>();

                return new StaticApiKeyProvider(options.ApiKey);
            });

            services.TryAddTransient<CompaniesHouseAuthorizationHandler>();

            services.AddHttpClient<ICompaniesHouseClient, CompaniesHouseClient>((provider, client) =>
                {
                    var options = provider.GetRequiredService<CompaniesHouseClientOptions>();

                    client.BaseAddress = options.BaseUri;
                })
                .AddHttpMessageHandler<CompaniesHouseAuthorizationHandler>();

            services.TryAddTransient<ICompaniesHouseSearchCompanyClient>(provider =>
                provider.GetService<ICompaniesHouseClient>());
            services.TryAddTransient<ICompaniesHouseSearchOfficerClient>(provider =>
                provider.GetService<ICompaniesHouseClient>());
            services.TryAddTransient<ICompaniesHouseSearchDisqualifiedOfficerClient>(provider =>
                provider.GetService<ICompaniesHouseClient>());
            services.TryAddTransient<ICompaniesHouseSearchAllClient>(provider =>
                provider.GetService<ICompaniesHouseClient>());
            services.TryAddTransient<ICompaniesHouseCompanyProfileClient>(provider =>
                provider.GetService<ICompaniesHouseClient>());
            services.TryAddTransient<ICompaniesHouseCompanyFilingHistoryClient>(provider =>
                provider.GetService<ICompaniesHouseClient>());
            services.TryAddTransient<ICompaniesHouseOfficersClient>(provider =>
                provider.GetService<ICompaniesHouseClient>());
            services.TryAddTransient<ICompaniesHouseCompanyInsolvencyInformationClient>(provider =>
                provider.GetService<ICompaniesHouseClient>());
            services.TryAddTransient<ICompaniesHouseAppointmentsClient>(
                provider => provider.GetService<ICompaniesHouseClient>());
            services.TryAddTransient<ICompaniesHousePersonsWithSignificantControlClient>(provider =>
                provider.GetService<ICompaniesHouseClient>());
            services.TryAddTransient<ICompaniesHouseChargesClient>(provider =>
                provider.GetService<ICompaniesHouseClient>());

            return services;
        }
    }
}