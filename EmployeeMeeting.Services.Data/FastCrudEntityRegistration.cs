using Dapper.FastCrud;
using EmployeeMeeting.Domain.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeMeeting.Services.Data
{
    public static class FastCrudEntityRegistration
    {
        public static void Register()
        {
            OrmConfiguration.DefaultDialect = SqlDialect.MsSql;

            OrmConfiguration.GetDefaultEntityMapping<City>()
                .SetTableName("City")
                .SetProperty(x => x.CityId, prop => prop.SetPrimaryKey().SetDatabaseGenerated(DatabaseGeneratedOption.Identity))
                .GetProperty(x => x.TimeOffset).IsExcludedFromInserts = true;

            OrmConfiguration.GetDefaultEntityMapping<City>()
                .GetProperty(x => x.TimeOffset).IsExcludedFromUpdates = true;
        }
    }
}
