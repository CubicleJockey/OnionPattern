using OnionPattern.Domain.Entities;
using OnionPattern.Domain.Repository;
using System;
using Serilog;

namespace OnionPattern.Service
{
    public abstract class BaseServiceRequestAsync<TEntity> : ServiceHandleError where TEntity : VideoGameEntity
    {
        protected IRepositoryAsync<TEntity> Repository { get; }
        protected IRepositoryAsyncAggregate RepositoryAggregate { get; }
        protected ILogger Logger { get; }

        protected BaseServiceRequestAsync(IRepositoryAsync<TEntity> repository, IRepositoryAsyncAggregate repositoryAggregate, ILogger logger)
        {
            Repository = repository ?? throw new ArgumentNullException($"{nameof(repository)} cannot be null.");
            RepositoryAggregate = repositoryAggregate ?? throw new ArgumentNullException($"{nameof(repositoryAggregate)} cannot be null.");
            Logger = logger ?? throw new ArgumentNullException($"{nameof(logger)} cannot be null.");
        }
    }
}