using System;

namespace CompaniesHouse.UriBuilders
{
    public interface IDisqualifiedOfficerUriBuilder
    {
        Uri BuildNatural(string officerId);

        Uri BuildCorporate(string officerId);
    }
}
