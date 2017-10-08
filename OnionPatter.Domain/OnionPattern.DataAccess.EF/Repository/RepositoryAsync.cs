using OnionPattern.Domain.Entities;
using OnionPattern.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OnionPattern.DataAccess.EF.Repository
{
    public class RepositoryAsync<TEntity> : IRepositoryAsync<TEntity> where TEntity : VideoGameEntity
    {
        private readonly DbContext context;
        private readonly DbSet<TEntity> dataSet;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="context"></param>
        public RepositoryAsync(DbContext context)
        {
            this.context = context ?? throw new ArgumentNullException($"{nameof(context)} cannot be null.");
            dataSet = context.Set<TEntity>();
        }

        #region Implementation of IRepositoryAsync<TEntity>

        public Task<IEnumerable<TEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> CreateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
