using System;
using System.Net;
using System.Net.Http;

namespace CompaniesHouse
{
    public class CompaniesHouseSettings : ICompaniesHouseSettings
    {
        public static readonly Func<HttpMessageHandler> DefaultHttpMessageHandlerCreator = () => new HttpClientHandler
        {
            AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
        };

        public CompaniesHouseSettings(Uri baseUri, string apiKey, Func<HttpMessageHandler> httpMessageHandlerCreator)
        {
            BaseUri = baseUri;
            ApiKey = apiKey;
            HttpMessageHandlerCreator = httpMessageHandlerCreator;
        }

        public CompaniesHouseSettings(Uri baseUri, string apiKey)
            : this(baseUri, apiKey, DefaultHttpMessageHandlerCreator)
        {
        }

        public CompaniesHouseSettings(string apiKey)
            :this(CompaniesHouseUris.Default, apiKey, DefaultHttpMessageHandlerCreator)
        {
        }

        public Uri BaseUri { get; }

        public string ApiKey { get; }

        public Func<HttpMessageHandler> HttpMessageHandlerCreator { get; }
    }
}