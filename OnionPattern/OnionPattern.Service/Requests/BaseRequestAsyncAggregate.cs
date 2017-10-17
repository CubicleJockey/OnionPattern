using System;
using OnionPattern.Domain.Entities;
using OnionPattern.Domain.Repository;

namespace OnionPattern.Service.Requests
{
    public abstract class BaseRequestAsyncAggregate<TEntity> where TEntity : VideoGameEntity
    {
        protected IRepositoryAsync<TEntity> RepositoryAsync { get; }
        protected IRepositoryAsyncAggregate RepositoryAsyncAggregate { get; }

        protected BaseRequestAsyncAggregate(IRepositoryAsync<TEntity> repositoryAsync, IRepositoryAsyncAggregate repositoryAsyncAggregate)
        {
            RepositoryAsync = repositoryAsync ?? throw new ArgumentNullException($"{nameof(repositoryAsync)} cannot be null.");
            RepositoryAsyncAggregate = repositoryAsyncAggregate ?? throw new ArgumentNullException($"{nameof(repositoryAsyncAggregate)} cannot be null.");
        }
    }
}
