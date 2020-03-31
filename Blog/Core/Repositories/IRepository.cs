using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Blog.Core.Repositories
{
    public interface IRepository<TEntity,T> where TEntity : class
    {
        TEntity Get(T id);
        IEnumerable<TEntity> GetAll();

        void Add(TEntity entity);
        void AddAll(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveAll(IEnumerable<TEntity> entities);

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        int Count();
    }
}
