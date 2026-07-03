namespace CompaniesHouse.Tests.ResourceBuilders
{
    public class CompanyFilingHistory
    {
        public string HistoryStatus { get; set; } = null!;

        public string ETag { get; set; } = null!;

        public int TotalCount { get; set; }

        public int ItemsPerPage { get; set; }

        public int StartIndex { get; set; }

        public FilingHistoryItem[] Items { get; set; } = null!;

        public string Kind { get; set; } = null!;
    }
}
