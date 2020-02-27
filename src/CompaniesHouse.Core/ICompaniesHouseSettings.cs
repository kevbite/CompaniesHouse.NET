using System;

namespace CompaniesHouse.Core
{
    public interface ICompaniesHouseSettings
    {
        Uri BaseUri { get; }

        string ApiKey { get; }
    }
}