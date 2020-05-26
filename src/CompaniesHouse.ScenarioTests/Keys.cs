using System;

namespace CompaniesHouse.ScenarioTests
{
    public static class Keys
    {
        public static string ApiKey { get; } = Environment.GetEnvironmentVariable("api_key");
    }
}