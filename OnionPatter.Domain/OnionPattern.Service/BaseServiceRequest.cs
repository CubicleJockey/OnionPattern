using System;
using OnionPattern.Domain.Entities;
using OnionPattern.Domain.Repository;

namespace OnionPattern.Service
{
    public abstract class BaseServiceRequest<TEntity> where TEntity : VideoGameEntity
    {
        protected IRepository<TEntity> Repository { get; }
        protected IRepositoryAggregate RepositoryAggregate { get; }

        protected BaseServiceRequest(IRepository<TEntity> repository, IRepositoryAggregate repositoryAggregate)
        {
            Repository = repository ?? throw new ArgumentNullException($"{nameof(repository)} cannot be null.");
            RepositoryAggregate = repositoryAggregate ?? throw new ArgumentNullException($"{nameof(repositoryAggregate)} cannot be null.");
        }
    }
}
