namespace LiberisLabs.CompaniesHouse
{
    public class CompaniesHouseClientResponse<T>
    {
        public CompaniesHouseClientResponse(T data)
        {
            Data = data;
        }

        public T Data { get; }
    }
}