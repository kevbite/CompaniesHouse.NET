using System;

namespace CompaniesHouse
{
    public interface ICompaniesHouseSettings
    {
        Uri BaseUri { get; }

        string ApiKey { get; }
    }
}