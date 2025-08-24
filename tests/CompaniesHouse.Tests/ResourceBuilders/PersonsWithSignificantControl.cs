namespace CompaniesHouse.Tests.ResourceBuilders
{
    public class PersonsWithSignificantControl
    {
        public int? ActiveCount { get; set; }

        public PersonWithSignificantControl[] Items { get; set; }

        public int? CeasedCount { get; set; }

        public int ItemsPerPage { get; set; }

        public int StartIndex { get; set; }

        public int TotalResults { get; set; }
    }
}