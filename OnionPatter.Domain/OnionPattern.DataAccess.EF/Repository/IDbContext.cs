using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace OnionPattern.DataAccess.EF.Repository
{
    public interface IDbContext
    {
        /// <summary>
        /// Gets a DbSet for a given entity.
        /// </summary>
        /// <typeparam name="TEntity">Name of Entity</typeparam>
        /// <returns>DbSet of Entity</returns>
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        /// <summary>
        /// Gets the EntityEntry generic for TEntity
        /// </summary>
        /// <typeparam name="TEntity">Name of Entity</typeparam>
        /// <param name="entity">Strong Typed Entity</param>
        /// <returns></returns>
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        /// <summary>
        /// Saves the Modifications to an Entity
        /// </summary>
        /// <returns>Number of Rows Affected.</returns>
        int SaveChanges();
    }
}