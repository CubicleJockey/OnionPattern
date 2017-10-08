using OnionPattern.Domain.Entities;
using OnionPattern.Domain.Repository;
using System;

namespace OnionPattern.Service
{
    public abstract class BaseServiceRequestAsync<TEntity> : ServiceHandleError where TEntity : VideoGameEntity
    {
        protected IRepositoryAsync<TEntity> RepositoryAsync { get; }
        protected IRepositoryAsyncAggregate RepositoryAggregateAsync { get; }

        protected BaseServiceRequestAsync(IRepositoryAsync<TEntity> repository, IRepositoryAsyncAggregate repositoryAggregate)
        {
            RepositoryAsync = repository ?? throw new ArgumentNullException($"{nameof(repository)} cannot be null.");
            RepositoryAggregateAsync = repositoryAggregate ?? throw new ArgumentNullException($"{nameof(repositoryAggregate)} cannot be null.");
        }
    }
}