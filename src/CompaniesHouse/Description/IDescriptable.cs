namespace CompaniesHouse.Description
{
    public interface IDescriptable
    {
        string GetDescription(string format, string dateFormat = null);
    }
}
