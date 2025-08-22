using System;

namespace CompaniesHouse.IntegrationTests
{
    public static class Keys
    {
        public static string ApiKey
        {
            get
            {
                var key = Environment.GetEnvironmentVariable("COMPANIES_HOUSE_API_KEY");
                if (string.IsNullOrEmpty(key))
                {
                    throw new InvalidOperationException("COMPANIES_HOUSE_API_KEY environment variable is not set.");
                }
                return key;
            }
        }
    }
}
