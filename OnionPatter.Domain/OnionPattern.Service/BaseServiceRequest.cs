using System;
using System.Threading.Tasks;
using OnionPattern.Domain.Entities;
using OnionPattern.Domain.Repository;
using OnionPattern.Domain.Services;

namespace OnionPattern.Service
{
    public abstract class BaseServiceRequest<TEntity, TResponse> : IServiceRequest<TEntity, TResponse> where TEntity : VideoGameEntity
    {
        protected IRepository<TEntity> Repository { get; }
        protected IRepositoryAggregate RepositoryAggregate { get; }

        protected BaseServiceRequest(IRepository<TEntity> repository, IRepositoryAggregate repositoryAggregate)
        {
            Repository = repository ?? throw new ArgumentNullException($"{nameof(repository)} cannot be null.");
            RepositoryAggregate = repositoryAggregate ?? throw new ArgumentNullException($"{nameof(repositoryAggregate)} cannot be null.");
        }

        public abstract Task<TResponse> Execute();
    }
}
