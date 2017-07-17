using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication.DAL.Interfaces
{
    public interface ICommonRepository<TEntity> where TEntity : class
    {
        void Create(TEntity entity);

        void Update(TEntity entity);

        void Delete(int id);

        TEntity Get(int id);

        IQueryable<TEntity> GetAll();

        IEnumerable<TEntity> Find(Func<TEntity, bool> predicate);
    }
}