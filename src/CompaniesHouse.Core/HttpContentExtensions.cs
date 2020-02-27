using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CompaniesHouse.Core
{
    public static class HttpContentExtensions
    {
        public static async Task<T> ReadAsJsonAsync<T>(this HttpContent content)
        {
            using (var s = await content.ReadAsStreamAsync()
                .ConfigureAwait(false))
            {
                using (var sr = new StreamReader(s))
                using (var reader = new JsonTextReader(sr))
                {
                    var serializer = new JsonSerializer();

                    return serializer.Deserialize<T>(reader);
                }
            }
        }
    }
}