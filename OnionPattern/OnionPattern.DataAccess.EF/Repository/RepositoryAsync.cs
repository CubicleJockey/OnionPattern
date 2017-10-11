using OnionPattern.Domain.Entities;
using OnionPattern.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
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

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            try
            {
                dataSet.AsNoTracking();
                var data = await Task.FromResult(dataSet.Where(f => true));
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting records: {ex.Message}", ex);
            }
        }

        public async Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await dataSet.SingleAsync(expression);
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await dataSet.SingleOrDefaultAsync(expression);
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await Task.FromResult(dataSet.Where(expression));
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            var createdEntity = await dataSet.AddAsync(entity);
            await SaveChangesAsync();
            return createdEntity.Entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (!dataSet.Local.Contains(entity)) { dataSet.Attach(entity); }
            context.Entry(entity).State = EntityState.Modified;
            await SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            var deleteEntity = dataSet.Remove(entity);
            await SaveChangesAsync();
            return deleteEntity.Entity;
        }

        #endregion

        private async Task<int> SaveChangesAsync()
        {
            try
            {
                return await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception($"Concurrency Error: {ex.Message}", ex);
            }
            catch (DbUpdateException ex)
            {
                throw new Exception($"Database Update Error: {ex.Message}", ex);
            }
            catch (DbException ex)
            {
                throw new Exception($"Entity Validation Errors: {ex.Message}", ex);
            }
        }
    }
}
