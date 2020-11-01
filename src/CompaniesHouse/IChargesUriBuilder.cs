using System;

namespace CompaniesHouse
{
    public interface IChargesUriBuilder
    {
        Uri Build(string companyNumber);
    }
}