using System.Collections.Generic;

namespace EmployeeMeeting.Domain.Interfaces
{
    public interface IRepository<TEntity, TKey>
    {
        List<TEntity> GetList();
        TEntity Get(TKey id);
        TKey Create(TEntity entity);
        TKey Update(TEntity entity);
        void Delete(TKey id);
    }
}
