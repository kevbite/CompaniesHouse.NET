using System;

namespace CompaniesHouse.IntegrationTests
{
    public static class Keys
    {
        public static string ApiKey { get; } = Environment.GetEnvironmentVariable("COMPANIES_HOUSE_API_KEY");
    }
}