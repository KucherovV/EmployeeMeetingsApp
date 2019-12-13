namespace EmployeeMeeting.Test
{
    //class CityServiceFake : ICityService
    //{
    //    private readonly List<City> _cities;

    //    public CityServiceFake()
    //    {
    //        _cities = new List<City>()
    //        {
    //            new City(){Name = "Gomel", CountryId = 1, CityId = 1 , TimeOffset = "+01:00", TimeZone = "W. Europe Standard Time"},
    //            new City(){Name = "Moskow", CountryId = 2, CityId = 2 , TimeOffset = "+00:00", TimeZone = "GMT Standard Time"},
    //            new City(){Name = "Grodno", CountryId = 3, CityId = 3 , TimeOffset = "+01:00", TimeZone = "W. Europe Standard Time"},
    //            new City(){Name = "Kharkov", CountryId = 2, CityId = 4 , TimeOffset = "+02:00", TimeZone = "Middle East Standard Time"},
    //        };
    //    }
    //    public void Create(City city)
    //    {
    //        city.CityId = _cities[_cities.Count - 1].CityId + 1;
    //        _cities.Add(city);
    //    }

    //    public void Delete(int id)
    //    {
    //        var city = _cities.First(c => c.CityId == id);
    //        _cities.Remove(city);
    //    }

    //    public IEnumerable<City> GetCities()
    //    {
    //        return _cities;
    //    }

    //    public City GetCity(int id)
    //    {
    //        return _cities.Where(c => c.CityId == id).FirstOrDefault();
    //    }

    //    public void Update(City city)
    //    {
    //        //var UpdateCity = _cities.Where(c => c.CityId == city.CityId).First();
    //        //UpdateCity = city;
    //    }
    //}
}
