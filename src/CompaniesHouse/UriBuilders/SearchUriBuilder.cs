using System.Text;
using CompaniesHouse.Request;
using Newtonsoft.Json;

namespace CompaniesHouse.UriBuilders
{
    public class QuerySearchUriBuilder<TSearch> : SearchUriBuilder<TSearch>
        where TSearch : IQuerySearchRequest
    {
        public QuerySearchUriBuilder(string path) : base(path)
        {
        }

        protected override string BuildQuery(TSearch request)
        {
            var queryBuilder = new StringBuilder(base.BuildQuery(request));

            AppendParameterIfValid(queryBuilder, "q", request.Query, value => !string.IsNullOrWhiteSpace(value));

            return queryBuilder.ToString();
        }
    }

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
            var queryBuilder = new StringBuilder("?");

            AppendParameterIfValid(queryBuilder, "items_per_page", request.ItemsPerPage, value => value.HasValue);
            AppendParameterIfValid(queryBuilder, "start_index", request.StartIndex, value => value.HasValue);

            return queryBuilder.ToString();
        }

        protected void AppendParameterIfValid<T>(
            StringBuilder builder,
            string parameterName,
            IReadOnlyCollection<T> parameterValues)
        {
            foreach (var parameterValue in parameterValues)
            {
                AppendParameterIfValid(builder, parameterName, parameterValue, _ => true);
            }
        }

        protected void AppendParameterIfValid<T>(StringBuilder builder, string parameterName, T parameterValue,
            Func<T, bool> isValid)
        {
            if (!isValid(parameterValue)) return;

            var value = parameterValue switch
            {
                string s => Uri.EscapeDataString(s),
                Enum @enum => GetEnumValue(@enum),
                DateTime dateTime => dateTime.ToString("O"),
                _ => parameterValue.ToString()
            };
            if (builder[builder.Length - 1] != '?')
            {
                builder.Append("&");
            }

            builder.Append($"{parameterName}={value}");
        }

        private static string GetEnumValue(Enum @enum)
        {
            using var stringWriter = new StringWriter();
            using var textWriter = new JsonTextWriter(stringWriter);
            HttpContentExtensions.Serializer.Serialize(textWriter, @enum, @enum.GetType());
            var s = stringWriter.ToString();
            return s.Substring(1, s.Length - 2); // Remove quotes
        }
    }
}