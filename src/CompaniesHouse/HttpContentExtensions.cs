using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CompaniesHouse
{
    public static class HttpContentExtensions
    {
        public static readonly JsonSerializer Serializer = new()
        {
            Converters = { new StringEnumConverter() }
        };

        public static async Task<T> ReadAsJsonAsync<T>(this HttpContent content)
        {
            using var s = await content.ReadAsStreamAsync()
                .ConfigureAwait(false);
            using var sr = new StreamReader(s);
            using var reader = new JsonTextReader(sr);

            return Serializer.Deserialize<T>(reader);
        }
    }
}