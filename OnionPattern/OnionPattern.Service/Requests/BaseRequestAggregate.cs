using OnionPattern.Domain.Entities;
using OnionPattern.Domain.Repository;
using System;

namespace OnionPattern.Service.Requests
{
    public abstract class BaseRequestAggregate<TEntity> where TEntity : VideoGameEntity
    {
        protected IRepository<TEntity> Repository { get; }
        protected IRepositoryAggregate RepositoryAggregate { get; }

        protected BaseRequestAggregate(IRepository<TEntity> repository, IRepositoryAggregate repositoryAggregate)
        {
            Repository = repository ?? throw new ArgumentNullException($"{nameof(repository)} cannot be null.");
            RepositoryAggregate = repositoryAggregate ?? throw new ArgumentNullException($"{nameof(repositoryAggregate)} cannot be null.");
        }
    }
}
