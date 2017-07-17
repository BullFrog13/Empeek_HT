using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebApplication.DAL.EF;
using WebApplication.DAL.Interfaces;

namespace WebApplication.DAL.Repositories
{
    public class CommonRepository<TEntity> : ICommonRepository<TEntity> where TEntity : class
    {
        private readonly DatabaseContext _databaseContext;

        public CommonRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _databaseContext.Set<TEntity>();
        }

        public IEnumerable<TEntity> Find(Func<TEntity, bool> predicate)
        {
            return _databaseContext.Set<TEntity>().Where(predicate);
        }

        public TEntity Get(int id)
        {
            return _databaseContext.Set<TEntity>().Find(id);
        }

        public virtual void Create(TEntity entity)
        {
            _databaseContext.Set<TEntity>().Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            _databaseContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(int id)
        {
            var entity = Get(id);
            _databaseContext.Set<TEntity>().Remove(entity);
        }
    }
}