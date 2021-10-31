using System;

namespace CompaniesHouse.UriBuilders
{
    public class RegisteredOfficeAddressUriBuilder : IRegisteredOfficeAddressUriBuilder
    {
        public Uri Build(string companyNumber)
        {
            var path = $"company/{Uri.EscapeDataString(companyNumber)}/registered-office-address";

            return new Uri(path, UriKind.Relative);
        }
    }
}