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
    /// Extensions to adding companies house document client to the service collection
    /// </summary>
    public static class CompaniesHouseDocumentClientServiceCollectionExtensions
    {
        /// <summary>
        /// The default configuration section name used when binding <see cref="CompaniesHouseClientDocumentOptions"/>
        /// from an <see cref="IConfiguration"/>.
        /// </summary>
        public const string DefaultSectionName = "CompaniesHouseDocument";

        /// <summary>
        /// Registers the companies house document client
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="apiKey">The Api Key</param>        
        /// <returns>Service collection</returns>
        public static IServiceCollection AddCompaniesHouseDocumentClient(this IServiceCollection services, string apiKey)
        {
            return services.AddCompaniesHouseDocumentClient(options => options.ApiKey = apiKey);
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
            return services.AddCompaniesHouseDocumentClient(options =>
            {
                options.BaseUri = baseUri;
                options.ApiKey = apiKey;
            });
        }

        /// <summary>
        /// Registers the companies house document client
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="configure">Companies house client options configuration</param>
        /// <param name="configureHttpClientBuilder">Optional hook to customise the underlying <see cref="IHttpClientBuilder"/>, e.g. to add resilience handlers</param>
        /// <returns>Service collection</returns>
        public static IServiceCollection AddCompaniesHouseDocumentClient(this IServiceCollection services,
            Action<CompaniesHouseClientDocumentOptions> configure,
            Action<IHttpClientBuilder>? configureHttpClientBuilder = null)
        {
            services.AddOptions<CompaniesHouseClientDocumentOptions>()
                .Configure(configure)
                .ValidateDataAnnotations()
                .ValidateOnStart();

            return services.AddCompaniesHouseDocumentClientCore(configureHttpClientBuilder);
        }

        /// <summary>
        /// Registers the companies house document client
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="configure">Companies house client options configuration</param>
        /// <param name="configureHttpClientBuilder">Optional hook to customise the underlying <see cref="IHttpClientBuilder"/>, e.g. to add resilience handlers</param>
        /// <returns>Service collection</returns>
        public static IServiceCollection AddCompaniesHouseDocumentClient(this IServiceCollection services,
            Action<IServiceProvider, CompaniesHouseClientDocumentOptions> configure,
            Action<IHttpClientBuilder>? configureHttpClientBuilder = null)
        {
            services.AddOptions<CompaniesHouseClientDocumentOptions>()
                .Configure<IServiceProvider>((options, provider) => configure(provider, options))
                .ValidateDataAnnotations()
                .ValidateOnStart();

            return services.AddCompaniesHouseDocumentClientCore(configureHttpClientBuilder);
        }

        /// <summary>
        /// Registers the companies house document client, binding <see cref="CompaniesHouseClientDocumentOptions"/> from configuration.
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="configuration">The configuration to bind options from</param>
        /// <param name="sectionName">The configuration section name (defaults to <see cref="DefaultSectionName"/>)</param>
        /// <param name="configureHttpClientBuilder">Optional hook to customise the underlying <see cref="IHttpClientBuilder"/>, e.g. to add resilience handlers</param>
        /// <returns>Service collection</returns>
        public static IServiceCollection AddCompaniesHouseDocumentClient(this IServiceCollection services,
            IConfiguration configuration, string sectionName = DefaultSectionName,
            Action<IHttpClientBuilder>? configureHttpClientBuilder = null)
        {
            return services.AddCompaniesHouseDocumentClient(configuration.GetSection(sectionName),
                configureHttpClientBuilder);
        }

        /// <summary>
        /// Registers the companies house document client, binding <see cref="CompaniesHouseClientDocumentOptions"/> from a configuration section.
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="section">The configuration section to bind options from</param>
        /// <param name="configureHttpClientBuilder">Optional hook to customise the underlying <see cref="IHttpClientBuilder"/>, e.g. to add resilience handlers</param>
        /// <returns>Service collection</returns>
        public static IServiceCollection AddCompaniesHouseDocumentClient(this IServiceCollection services,
            IConfigurationSection section, Action<IHttpClientBuilder>? configureHttpClientBuilder = null)
        {
            services.AddOptions<CompaniesHouseClientDocumentOptions>()
                .Bind(section)
                .ValidateDataAnnotations()
                .ValidateOnStart();

            return services.AddCompaniesHouseDocumentClientCore(configureHttpClientBuilder);
        }

        private static IServiceCollection AddCompaniesHouseDocumentClientCore(this IServiceCollection services,
            Action<IHttpClientBuilder>? configureHttpClientBuilder)
        {
            services.TryAddTransient<IApiKeyProvider>(provider =>
            {
                var options = provider.GetRequiredService<IOptions<CompaniesHouseClientDocumentOptions>>().Value;

                return new StaticApiKeyProvider(options.ApiKey);
            });

            services.TryAddTransient<CompaniesHouseAuthorizationHandler>();

            var httpClientBuilder = services
                .AddHttpClient<ICompaniesHouseDocumentClient, CompaniesHouseDocumentClient>((provider, client) =>
                {
                    var options = provider.GetRequiredService<IOptions<CompaniesHouseClientDocumentOptions>>().Value;

                    client.BaseAddress = options.BaseUri;
                })
                .AddHttpMessageHandler<CompaniesHouseAuthorizationHandler>();

            configureHttpClientBuilder?.Invoke(httpClientBuilder);

            services.TryAddTransient<ICompaniesHouseDocumentMetadataClient>(provider =>
                provider.GetRequiredService<ICompaniesHouseDocumentClient>());
            services.TryAddTransient<ICompaniesHouseDocumentDownloadClient>(provider =>
                provider.GetRequiredService<ICompaniesHouseDocumentClient>());

            return services;
        }

        // ---------------------------------------------------------------
        // Named / keyed registrations — allow several distinct, separately
        // configured Companies House document clients to coexist in the
        // same service collection, resolved via `[FromKeyedServices(name)]`
        // or `IServiceProvider.GetRequiredKeyedService<ICompaniesHouseDocumentClient>(name)`.
        // ---------------------------------------------------------------

        /// <summary>
        /// Registers a named companies house document client, resolvable as a keyed service.
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="name">The name/key used to register and resolve this client</param>
        /// <param name="apiKey">The Api Key</param>        
        /// <returns>Service collection</returns>
        public static IServiceCollection AddCompaniesHouseDocumentClient(this IServiceCollection services,
            string name, string apiKey)
        {
            return services.AddCompaniesHouseDocumentClient(name, options => options.ApiKey = apiKey);
        }

        /// <summary>
        /// Registers a named companies house document client, resolvable as a keyed service.
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="name">The name/key used to register and resolve this client</param>
        /// <param name="baseUri">The Base Uri of the API</param>        
        /// <param name="apiKey">The Api Key</param>        
        /// <returns>Service collection</returns>
        public static IServiceCollection AddCompaniesHouseDocumentClient(this IServiceCollection services,
            string name, Uri baseUri, string apiKey)
        {
            return services.AddCompaniesHouseDocumentClient(name, options =>
            {
                options.BaseUri = baseUri;
                options.ApiKey = apiKey;
            });
        }

        /// <summary>
        /// Registers a named companies house document client, resolvable as a keyed service.
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="name">The name/key used to register and resolve this client</param>
        /// <param name="configure">Companies house client options configuration</param>
        /// <param name="configureHttpClientBuilder">Optional hook to customise the underlying <see cref="IHttpClientBuilder"/>, e.g. to add resilience handlers</param>
        /// <returns>Service collection</returns>
        public static IServiceCollection AddCompaniesHouseDocumentClient(this IServiceCollection services,
            string name, Action<CompaniesHouseClientDocumentOptions> configure,
            Action<IHttpClientBuilder>? configureHttpClientBuilder = null)
        {
            services.AddOptions<CompaniesHouseClientDocumentOptions>(name)
                .Configure(configure)
                .ValidateDataAnnotations()
                .ValidateOnStart();

            return services.AddCompaniesHouseDocumentClientCore(name, configureHttpClientBuilder);
        }

        /// <summary>
        /// Registers a named companies house document client, resolvable as a keyed service.
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="name">The name/key used to register and resolve this client</param>
        /// <param name="configure">Companies house client options configuration</param>
        /// <param name="configureHttpClientBuilder">Optional hook to customise the underlying <see cref="IHttpClientBuilder"/>, e.g. to add resilience handlers</param>
        /// <returns>Service collection</returns>
        public static IServiceCollection AddCompaniesHouseDocumentClient(this IServiceCollection services,
            string name, Action<IServiceProvider, CompaniesHouseClientDocumentOptions> configure,
            Action<IHttpClientBuilder>? configureHttpClientBuilder = null)
        {
            services.AddOptions<CompaniesHouseClientDocumentOptions>(name)
                .Configure<IServiceProvider>((options, provider) => configure(provider, options))
                .ValidateDataAnnotations()
                .ValidateOnStart();

            return services.AddCompaniesHouseDocumentClientCore(name, configureHttpClientBuilder);
        }

        /// <summary>
        /// Registers a named companies house document client, binding <see cref="CompaniesHouseClientDocumentOptions"/> from configuration.
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="name">The name/key used to register and resolve this client</param>
        /// <param name="configuration">The configuration to bind options from</param>
        /// <param name="sectionName">The configuration section name (defaults to <see cref="DefaultSectionName"/>)</param>
        /// <param name="configureHttpClientBuilder">Optional hook to customise the underlying <see cref="IHttpClientBuilder"/>, e.g. to add resilience handlers</param>
        /// <returns>Service collection</returns>
        public static IServiceCollection AddCompaniesHouseDocumentClient(this IServiceCollection services,
            string name, IConfiguration configuration, string sectionName = DefaultSectionName,
            Action<IHttpClientBuilder>? configureHttpClientBuilder = null)
        {
            return services.AddCompaniesHouseDocumentClient(name, configuration.GetSection(sectionName),
                configureHttpClientBuilder);
        }

        /// <summary>
        /// Registers a named companies house document client, binding <see cref="CompaniesHouseClientDocumentOptions"/> from a configuration section.
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="name">The name/key used to register and resolve this client</param>
        /// <param name="section">The configuration section to bind options from</param>
        /// <param name="configureHttpClientBuilder">Optional hook to customise the underlying <see cref="IHttpClientBuilder"/>, e.g. to add resilience handlers</param>
        /// <returns>Service collection</returns>
        public static IServiceCollection AddCompaniesHouseDocumentClient(this IServiceCollection services,
            string name, IConfigurationSection section, Action<IHttpClientBuilder>? configureHttpClientBuilder = null)
        {
            services.AddOptions<CompaniesHouseClientDocumentOptions>(name)
                .Bind(section)
                .ValidateDataAnnotations()
                .ValidateOnStart();

            return services.AddCompaniesHouseDocumentClientCore(name, configureHttpClientBuilder);
        }

        private static IServiceCollection AddCompaniesHouseDocumentClientCore(this IServiceCollection services,
            string name, Action<IHttpClientBuilder>? configureHttpClientBuilder)
        {
            services.TryAddKeyedTransient<IApiKeyProvider>(name, (provider, key) =>
            {
                var options = provider.GetRequiredService<IOptionsMonitor<CompaniesHouseClientDocumentOptions>>()
                    .Get((string)key!);

                return new StaticApiKeyProvider(options.ApiKey);
            });

            var httpClientBuilder = services.AddHttpClient(name)
                .ConfigureHttpClient((provider, client) =>
                {
                    var options = provider.GetRequiredService<IOptionsMonitor<CompaniesHouseClientDocumentOptions>>()
                        .Get(name);

                    client.BaseAddress = options.BaseUri;
                })
                .AddHttpMessageHandler(provider =>
                    new CompaniesHouseAuthorizationHandler(
                        provider.GetRequiredKeyedService<IApiKeyProvider>(name)));

            configureHttpClientBuilder?.Invoke(httpClientBuilder);

            services.TryAddKeyedTransient<ICompaniesHouseDocumentClient>(name, (provider, key) =>
                new CompaniesHouseDocumentClient(
                    provider.GetRequiredService<System.Net.Http.IHttpClientFactory>().CreateClient((string)key!)));

            services.TryAddKeyedTransient<ICompaniesHouseDocumentMetadataClient>(name, (provider, key) =>
                provider.GetRequiredKeyedService<ICompaniesHouseDocumentClient>(key));
            services.TryAddKeyedTransient<ICompaniesHouseDocumentDownloadClient>(name, (provider, key) =>
                provider.GetRequiredKeyedService<ICompaniesHouseDocumentClient>(key));

            return services;
        }
    }
}
