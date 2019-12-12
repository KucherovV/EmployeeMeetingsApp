using EmployeeMeeting.Domain.Core;
using EmployeeMeeting.Domain.Interfaces;
using EmployeeMeeting.Services.Interfaces;
using System.Collections.Generic;

namespace EmployeeMeeting.Services.Data
{
    public class CityService : ICityService
    {
        private readonly IRepository<City, int> _repository;

        public CityService(IRepository<City, int> repository)
        {
            _repository = repository;
        }

        public int Create(City city)
        {
            var cityId = _repository.Create(city);

            return cityId;
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

        public int Update(City city)
        {
            var cityId = _repository.Update(city);

            return cityId;
        }
    }
}
