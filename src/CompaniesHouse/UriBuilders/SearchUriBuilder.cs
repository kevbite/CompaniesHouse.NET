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

            AppendParameterIfValid(queryBuilder, "items_per_page", request.ItemsPerPage, value => value.HasValue);
            AppendParameterIfValid(queryBuilder, "start_index", request.StartIndex, value => value.HasValue);

            return queryBuilder.ToString();
        }

        protected void AppendParameterIfValid<T>(StringBuilder builder, string parameterName, T parameterValue, Func<T, bool> isValid)
        {
            if (!isValid(parameterValue)) return;

            var value = parameterValue switch
            {
                string s => Uri.EscapeDataString(s),
                _ => parameterValue.ToString()
            };

            builder.Append($"&{parameterName}={value}");
        }
    }
}