using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideBikeProjectDAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Create(TEntity entity);
        List<TEntity> Get();
        List<TEntity> Get(Func<TEntity, bool> predicate);
        List<TEntity> Paging(Func<TEntity, string> predicate, string order, int skip, int take);
        int Count();
        int Count(Func<TEntity, bool> predicate);
        TEntity Find(long id);
        void Update(TEntity entity);
        void Remove(long id);
    }
}
