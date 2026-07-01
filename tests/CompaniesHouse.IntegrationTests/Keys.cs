using System;

namespace CompaniesHouse.IntegrationTests
{
    public static class Keys
    {
        public static string ApiKey { get; } = Environment.GetEnvironmentVariable("COMPANIES_HOUSE_API_KEY")!;

        /// <summary>
        /// Same value as <see cref="ApiKey"/> without the null-forgiving suppression, for use by
        /// <see cref="IntegrationFactAttribute"/>/<see cref="IntegrationTheoryAttribute"/> to decide
        /// whether to skip a test cleanly when no key is configured.
        /// </summary>
        public static string? ApiKeyOrNull { get; } = Environment.GetEnvironmentVariable("COMPANIES_HOUSE_API_KEY");
    }
}