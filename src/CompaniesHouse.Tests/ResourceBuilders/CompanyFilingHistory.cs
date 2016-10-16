namespace CompaniesHouse.Tests.ResourceBuilders
{
    public class CompanyFilingHistory
    {
        public string HistoryStatus { get; set; }

        public string ETag { get; set; }

        public int TotalCount { get; set; }

        public int ItemsPerPage { get; set; }

        public int StartIndex { get; set; }

        public FilingHistoryItem[] Items { get; set; }

        public string Kind { get; set; }
    }
}
