using System;
using OnionPattern.Domain.Entities;
using OnionPattern.Domain.Repository;

namespace OnionPattern.Service.Requests
{
    public abstract class BaseRequest<TEntity, TResponse> where TEntity : VideoGameEntity
    {
        protected IRepository<TEntity> Repository;

        protected BaseRequest(IRepository<TEntity> repository)
        {
            Repository = repository ?? throw new ArgumentNullException($"{nameof(repository)} cannot be null.");
        }

        public abstract TResponse Execute();
    }
}
