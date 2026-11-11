using System;
using Xunit;

namespace CompaniesHouse.ScenarioTests
{
    public sealed class ScenarioFactAttribute : FactAttribute
    {
        public ScenarioFactAttribute()
        {
            if (string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("COMPANIES_HOUSE_API_KEY")))
            {
                Skip = "COMPANIES_HOUSE_API_KEY environment variable is not set - skipping scenario test that calls the real API.";
            }
        }
    }
}
