using Xunit;

namespace CompaniesHouse.IntegrationTests
{
    /// <summary>
    /// A <see cref="TheoryAttribute"/> counterpart to <see cref="IntegrationFactAttribute"/> -
    /// skips cleanly when <c>COMPANIES_HOUSE_API_KEY</c> is not set.
    /// </summary>
    public sealed class IntegrationTheoryAttribute : TheoryAttribute
    {
        public IntegrationTheoryAttribute()
        {
            if (string.IsNullOrWhiteSpace(Keys.ApiKeyOrNull))
            {
                Skip = "COMPANIES_HOUSE_API_KEY environment variable is not set - skipping integration test that calls the real API.";
            }
        }
    }
}
