namespace LiberisLabs.CompaniesHouse.Request
{
    public class CompanySearchRequest
    {
        public string Query { get; set; }

        public int? ItemsPerPage { get; set; }

        public int? StartIndex { get; set; }
    }
}
