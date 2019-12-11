using Domain.Core;
using System;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface ICityRepository
    {
        IEnumerable<City> GetList();
        City Get(int id);
        void Create(City city);
        void Update(City city);
        void Delete(int id);

    }
}
