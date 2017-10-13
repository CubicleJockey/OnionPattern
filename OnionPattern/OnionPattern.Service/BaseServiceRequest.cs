using System;
using OnionPattern.Domain.Entities;
using OnionPattern.Domain.Errors;
using OnionPattern.Domain.Repository;
using Serilog;

namespace OnionPattern.Service
{
    public abstract class BaseServiceRequest<TEntity>: ServiceHandleError where TEntity : VideoGameEntity
    {
        protected IRepository<TEntity> Repository { get; }
        protected IRepositoryAggregate RepositoryAggregate { get; }
        protected ILogger Logger { get; }

        protected BaseServiceRequest(IRepository<TEntity> repository, IRepositoryAggregate repositoryAggregate, ILogger logger)
        {
            Repository = repository ?? throw new ArgumentNullException($"{nameof(repository)} cannot be null.");
            RepositoryAggregate = repositoryAggregate ?? throw new ArgumentNullException($"{nameof(repositoryAggregate)} cannot be null.");
            Logger = logger ?? throw new ArgumentNullException($"{nameof(logger)} cannot be null.");
        }
    }
}
