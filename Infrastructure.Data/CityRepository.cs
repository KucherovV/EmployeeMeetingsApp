using Dapper;
using EmployeeMeeting.Domain.Core;
using EmployeeMeeting.Domain.Interfaces;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace EmployeeMeeting.Infrastructure.Data
{
    public class CityRepository : IRepository<City>
    {
        private readonly IDatabaseConnectionFactory _connectionFactory;
        private readonly string _connectionString;

        public CityRepository(IDatabaseConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;

            _connectionString = _connectionFactory.GetConnection().ConnectionString;
        }

        public City Create(City city)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sqlQuery = $"INSERT INTO City (Name, TimeZone, CountryId) VALUES('{city.Name}', '{city.TimeZone}', {city.CountryId})";
                var cityId = db.Query<int>(sqlQuery).FirstOrDefault();
                city.CityId = cityId;
            }

            return city;
        }

        public void Delete(int id)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sqlQuery = $"DELETE FROM City WHERE Id = {id}";
                db.Execute(sqlQuery);
            }
        }

        public City Get(int id)
        {
            City city;

            using (var db = new SqlConnection(_connectionString))
            {
                city = db.Query<City>($"SELECT * FROM City WHERE CityId = {id}", new { id }).FirstOrDefault();
            }

            return city;
        }

        public List<City> GetList()
        {
            List<City> cities;

            using (var db = new SqlConnection(_connectionString))
            {
                cities = db.Query<City>("SELECT * FROM City").ToList();
            }

            return cities;
        }

        public City Update(City city)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sqlQuery = $"UPDATE City SET Name = {city.Name}, TimeZone = {city.TimeZone}, CountryId = {city.CountryId}, TimeOffset = {city.TimeOffset} WHERE CityId = {city.CityId}; SELECT * FROM City WHERE CityId = {city.CityId}";
                city = db.Query<City>(sqlQuery).FirstOrDefault();
            }

            return city;
        }
    }
}
