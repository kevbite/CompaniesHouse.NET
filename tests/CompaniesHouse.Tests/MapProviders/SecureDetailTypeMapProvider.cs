using System.Collections.Generic;
using CompaniesHouse.Response;
using CompaniesHouse.Response.CompanyProfile;

namespace CompaniesHouse.Tests.MapProviders
{
    public class SecureDetailTypeMapProvider : IEnumDataMapProvider<SecuredDetailType>
    {
        public IReadOnlyDictionary<string, SecuredDetailType> Map => EnumerationMappings.PossibleSecuredDetailTypes;
    }
    
    public class ForeignAccountTypeMapProvider : IEnumDataMapProvider<ForeignAccountType>
    {
        public IReadOnlyDictionary<string, ForeignAccountType> Map => EnumerationMappings.PossibleForeignAccountTypes;
    }
    
    public class TermsOfAccountPublicationMapProvider : IEnumDataMapProvider<TermsOfAccountPublication>
    {
        public IReadOnlyDictionary<string, TermsOfAccountPublication> Map => EnumerationMappings.PossibleTermsOfAccountPublication;
    }
}