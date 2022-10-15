using System;
using CompaniesHouse;
using CompaniesHouse.DelegatingHandlers;
using CompaniesHouse.Extensions.Microsoft.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Extensions to adding companies house document client to the service collection
    /// </summary>
    public static class CompaniesHouseDocumentClientServiceCollectionExtensions
    {
        /// <summary>
        /// Registers the companies house document client
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="apiKey">The Api Key</param>        
        /// <returns>Service collection</returns>
        public static IServiceCollection AddCompaniesHouseDocumentClient(this IServiceCollection services, string apiKey)
        {
            return services.AddCompaniesHouseDocumentClient(opt =>
            {
                opt.ApiKey = apiKey;
            });
        }
        
        /// <summary>
        /// Registers the companies house document client
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="baseUri">The Base Uri of the API</param>        
        /// <param name="apiKey">The Api Key</param>        
        /// <returns>Service collection</returns>
        public static IServiceCollection AddCompaniesHouseDocumentClient(this IServiceCollection services, Uri baseUri,
            string apiKey)
        {
            return services.AddCompaniesHouseDocumentClient(opt =>
            {
                opt.BaseUri = baseUri;
                opt.ApiKey = apiKey;
            });
        }

        /// <summary>
        /// Registers the companies house document client
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="configure">Companies house client options configuration</param>
        /// <returns>Service collection</returns>
        private static IServiceCollection AddCompaniesHouseDocumentClient(this IServiceCollection services,
            Action<CompaniesHouseClientDocumentOptions> configure)
        {
            return services.AddCompaniesHouseDocumentClient((provider, options) => configure(options));
        }

        /// <summary>
        /// Registers the companies house document client
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="configure">Companies house client options configuration</param>
        /// <returns>Service collection</returns>
        public static IServiceCollection AddCompaniesHouseDocumentClient(this IServiceCollection services,
            Action<IServiceProvider, CompaniesHouseClientDocumentOptions> configure)
        {
            services.TryAddSingleton<CompaniesHouseClientDocumentOptions>(provider =>
            {
                var options = new CompaniesHouseClientDocumentOptions();
                configure.Invoke(provider, options);
                return options;
            });
            
            services.TryAddTransient<IApiKeyProvider>(provider =>
            {
                var options = provider.GetRequiredService<CompaniesHouseClientDocumentOptions>();

                return new StaticApiKeyProvider(options.ApiKey);
            });
            
            services.TryAddTransient<CompaniesHouseAuthorizationHandler>();

            services.AddHttpClient<ICompaniesHouseDocumentClient, CompaniesHouseDocumentClient>((provider, client) =>
                {
                    var options = provider.GetRequiredService<CompaniesHouseClientDocumentOptions>();

                    client.BaseAddress = options.BaseUri;
                })
                .AddHttpMessageHandler<CompaniesHouseAuthorizationHandler>();

            services.TryAddTransient<ICompaniesHouseDocumentMetadataClient>(provider =>
                provider.GetService<ICompaniesHouseDocumentClient>());
            services.TryAddTransient<ICompaniesHouseDocumentDownloadClient>(provider =>
                provider.GetService<ICompaniesHouseDocumentClient>());

            return services;
        }
    }
}