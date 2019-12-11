using System.Collections.Generic;

namespace EmployeeMeeting.Domain.Interfaces
{
    public interface IRepository<T>
    {
        List<T> GetList();
        T Get(int id);
        T Create(T entity);
        T Update(T entity);
        void Delete(int id);
    }
}
