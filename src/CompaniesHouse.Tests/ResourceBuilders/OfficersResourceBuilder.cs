using System.Linq;

namespace CompaniesHouse.Tests.ResourceBuilders
{
    public class OfficersResourceBuilder
    {
        private readonly Officers _officers;

        public OfficersResourceBuilder(Officers officers)
        {
            _officers = officers;
        }

        public string Create()
        {
            return
                $@"{{
                      ""active_count"" : {_officers.ActiveCount},
                      ""items"" : [
                        {string.Join(",", _officers.Items.Select(GetOfficerJsonBlock).ToArray())}
                      ],
                      ""resigned_count"" : {_officers.ResignedCount}
                }}";
        }

        private string GetOfficerJsonBlock(Officer officer)
        {
            return $@" {{
                    ""appointed_on"" : ""{officer.AppointedOn.ToString("yyyy-MM-dd")}"",
                    ""resigned_on"" : ""{officer.ResignedOn.ToString("yyyy-MM-dd")}"",
                    ""date_of_birth"" : {{
                       ""day"" : {officer.DateOfBirth.Day},
                       ""month"" : {officer.DateOfBirth.Month},
                       ""year"" : {officer.DateOfBirth.Year}
                    }},
                    ""name"" : ""{officer.Name}"",
                    ""officer_role"" : ""{officer.OfficerRole}"",
                    ""nationality"" : ""{officer.Nationality}""
                 }}";
        }
    }
}
