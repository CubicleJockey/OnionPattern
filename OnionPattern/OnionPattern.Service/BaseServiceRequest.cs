using OnionPattern.Domain.Repository;
using System;
using OnionPattern.Domain;

namespace OnionPattern.Service
{
    /// <summary>
    ///  Each service request requires a Repository and Repository Aggregate.
    /// </summary>
    /// <typeparam name="TEntity">Type of Repositories to conenct to.</typeparam>
    public abstract class BaseServiceRequest<TEntity>: ServiceHandleError where TEntity : VideoGameEntity
    {
        protected IRepository<TEntity> Repository { get; }
        protected IRepositoryAggregate RepositoryAggregate { get; }

        /// <exception cref="ArgumentNullException">Condition.</exception>
        protected BaseServiceRequest(IRepository<TEntity> repository, IRepositoryAggregate repositoryAggregate)
        {
            Repository = repository ?? throw new ArgumentNullException($"{nameof(repository)} cannot be null.");
            RepositoryAggregate = repositoryAggregate ?? throw new ArgumentNullException($"{nameof(repositoryAggregate)} cannot be null.");
        }
    }
}
