using System;

namespace CompaniesHouse.UriBuilders
{
    public interface IOfficersAppointmentUriBuilder
    {
        Uri Build(string companyNumber, string appointmentId);
    }
}