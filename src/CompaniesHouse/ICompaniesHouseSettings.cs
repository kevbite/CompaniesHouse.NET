using System;
using System.Net.Http;

namespace CompaniesHouse
{
    public interface ICompaniesHouseSettings
    {
        Uri BaseUri { get; }

        string ApiKey { get; }

        Func<HttpMessageHandler> HttpMessageHandlerCreator { get; }
    }
}