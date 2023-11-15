using System.Text;
using CompaniesHouse.Request;

namespace CompaniesHouse.UriBuilders
{
    public class SearchUriBuilder<TSearch> : ISearchUriBuilder<TSearch> where TSearch : ISearchRequest
    {
        private readonly string _path;

        public SearchUriBuilder(string path)
        {
            _path = path;
        }

        public Uri Build(TSearch request)
        {
            var query = BuildQuery(request);

            var pathAndQuery = _path + query;

            return new Uri(pathAndQuery, UriKind.Relative);
        }

        protected virtual string BuildQuery(TSearch request)
        {
            var queryBuilder = new StringBuilder($"?q={Uri.EscapeDataString(request.Query)}");

            if (request.ItemsPerPage.HasValue)
            {
                queryBuilder.Append($"&items_per_page={request.ItemsPerPage.Value}");
            }

            if (request.StartIndex.HasValue)
            {
                queryBuilder.Append($"&start_index={request.StartIndex.Value}");
            }

            return queryBuilder.ToString();
        }
    }
}