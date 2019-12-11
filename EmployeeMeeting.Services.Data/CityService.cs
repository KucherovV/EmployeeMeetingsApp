using EmployeeMeeting.Domain.Core;
using EmployeeMeeting.Domain.Interfaces;
using EmployeeMeeting.Services.Interfaces;
using System.Collections.Generic;

namespace EmployeeMeeting.Services.Data
{
    public class CityService : ICityService
    {
        private readonly IRepository<City> _repository;

        public CityService(IRepository<City> repository)
        {
            _repository = repository;
        }

        public City Create(City city)
        {
            city = _repository.Create(city);

            return city;
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public City GetCity(int id)
        {
            var city = _repository.Get(id);
            return city;
        }

        public IEnumerable<City> GetCities()
        {
            var cities = _repository.GetList();
            return cities;
        }

        public City Update(City city)
        {
            city = _repository.Update(city);

            return city;
        }
    }
}
