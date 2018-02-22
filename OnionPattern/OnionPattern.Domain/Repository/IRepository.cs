using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace OnionPattern.Domain.Repository
{
    public interface IRepository<TEntity> where TEntity : VideoGameEntity
    {
        IEnumerable<TEntity> GetAll();
        TEntity Single(Expression<Func<TEntity, bool>> expression);
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> expression);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression);
        TEntity Create(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity Delete(TEntity entity);
    }
}

