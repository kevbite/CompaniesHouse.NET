using System;

namespace CompaniesHouse.UriBuilders
{
    public class DisqualifiedOfficerUriBuilder : IDisqualifiedOfficerUriBuilder
    {
        public Uri BuildNatural(string officerId)
        {
            var path = $"disqualified-officers/natural/{Uri.EscapeDataString(officerId)}";
            return new Uri(path, UriKind.Relative);
        }

        public Uri BuildCorporate(string officerId)
        {
            var path = $"disqualified-officers/corporate/{Uri.EscapeDataString(officerId)}";
            return new Uri(path, UriKind.Relative);
        }
    }
}
