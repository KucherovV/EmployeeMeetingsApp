using EmployeeMeeting.Domain.Core;
using EmployeeMeeting.Domain.Interfaces;
using System.Collections.Generic;

namespace EmployeeMeeting.Infrastructure.Data
{
    public class CountryRepository : IRepository<Country, int>
    {
        //private readonly IDatabaseConnectionFactory _connectionFactory;

        //private readonly string _connectionString;

        //public CountryRepository(IDatabaseConnectionFactory connectionFactory)
        //{
        //    _connectionFactory = connectionFactory;

        //    _connectionString = _connectionFactory.GetConnection().ConnectionString;
        //}

        //public Country Create(Country country)
        //{
        //    using (var db = new SqlConnection(_connectionString))
        //    {
        //        var sqlQuery = $"INSERT INTO Country VALUES('{country.Name}'); SELECT CAST(SCOPE_IDENTITY() as int)";
        //        var countryId = db.Query<int>(sqlQuery).FirstOrDefault();
        //        country.CountryId = countryId;
        //    }

        //    return country;
        //}

        //public void Delete(int id)
        //{
        //    using (var db = new SqlConnection(_connectionString))
        //    {
        //        var sqlQuery = $"DELETE FROM Country WHERE CountryId = {id}";
        //        db.Execute(sqlQuery);
        //    }
        //}

        //public Country Get(int id)
        //{
        //    Country country;

        //    using (var db = new SqlConnection(_connectionString))
        //    {
        //        country = db.Query<Country>($"SELECT * FROM Country WHERE CountryId = {id}").FirstOrDefault();
        //    }

        //    return country;
        //}

        //public List<Country> GetList()
        //{
        //    List<Country> countries;

        //    using (var db = new SqlConnection(_connectionString))
        //    {
        //        countries = db.Query<Country>("SELECT * FROM Country").ToList();
        //    }

        //    return countries;
        //}

        //public Country Update(Country country)
        //{
        //    using (var db = new SqlConnection(_connectionString))
        //    {
        //        var sqlQuery = $"UPDATE Country SET Name = {country.Name} WHERE CountryId = {country.CountryId}; SELECT * FROM Country WHERE CountryId = {country.CountryId}";
        //        country = db.Query<Country>(sqlQuery).FirstOrDefault();
        //    }

        //    return country;
        //}
        public int Create(Country entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Country Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Country> GetList()
        {
            throw new System.NotImplementedException();
        }

        public int Update(Country entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
