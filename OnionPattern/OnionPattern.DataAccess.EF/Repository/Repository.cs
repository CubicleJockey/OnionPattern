using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using OnionPattern.Domain;
using OnionPattern.Domain.Repository;

namespace OnionPattern.DataAccess.EF.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : VideoGameEntity
    {
        private readonly DbContext context;
        private readonly DbSet<TEntity> dataSet;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="context"></param>
        public Repository(DbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            dataSet = context.Set<TEntity>();
        }

        #region Queries

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression)
        {
            return dataSet.Where(expression);
        }

        public TEntity Single(Expression<Func<TEntity, bool>> expression)
        {
            return dataSet.Single(expression);
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> expression)
        {
            return dataSet.SingleOrDefault(expression);
        }

        #endregion Queries

        #region Gets

        public IEnumerable<TEntity> GetAll()
        {
            try
            {
                dataSet.AsNoTracking();
                var data = dataSet.Where(f => true);
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting records: {ex.Message}", ex);
            }
        }

        #endregion Gets

        public TEntity Create(TEntity entity)
        {
            var savedEntity = dataSet.Add(entity);
            SaveChanges();
            return savedEntity.Entity;
        }

        public TEntity Delete(TEntity entity)
        {
            var deletedEntity = dataSet.Remove(entity);
            SaveChanges();
            return deletedEntity.Entity;
        }

        public TEntity Update(TEntity entity)
        {
            if (!dataSet.Local.Contains(entity)) { dataSet.Attach(entity); }
            context.Entry(entity).State = EntityState.Modified;
            SaveChanges();
            return entity;
        }

        private int SaveChanges()
        {
            try
            {
                return context.SaveChanges();
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
