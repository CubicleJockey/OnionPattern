using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using OnionPattern.Domain.Entities;

namespace OnionPattern.Domain.Repository
{
    public interface IRepository<TEntity> where TEntity : GameEntity
    {
        IEnumerable<TEntity> GetAll();
        TEntity Single(Expression<Func<TEntity, bool>> expression);
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> expression);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}

