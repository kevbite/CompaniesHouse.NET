using System;

namespace CompaniesHouse.UriBuilders
{
    public class PersonsWithSignificantControlBuilder : IPersonsWithSignificantControlBuilder
    {
        public Uri Build(string companyNumber, int startIndex, int pageSize)
        {
            var path = $"company/{Uri.EscapeDataString(companyNumber)}/persons-with-significant-control?items_per_page={pageSize}&start_index={startIndex}";

            return new Uri(path, UriKind.Relative);
        }
    }
}
