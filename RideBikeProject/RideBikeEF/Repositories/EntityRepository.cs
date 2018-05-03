using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;
using RideBikeProjectDAL.Interfaces;

namespace RideBikeProjectDAL.Repositories
{
    public class EntityRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;
        protected readonly IDbSet<TEntity> _dbSet;

        public EntityRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public void Create(TEntity entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public List<TEntity> Get()
        {
            return _dbSet.ToList();
        }

        public List<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }

        public List<TEntity> Paging(Func<TEntity, string> predicate, string order, int skip, int take)
        {
            if(order.ToUpper().Equals("DESC"))
                return _dbSet.OrderByDescending(predicate).Skip(skip).Take(take).ToList();
            else
                return _dbSet.OrderBy(predicate).Skip(skip).Take(take).ToList();
        }

        public int Count()
        {
            return _dbSet.Count();
        }

        public int Count(Func<TEntity, bool> predicate)
        {
            return _dbSet.Where(predicate).Count();
        }

        public TEntity Find(long id)
        {
            return _dbSet.Find(id);
        }

        public void Remove(long id)
        {
            TEntity entity = Find(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                _context.SaveChanges();
            }
        }

        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }


    }
}
