using EmployeeMeeting.Domain.Core;
using System.Collections.Generic;

namespace EmployeeMeeting.Services.Interfaces
{
    public interface ICityService
    {
        IEnumerable<City> GetCities();
        City GetCity(int id);
        int Create(City city);
        int Update(City city);
        void Delete(int id);
    }
}
