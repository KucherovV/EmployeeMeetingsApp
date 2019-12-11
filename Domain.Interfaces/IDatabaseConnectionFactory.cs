using System.Data;

namespace EmployeeMeeting.Domain.Interfaces
{
    public interface IDatabaseConnectionFactory
    {
        IDbConnection GetConnection();
    }
}
