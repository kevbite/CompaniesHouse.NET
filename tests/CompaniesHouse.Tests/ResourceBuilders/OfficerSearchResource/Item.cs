namespace CompaniesHouse.Tests.ResourceBuilders.OfficerSearchResource
{
    public class Item
    {
        public string Description { get; set; } = null!;

        public string Snippet { get; set; } = null!;

        public DateOfBirth DateOfBirth { get; set; } = null!;

        public string AddressSnippet { get; set; } = null!;

        public Address Address { get; set; } = null!;

        public string[] DescriptionIdentifiers { get; set; } = null!;

        public int AppointmentCount { get; set; }

        public Links Links { get; set; } = null!;

        public string Title { get; set; } = null!;

        public string Kind { get; set; } = null!;

        public Matches Matches { get; set; } = null!;
    }
}