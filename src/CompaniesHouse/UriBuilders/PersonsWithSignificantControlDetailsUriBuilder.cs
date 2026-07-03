using System;
using System.Collections.Generic;
using System.Globalization;

namespace CompaniesHouse.UriBuilders
{
    public class PersonsWithSignificantControlDetailsUriBuilder : IPersonsWithSignificantControlDetailsUriBuilder
    {
        public Uri BuildIndividual(string companyNumber, string notificationId)
        {
            return Build(companyNumber, $"persons-with-significant-control/individual/{Uri.EscapeDataString(notificationId)}");
        }

        public Uri BuildIndividualBeneficialOwner(string companyNumber, string notificationId)
        {
            return Build(companyNumber, $"persons-with-significant-control/individual-beneficial-owner/{Uri.EscapeDataString(notificationId)}");
        }

        public Uri BuildCorporateEntity(string companyNumber, string notificationId)
        {
            return Build(companyNumber, $"persons-with-significant-control/corporate-entity/{Uri.EscapeDataString(notificationId)}");
        }

        public Uri BuildCorporateEntityBeneficialOwner(string companyNumber, string notificationId)
        {
            return Build(companyNumber, $"persons-with-significant-control/corporate-entity-beneficial-owner/{Uri.EscapeDataString(notificationId)}");
        }

        public Uri BuildLegalPerson(string companyNumber, string notificationId)
        {
            return Build(companyNumber, $"persons-with-significant-control/legal-person/{Uri.EscapeDataString(notificationId)}");
        }

        public Uri BuildLegalPersonBeneficialOwner(string companyNumber, string notificationId)
        {
            return Build(companyNumber, $"persons-with-significant-control/legal-person-beneficial-owner/{Uri.EscapeDataString(notificationId)}");
        }

        public Uri BuildStatementsList(string companyNumber, int startIndex, int pageSize, bool? registerView)
        {
            var queryParts = new List<string>
            {
                "items_per_page=" + pageSize.ToString(CultureInfo.InvariantCulture),
                "start_index=" + startIndex.ToString(CultureInfo.InvariantCulture)
            };

            if (registerView.HasValue)
            {
                queryParts.Add("register_view=" + registerView.Value.ToString().ToLowerInvariant());
            }

            var path = $"company/{Uri.EscapeDataString(companyNumber)}/persons-with-significant-control-statements?{string.Join("&", queryParts)}";
            return new Uri(path, UriKind.Relative);
        }

        public Uri BuildStatement(string companyNumber, string statementId)
        {
            return Build(companyNumber, $"persons-with-significant-control-statements/{Uri.EscapeDataString(statementId)}");
        }

        public Uri BuildSuperSecure(string companyNumber, string superSecureId)
        {
            return Build(companyNumber, $"persons-with-significant-control/super-secure/{Uri.EscapeDataString(superSecureId)}");
        }

        public Uri BuildSuperSecureBeneficialOwner(string companyNumber, string superSecureId)
        {
            return Build(companyNumber, $"persons-with-significant-control/super-secure-beneficial-owner/{Uri.EscapeDataString(superSecureId)}");
        }

        private static Uri Build(string companyNumber, string endpointPath)
        {
            var path = $"company/{Uri.EscapeDataString(companyNumber)}/{endpointPath}";
            return new Uri(path, UriKind.Relative);
        }
    }
}
