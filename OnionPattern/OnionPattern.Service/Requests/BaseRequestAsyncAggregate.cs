using System;
using OnionPattern.Domain;
using OnionPattern.Domain.Repository;

namespace OnionPattern.Service.Requests
{
    /// <summary>
    /// Each Request requires a Repository Async and A Repository Aggregate Async.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class BaseRequestAsyncAggregate<TEntity> where TEntity : VideoGameEntity
    {
        protected IRepositoryAsync<TEntity> RepositoryAsync { get; }
        protected IRepositoryAsyncAggregate RepositoryAsyncAggregate { get; }

        /// <exception cref="ArgumentNullException">Condition.</exception>
        protected BaseRequestAsyncAggregate(IRepositoryAsync<TEntity> repositoryAsync, IRepositoryAsyncAggregate repositoryAsyncAggregate)
        {
            RepositoryAsync = repositoryAsync ?? throw new ArgumentNullException($"{nameof(repositoryAsync)} cannot be null.");
            RepositoryAsyncAggregate = repositoryAsyncAggregate ?? throw new ArgumentNullException($"{nameof(repositoryAsyncAggregate)} cannot be null.");
        }
    }
}
