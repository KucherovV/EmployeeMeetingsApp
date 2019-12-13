using Dapper.FastCrud;
using EmployeeMeeting.Domain.Interfaces;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace EmployeeMeeting.Infrastructure.Data
{
    public abstract class AbstractRepository<TEntity, TKey> : IRepository<TEntity, TKey>
    {
        private readonly string _connectionString;

        protected AbstractRepository(IDatabaseConnectionFactory connectionFactory)
        {
            _connectionString = connectionFactory.GetConnection().ConnectionString;
        }

        public virtual TKey Create(TEntity entity)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                db.Insert(entity);
            }

            return GetId(entity);
        }

        public virtual void Delete(TKey id)
        {
            var idColumnName = GetIdColumnName();

            using (var db = new SqlConnection(_connectionString))
            {
                var entity = db.Find<TEntity>(x => x.Where($"{idColumnName} = {id}")).SingleOrDefault();

                db.Delete(entity);
            }
        }

        public virtual TEntity Get(TKey id)
        {
            var idColumnName = GetIdColumnName();

            using (var db = new SqlConnection(_connectionString))
            {
                return db.Find<TEntity>(x => x.Where($"{idColumnName} = {id}")).SingleOrDefault();
            }
        }

        public virtual List<TEntity> GetList()
        {
            using (var db = new SqlConnection(_connectionString))
            {
                return db.Find<TEntity>().ToList();
            }
        }

        public virtual TKey Update(TEntity entity)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                db.Update(entity);
            }

            return GetId(entity);
        }

        protected abstract TKey GetId(TEntity entity);

        protected abstract string GetIdColumnName();
    }
}
