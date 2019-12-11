using Domain.Core;
using System;
using System.Collections.Generic;

namespace EmployeeMeeting.Services.Interfaces
{
    public interface ICityService
    {
        IEnumerable<City> GetCities();
        City GetCity(int id);
        void Create(City city);
        void Update(City city);
        void Delete(int id);
    }
}
