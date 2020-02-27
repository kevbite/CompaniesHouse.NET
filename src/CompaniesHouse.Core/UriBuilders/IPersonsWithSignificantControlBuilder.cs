using System;

namespace CompaniesHouse.UriBuilders
{
    public interface IPersonsWithSignificantControlBuilder
    {
        Uri Build(string companyNumber, int startIndex, int pageSize);
    }
}
