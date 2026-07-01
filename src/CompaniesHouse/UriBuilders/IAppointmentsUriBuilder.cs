using System;

namespace CompaniesHouse.UriBuilders
{
    public interface IAppointmentsUriBuilder
    {
        Uri Build(string officerId, int startIndex, int pageSize);
    }
}
