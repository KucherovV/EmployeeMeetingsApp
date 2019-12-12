using EmployeeMeeting.Domain.Core;
using EmployeeMeeting.Domain.Interfaces;

namespace EmployeeMeeting.Infrastructure.Data
{
    public class CityRepository : AbstractRepository<City, int>
    {
        public CityRepository(IDatabaseConnectionFactory connectionFactory) : base(connectionFactory) { }

        protected override int GetId(City city)
        {
            var cityId = city.CityId;

            return cityId;
        }

        protected override string GetIdColumnName()
        {
            var idColumnName = nameof(City.CityId);

            return idColumnName;
        }
    }
}
