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

            var id = GetId(entity);

            return id;
        }

        public virtual void Delete(TKey id)
        {
            var idColumnName = GetIdColumnName();
            TEntity entity;

            using (var db = new SqlConnection(_connectionString))
            {
                entity = db.Find<TEntity>(x => x.Where($"{idColumnName} = {id}")).SingleOrDefault();

                db.Delete(entity);
            }
        }

        public virtual TEntity Get(TKey id)
        {
            var idColumnName = GetIdColumnName();
            TEntity entity;

            using (var db = new SqlConnection(_connectionString))
            {
                entity = db.Find<TEntity>(x => x.Where($"{idColumnName} = {id}")).SingleOrDefault();
            }

            return entity;
        }

        public virtual List<TEntity> GetList()
        {
            List<TEntity> entities;

            using (var db = new SqlConnection(_connectionString))
            {
                entities = db.Find<TEntity>().ToList();
            }

            return entities;
        }

        public virtual TKey Update(TEntity entity)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                db.Update(entity);
            }

            var id = GetId(entity);

            return id;
        }

        protected abstract TKey GetId(TEntity entity);

        protected abstract string GetIdColumnName();
    }
}
