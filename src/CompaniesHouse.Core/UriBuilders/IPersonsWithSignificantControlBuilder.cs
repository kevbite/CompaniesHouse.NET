using System;

namespace CompaniesHouse.Core.UriBuilders
{
    public interface IPersonsWithSignificantControlBuilder
    {
        Uri Build(string companyNumber, int startIndex, int pageSize);
    }
}
