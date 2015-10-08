using System;

namespace LiberisLabs.CompaniesHouse
{
    public interface ICompaniesHouseSettings
    {
        Uri BaseUri { get; }

        string ApiKey { get; }
    }
}