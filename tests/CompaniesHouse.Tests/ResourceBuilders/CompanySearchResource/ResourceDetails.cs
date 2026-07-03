namespace CompaniesHouse.Tests.ResourceBuilders.CompanySearchResource
{
    public class ResourceDetails
    {
        public string ETag { get; set; } = null!;

        public int ItemsPerPage { get; set; }

        public string Kind { get; set; } = null!;

        public int PageNumber { get; set; }

        public int StartIndex { get; set; }

        public int TotalResults { get; set; }
    }
}