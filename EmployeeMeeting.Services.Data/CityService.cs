using Domain.Core;
using Domain.Interfaces;
using EmployeeMeeting.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace EmployeeMeeting.Services.Data
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _repo;
        
        public CityService(ICityRepository repository)
        {
            _repo = repository;
        }
        public void Create(City city)
        {
            _repo.Create(city);
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }

        public City GetCity(int id)
        {
            var city = _repo.Get(id);
            return city;
        }

        public IEnumerable<City> GetCities()
        {
            var cities = _repo.GetList();
            return cities;
        }

        public void Update(City city)
        {
            _repo.Update(city);
        }
    }
}
