using System.Text.Json;
using System.Text.Json.Serialization;
using CompaniesHouse.JsonConverters;

namespace CompaniesHouse
{
    /// <summary>
    /// Central <see cref="JsonSerializerOptions"/> factory shared by every sub-client. One
    /// instance is used for the whole assembly rather than per-endpoint options.
    /// </summary>
    public static class CompaniesHouseJsonSerializerOptions
    {
        /// <summary>
        /// The shared, immutable options instance used for every request/response in the client.
        /// </summary>
        public static JsonSerializerOptions Default { get; } = Create();

        private static JsonSerializerOptions Create()
        {
            var options = new JsonSerializerOptions
            {
                AllowTrailingCommas = true,
                PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
                PropertyNameCaseInsensitive = true,
                NumberHandling = JsonNumberHandling.AllowReadingFromString,
            };

            options.Converters.Add(new FlexibleBooleanJsonConverterFactory());
            options.Converters.Add(new EnumMemberJsonConverterFactory());
            options.Converters.Add(new EnumArrayOrSingleJsonConverterFactory());
            options.Converters.Add(new SearchItemConverter());

            return options;
        }
    }
}
