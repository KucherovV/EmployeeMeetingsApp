using Dapper;
using Domain.Core;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Infrastructure.Data
{
    public class CityRepository : ICityRepository
    {
        string connectionString = null;
        public CityRepository(string connectionstr)
        {
            connectionString = connectionstr;
        }
        public void Create(City city)
        {
            using (var db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO City (Name, TimeZone, CountryId, TimeOffset) VALUES(@Name, @TimeZone, @CountryId, @TimeOffset)";
                db.Execute(sqlQuery, city);
            }
        }

        public void Delete(int id)
        {
            using (var db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM City WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }

        public IEnumerable<City> GetList()
        {
            using (var db = new SqlConnection(connectionString))
            {
                return db.Query<City>("SELECT * FROM City").ToList();
            }
        }

        public City Get(int id)
        {
            using (var db = new SqlConnection(connectionString))
            {
                return db.Query<City>("SELECT * FROM City WHERE CityId = @id", new { id }).FirstOrDefault();
            }
        }

        public void Update(City city)
        {
            using (var db = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE City SET Name = @Name, TimeZone = @TimeZone, CountryId = @CountryId, TimeOffset = @TimeOffset WHERE CityId = @CityId";
                db.Execute(sqlQuery, city);
            }
        }
    }
}
