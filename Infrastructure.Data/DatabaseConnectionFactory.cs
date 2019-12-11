using EmployeeMeeting.Domain.Interfaces;
using System.Data;

namespace EmployeeMeeting.Infrastructure.Data
{
    public class DatabaseConnectionFactory : IDatabaseConnectionFactory
    {
        private readonly IDbConnection _dbConnection;

        public DatabaseConnectionFactory(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public IDbConnection GetConnection()
        {
            return _dbConnection;
        }
    }
}
