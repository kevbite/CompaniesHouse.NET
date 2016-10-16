namespace CompaniesHouse.Tests.ResourceBuilders.OfficerSearchResource
{
    public class ResourceDetails
    {
        public int ItemsPerPage { get; set; }

        public int StartIndex { get; set; }

        public int PageNumber { get; set; }

        public int TotalResults { get; set; }

        public string Kind { get; set; }

        public Item[] Officers { get; set; }
    }
}
