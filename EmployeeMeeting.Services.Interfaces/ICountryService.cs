using EmployeeMeeting.Domain.Core;
using System.Collections.Generic;

namespace EmployeeMeeting.Services.Interfaces
{
    public interface ICountryService
    {
        Country GetCountry(int id);
        List<Country> GetCountries();
        Country Create(Country country);
        Country Update(Country country);
        void Delete(int id);
    }
}
