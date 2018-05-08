using System;
using System.Collections.Generic;

namespace RideBikeProjectDAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Create(TEntity entity);
        List<TEntity> Get();
        List<TEntity> Get(Func<TEntity, bool> predicate);
        List<TEntity> Paging(Func<TEntity, string> predicate, int skip, int take);
        List<TEntity> Paging(Func<TEntity, long> predicate, int skip, int take);
        int Count();
        int Count(Func<TEntity, bool> predicate);
        TEntity Find(long id);
        void Update(TEntity entity);
        void Remove(long id);
    }
}
