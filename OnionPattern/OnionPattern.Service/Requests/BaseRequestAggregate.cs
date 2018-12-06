using OnionPattern.Domain;
using OnionPattern.Domain.Repository;
using System;

namespace OnionPattern.Service.Requests
{
    /// <summary>
    /// Each Request requires a Repository and A Repository Aggregate.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class BaseRequestAggregate<TEntity> where TEntity : VideoGameEntity
    {
        protected IRepository<TEntity> Repository { get; }
        protected IRepositoryAggregate RepositoryAggregate { get; }

        /// <exception cref="ArgumentNullException">Condition.</exception>
        protected BaseRequestAggregate(IRepository<TEntity> repository, IRepositoryAggregate repositoryAggregate)
        {
            Repository = repository ?? throw new ArgumentNullException(nameof(repository));
            RepositoryAggregate = repositoryAggregate ?? throw new ArgumentNullException(nameof(repositoryAggregate));
        }
    }
}
