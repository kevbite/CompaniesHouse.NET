using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CompaniesHouse
{
    public static class HttpContentExtensions
    {
        public static async Task<T> ReadAsJsonAsync<T>(this HttpContent content)
        {
            var input = await content.ReadAsStringAsync()
                .ConfigureAwait(false);

            var obj = JsonConvert.DeserializeObject<T>(input);

            return obj;
        }
    }
}