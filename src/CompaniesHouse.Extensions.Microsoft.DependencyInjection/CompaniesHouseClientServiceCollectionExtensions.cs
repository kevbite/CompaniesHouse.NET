using System;
using CompaniesHouse;
using CompaniesHouse.DelegatingHandlers;
using CompaniesHouse.Extensions.Microsoft.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Extensions to adding companies house client to the service collection
    /// </summary>
    public static class CompaniesHouseClientServiceCollectionExtensions
    {
        /// <summary>
        /// The default configuration section name used when binding <see cref="CompaniesHouseClientOptions"/>
        /// from an <see cref="IConfiguration"/>.
        /// </summary>
        public const string DefaultSectionName = "CompaniesHouse";

        /// <summary>
        /// Registers the companies house client
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="apiKey">The Api Key</param>        
        /// <returns>Service collection</returns>
        public static IServiceCollection AddCompaniesHouseClient(this IServiceCollection services, string apiKey)
        {
            return services.AddCompaniesHouseClient(options => options.ApiKey = apiKey);
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
            return services.AddCompaniesHouseClient(options =>
            {
                options.BaseUri = baseUri;
                options.ApiKey = apiKey;
            });
        }

        /// <summary>
        /// Registers the companies house client
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="configure">Companies house client options configuration</param>
        /// <param name="configureHttpClientBuilder">Optional hook to customise the underlying <see cref="IHttpClientBuilder"/>, e.g. to add resilience handlers</param>
        /// <returns>Service collection</returns>
        public static IServiceCollection AddCompaniesHouseClient(this IServiceCollection services,
            Action<CompaniesHouseClientOptions> configure,
            Action<IHttpClientBuilder>? configureHttpClientBuilder = null)
        {
            services.AddOptions<CompaniesHouseClientOptions>()
                .Configure(configure)
                .ValidateDataAnnotations()
                .ValidateOnStart();

            return services.AddCompaniesHouseClientCore(configureHttpClientBuilder);
        }

        /// <summary>
        /// Registers the companies house client
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="configure">Companies house client options configuration</param>
        /// <param name="configureHttpClientBuilder">Optional hook to customise the underlying <see cref="IHttpClientBuilder"/>, e.g. to add resilience handlers</param>
        /// <returns>Service collection</returns>
        public static IServiceCollection AddCompaniesHouseClient(this IServiceCollection services,
            Action<IServiceProvider, CompaniesHouseClientOptions> configure,
            Action<IHttpClientBuilder>? configureHttpClientBuilder = null)
        {
            services.AddOptions<CompaniesHouseClientOptions>()
                .Configure<IServiceProvider>((options, provider) => configure(provider, options))
                .ValidateDataAnnotations()
                .ValidateOnStart();

            return services.AddCompaniesHouseClientCore(configureHttpClientBuilder);
        }

        /// <summary>
        /// Registers the companies house client, binding <see cref="CompaniesHouseClientOptions"/> from configuration.
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="configuration">The configuration to bind options from</param>
        /// <param name="sectionName">The configuration section name (defaults to <see cref="DefaultSectionName"/>)</param>
        /// <param name="configureHttpClientBuilder">Optional hook to customise the underlying <see cref="IHttpClientBuilder"/>, e.g. to add resilience handlers</param>
        /// <returns>Service collection</returns>
        public static IServiceCollection AddCompaniesHouseClient(this IServiceCollection services,
            IConfiguration configuration, string sectionName = DefaultSectionName,
            Action<IHttpClientBuilder>? configureHttpClientBuilder = null)
        {
            return services.AddCompaniesHouseClient(configuration.GetSection(sectionName), configureHttpClientBuilder);
        }

        /// <summary>
        /// Registers the companies house client, binding <see cref="CompaniesHouseClientOptions"/> from a configuration section.
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="section">The configuration section to bind options from</param>
        /// <param name="configureHttpClientBuilder">Optional hook to customise the underlying <see cref="IHttpClientBuilder"/>, e.g. to add resilience handlers</param>
        /// <returns>Service collection</returns>
        public static IServiceCollection AddCompaniesHouseClient(this IServiceCollection services,
            IConfigurationSection section, Action<IHttpClientBuilder>? configureHttpClientBuilder = null)
        {
            services.AddOptions<CompaniesHouseClientOptions>()
                .Bind(section)
                .ValidateDataAnnotations()
                .ValidateOnStart();

            return services.AddCompaniesHouseClientCore(configureHttpClientBuilder);
        }

        private static IServiceCollection AddCompaniesHouseClientCore(this IServiceCollection services,
            Action<IHttpClientBuilder>? configureHttpClientBuilder)
        {
            services.TryAddTransient<IApiKeyProvider>(provider =>
            {
                var options = provider.GetRequiredService<IOptions<CompaniesHouseClientOptions>>().Value;

                return new StaticApiKeyProvider(options.ApiKey);
            });

            services.TryAddTransient<CompaniesHouseAuthorizationHandler>();

            var httpClientBuilder = services.AddHttpClient<ICompaniesHouseClient, CompaniesHouseClient>((provider, client) =>
                {
                    var options = provider.GetRequiredService<IOptions<CompaniesHouseClientOptions>>().Value;

                    client.BaseAddress = options.BaseUri;
                })
                .AddHttpMessageHandler<CompaniesHouseAuthorizationHandler>();

            configureHttpClientBuilder?.Invoke(httpClientBuilder);

            services.TryAddCompaniesHouseSubClients();

            return services;
        }

        private static IServiceCollection TryAddCompaniesHouseSubClients(this IServiceCollection services)
        {
            services.TryAddTransient<ICompaniesHouseSearchCompanyClient>(provider =>
                provider.GetRequiredService<ICompaniesHouseClient>());
            services.TryAddTransient<ICompaniesHouseSearchOfficerClient>(provider =>
                provider.GetRequiredService<ICompaniesHouseClient>());
            services.TryAddTransient<ICompaniesHouseSearchDisqualifiedOfficerClient>(provider =>
                provider.GetRequiredService<ICompaniesHouseClient>());
            services.TryAddTransient<ICompaniesHouseSearchAllClient>(provider =>
                provider.GetRequiredService<ICompaniesHouseClient>());
            services.TryAddTransient<ICompaniesHouseSearchCompaniesAlphabeticallyClient>(provider =>
                provider.GetRequiredService<ICompaniesHouseClient>());
            services.TryAddTransient<ICompaniesHouseSearchDissolvedCompaniesClient>(provider =>
                provider.GetRequiredService<ICompaniesHouseClient>());
            services.TryAddTransient<ICompaniesHouseAdvancedCompanySearchClient>(provider =>
                provider.GetRequiredService<ICompaniesHouseClient>());
            services.TryAddTransient<ICompaniesHouseCompanyProfileClient>(provider =>
                provider.GetRequiredService<ICompaniesHouseClient>());
            services.TryAddTransient<ICompaniesHouseCompanyFilingHistoryClient>(provider =>
                provider.GetRequiredService<ICompaniesHouseClient>());
            services.TryAddTransient<ICompaniesHouseOfficersClient>(provider =>
                provider.GetRequiredService<ICompaniesHouseClient>());
            services.TryAddTransient<ICompaniesHouseCompanyInsolvencyInformationClient>(provider =>
                provider.GetRequiredService<ICompaniesHouseClient>());
            services.TryAddTransient<ICompaniesHouseAppointmentsClient>(
                provider => provider.GetRequiredService<ICompaniesHouseClient>());
            services.TryAddTransient<ICompaniesHousePersonsWithSignificantControlClient>(provider =>
                provider.GetRequiredService<ICompaniesHouseClient>());
            services.TryAddTransient<ICompaniesHouseChargesClient>(provider =>
                provider.GetRequiredService<ICompaniesHouseClient>());
            services.TryAddTransient<ICompaniesHouseRegisteredOfficeAddressClient>(provider =>
                provider.GetRequiredService<ICompaniesHouseClient>());

            return services;
        }

        // ---------------------------------------------------------------
        // Named / keyed registrations — allow several distinct, separately
        // configured Companies House clients to coexist in the same
        // service collection, resolved via `[FromKeyedServices(name)]` or
        // `IServiceProvider.GetRequiredKeyedService<ICompaniesHouseClient>(name)`.
        // ---------------------------------------------------------------

        /// <summary>
        /// Registers a named companies house client, resolvable as a keyed service.
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="name">The name/key used to register and resolve this client</param>
        /// <param name="apiKey">The Api Key</param>        
        /// <returns>Service collection</returns>
        public static IServiceCollection AddCompaniesHouseClient(this IServiceCollection services, string name,
            string apiKey)
        {
            return services.AddCompaniesHouseClient(name, options => options.ApiKey = apiKey);
        }

        /// <summary>
        /// Registers a named companies house client, resolvable as a keyed service.
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="name">The name/key used to register and resolve this client</param>
        /// <param name="baseUri">The Base Uri of the API</param>        
        /// <param name="apiKey">The Api Key</param>        
        /// <returns>Service collection</returns>
        public static IServiceCollection AddCompaniesHouseClient(this IServiceCollection services, string name,
            Uri baseUri, string apiKey)
        {
            return services.AddCompaniesHouseClient(name, options =>
            {
                options.BaseUri = baseUri;
                options.ApiKey = apiKey;
            });
        }

        /// <summary>
        /// Registers a named companies house client, resolvable as a keyed service.
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="name">The name/key used to register and resolve this client</param>
        /// <param name="configure">Companies house client options configuration</param>
        /// <param name="configureHttpClientBuilder">Optional hook to customise the underlying <see cref="IHttpClientBuilder"/>, e.g. to add resilience handlers</param>
        /// <returns>Service collection</returns>
        public static IServiceCollection AddCompaniesHouseClient(this IServiceCollection services, string name,
            Action<CompaniesHouseClientOptions> configure,
            Action<IHttpClientBuilder>? configureHttpClientBuilder = null)
        {
            services.AddOptions<CompaniesHouseClientOptions>(name)
                .Configure(configure)
                .ValidateDataAnnotations()
                .ValidateOnStart();

            return services.AddCompaniesHouseClientCore(name, configureHttpClientBuilder);
        }

        /// <summary>
        /// Registers a named companies house client, resolvable as a keyed service.
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="name">The name/key used to register and resolve this client</param>
        /// <param name="configure">Companies house client options configuration</param>
        /// <param name="configureHttpClientBuilder">Optional hook to customise the underlying <see cref="IHttpClientBuilder"/>, e.g. to add resilience handlers</param>
        /// <returns>Service collection</returns>
        public static IServiceCollection AddCompaniesHouseClient(this IServiceCollection services, string name,
            Action<IServiceProvider, CompaniesHouseClientOptions> configure,
            Action<IHttpClientBuilder>? configureHttpClientBuilder = null)
        {
            services.AddOptions<CompaniesHouseClientOptions>(name)
                .Configure<IServiceProvider>((options, provider) => configure(provider, options))
                .ValidateDataAnnotations()
                .ValidateOnStart();

            return services.AddCompaniesHouseClientCore(name, configureHttpClientBuilder);
        }

        /// <summary>
        /// Registers a named companies house client, binding <see cref="CompaniesHouseClientOptions"/> from configuration.
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="name">The name/key used to register and resolve this client</param>
        /// <param name="configuration">The configuration to bind options from</param>
        /// <param name="sectionName">The configuration section name (defaults to <see cref="DefaultSectionName"/>)</param>
        /// <param name="configureHttpClientBuilder">Optional hook to customise the underlying <see cref="IHttpClientBuilder"/>, e.g. to add resilience handlers</param>
        /// <returns>Service collection</returns>
        public static IServiceCollection AddCompaniesHouseClient(this IServiceCollection services, string name,
            IConfiguration configuration, string sectionName = DefaultSectionName,
            Action<IHttpClientBuilder>? configureHttpClientBuilder = null)
        {
            return services.AddCompaniesHouseClient(name, configuration.GetSection(sectionName),
                configureHttpClientBuilder);
        }

        /// <summary>
        /// Registers a named companies house client, binding <see cref="CompaniesHouseClientOptions"/> from a configuration section.
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="name">The name/key used to register and resolve this client</param>
        /// <param name="section">The configuration section to bind options from</param>
        /// <param name="configureHttpClientBuilder">Optional hook to customise the underlying <see cref="IHttpClientBuilder"/>, e.g. to add resilience handlers</param>
        /// <returns>Service collection</returns>
        public static IServiceCollection AddCompaniesHouseClient(this IServiceCollection services, string name,
            IConfigurationSection section, Action<IHttpClientBuilder>? configureHttpClientBuilder = null)
        {
            services.AddOptions<CompaniesHouseClientOptions>(name)
                .Bind(section)
                .ValidateDataAnnotations()
                .ValidateOnStart();

            return services.AddCompaniesHouseClientCore(name, configureHttpClientBuilder);
        }

        private static IServiceCollection AddCompaniesHouseClientCore(this IServiceCollection services, string name,
            Action<IHttpClientBuilder>? configureHttpClientBuilder)
        {
            services.TryAddKeyedTransient<IApiKeyProvider>(name, (provider, key) =>
            {
                var options = provider.GetRequiredService<IOptionsMonitor<CompaniesHouseClientOptions>>().Get((string)key!);

                return new StaticApiKeyProvider(options.ApiKey);
            });

            var httpClientBuilder = services.AddHttpClient(name)
                .ConfigureHttpClient((provider, client) =>
                {
                    var options = provider.GetRequiredService<IOptionsMonitor<CompaniesHouseClientOptions>>().Get(name);

                    client.BaseAddress = options.BaseUri;
                })
                .AddHttpMessageHandler(provider =>
                    new CompaniesHouseAuthorizationHandler(
                        provider.GetRequiredKeyedService<IApiKeyProvider>(name)));

            configureHttpClientBuilder?.Invoke(httpClientBuilder);

            services.TryAddKeyedTransient<ICompaniesHouseClient>(name, (provider, key) =>
                new CompaniesHouseClient(provider.GetRequiredService<System.Net.Http.IHttpClientFactory>().CreateClient((string)key!)));

            services.TryAddKeyedCompaniesHouseSubClients(name);

            return services;
        }

        private static IServiceCollection TryAddKeyedCompaniesHouseSubClients(this IServiceCollection services,
            string name)
        {
            services.TryAddKeyedTransient<ICompaniesHouseSearchCompanyClient>(name, (provider, key) =>
                provider.GetRequiredKeyedService<ICompaniesHouseClient>(key));
            services.TryAddKeyedTransient<ICompaniesHouseSearchOfficerClient>(name, (provider, key) =>
                provider.GetRequiredKeyedService<ICompaniesHouseClient>(key));
            services.TryAddKeyedTransient<ICompaniesHouseSearchDisqualifiedOfficerClient>(name, (provider, key) =>
                provider.GetRequiredKeyedService<ICompaniesHouseClient>(key));
            services.TryAddKeyedTransient<ICompaniesHouseSearchAllClient>(name, (provider, key) =>
                provider.GetRequiredKeyedService<ICompaniesHouseClient>(key));
            services.TryAddKeyedTransient<ICompaniesHouseSearchCompaniesAlphabeticallyClient>(name, (provider, key) =>
                provider.GetRequiredKeyedService<ICompaniesHouseClient>(key));
            services.TryAddKeyedTransient<ICompaniesHouseSearchDissolvedCompaniesClient>(name, (provider, key) =>
                provider.GetRequiredKeyedService<ICompaniesHouseClient>(key));
            services.TryAddKeyedTransient<ICompaniesHouseAdvancedCompanySearchClient>(name, (provider, key) =>
                provider.GetRequiredKeyedService<ICompaniesHouseClient>(key));
            services.TryAddKeyedTransient<ICompaniesHouseCompanyProfileClient>(name, (provider, key) =>
                provider.GetRequiredKeyedService<ICompaniesHouseClient>(key));
            services.TryAddKeyedTransient<ICompaniesHouseCompanyFilingHistoryClient>(name, (provider, key) =>
                provider.GetRequiredKeyedService<ICompaniesHouseClient>(key));
            services.TryAddKeyedTransient<ICompaniesHouseOfficersClient>(name, (provider, key) =>
                provider.GetRequiredKeyedService<ICompaniesHouseClient>(key));
            services.TryAddKeyedTransient<ICompaniesHouseCompanyInsolvencyInformationClient>(name, (provider, key) =>
                provider.GetRequiredKeyedService<ICompaniesHouseClient>(key));
            services.TryAddKeyedTransient<ICompaniesHouseAppointmentsClient>(name, (provider, key) =>
                provider.GetRequiredKeyedService<ICompaniesHouseClient>(key));
            services.TryAddKeyedTransient<ICompaniesHousePersonsWithSignificantControlClient>(name, (provider, key) =>
                provider.GetRequiredKeyedService<ICompaniesHouseClient>(key));
            services.TryAddKeyedTransient<ICompaniesHouseChargesClient>(name, (provider, key) =>
                provider.GetRequiredKeyedService<ICompaniesHouseClient>(key));
            services.TryAddKeyedTransient<ICompaniesHouseRegisteredOfficeAddressClient>(name, (provider, key) =>
                provider.GetRequiredKeyedService<ICompaniesHouseClient>(key));

            return services;
        }
    }
}
