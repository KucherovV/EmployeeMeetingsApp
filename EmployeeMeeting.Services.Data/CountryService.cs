﻿using EmployeeMeeting.Domain.Core;
using EmployeeMeeting.Services.Interfaces;
using System.Collections.Generic;

namespace EmployeeMeeting.Services.Data
{
    public class CountryService : ICountryService
    {
        //private readonly IRepository<Country> _repository;

        //public CountryService(IRepository<Country> repository)
        //{
        //    _repository = repository;
        //}

        //public Country Create(Country country)
        //{
        //    country = _repository.Create(country);

        //    return country;
        //}

        //public void Delete(int id)
        //{
        //    _repository.Delete(id);
        //}

        //public List<Country> GetCountries()
        //{
        //    var countries = _repository.GetList();

        //    return countries;
        //}

        //public Country GetCountry(int id)
        //{
        //    var country = _repository.Get(id);

        //    return country;
        //}

        //public Country Update(Country country)
        //{
        //    country = _repository.Update(country);

        //    return country;
        //}
        public Country Create(Country country)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Country> GetCountries()
        {
            throw new System.NotImplementedException();
        }

        public Country GetCountry(int id)
        {
            throw new System.NotImplementedException();
        }

        public Country Update(Country country)
        {
            throw new System.NotImplementedException();
        }
    }
}
