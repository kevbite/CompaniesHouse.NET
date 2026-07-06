using System;
using Xunit;

namespace CompaniesHouse.IntegrationTests
{
    /// <summary>
    /// A <see cref="FactAttribute"/> that skips itself cleanly when the
    /// <c>COMPANIES_HOUSE_API_KEY</c> environment variable is not set, rather than failing with
    /// an unauthenticated/expired-key error. See plan 10 (testing strategy): integration tests
    /// must be skippable offline (e.g. in CI forks without a secret, or local dev without a key)
    /// without being reported as failures.
    /// </summary>
    public sealed class IntegrationFactAttribute : FactAttribute
    {
        public IntegrationFactAttribute()
        {
            if (string.IsNullOrWhiteSpace(Keys.ApiKeyOrNull))
            {
                Skip = "COMPANIES_HOUSE_API_KEY environment variable is not set - skipping integration test that calls the real API.";
            }
        }
    }
}
