using System;
using LiberisLabs.CompaniesHouse.Request;

namespace LiberisLabs.CompaniesHouse.UriBuilders
{
    public class CompanySearchUriBuilder
    {
        public Uri Build(CompanySearchRequest request)
        {
            var path = "search/companies";

            var query = $"?q={Uri.EscapeDataString(request.Query)}";

            if (request.ItemsPerPage.HasValue)
            {
                query += "&items_per_page=" + request.ItemsPerPage.Value;
            }

            if (request.StartIndex.HasValue)
            {
                query += "&start_index=" + request.StartIndex.Value;
            }

            var pathAndQuery = path + query;

            return new Uri(pathAndQuery, UriKind.Relative);
        }
    }
}
