using OnionPattern.Domain.Entities;
using OnionPattern.Domain.Repository;
using System;

namespace OnionPattern.Service
{
    public abstract class BaseServiceRequestAsync<TEntity> : ServiceHandleError where TEntity : VideoGameEntity
    {
        protected IRepositoryAsync<TEntity> Repository { get; }
        protected IRepositoryAsyncAggregate RepositoryAggregate { get; }

        protected BaseServiceRequestAsync(IRepositoryAsync<TEntity> repository, IRepositoryAsyncAggregate repositoryAggregate)
        {
            Repository = repository ?? throw new ArgumentNullException($"{nameof(repository)} cannot be null.");
            RepositoryAggregate = repositoryAggregate ?? throw new ArgumentNullException($"{nameof(repositoryAggregate)} cannot be null.");
        }
    }
}