namespace CompaniesHouse.Core
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