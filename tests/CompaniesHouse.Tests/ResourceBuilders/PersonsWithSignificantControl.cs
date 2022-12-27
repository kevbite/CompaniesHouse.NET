namespace CompaniesHouse.Tests.ResourceBuilders
{
    public class PersonsWithSignificantControl
    {
        public int? ActiveCount { get; set; }

        public PersonWithSignificantControl[] Items { get; set; }

        public int? CeasedCount { get; set; }
    }
}