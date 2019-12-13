using EmployeeMeeting.Domain.Core;
using EmployeeMeeting.Domain.Interfaces;

namespace EmployeeMeeting.Infrastructure.Data
{
    public class CityRepository : AbstractRepository<City, int>
    {
        public CityRepository(IDatabaseConnectionFactory connectionFactory) : base(connectionFactory) { }

        protected override int GetId(City city)
        {
            return city.CityId;
        }

        protected override string GetIdColumnName()
        {
            return nameof(City.CityId);
        }
    }
}
