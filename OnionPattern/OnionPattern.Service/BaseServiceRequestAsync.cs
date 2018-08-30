﻿using OnionPattern.Domain;
using OnionPattern.Domain.Repository;
using System;

namespace OnionPattern.Service
{
    /// <summary>
    ///  Each service request requires a Repository Async and Repository Aggregate Async.
    /// </summary>
    /// <typeparam name="TEntity">Type of Repositories to conenct to.</typeparam>
    public abstract class BaseServiceRequestAsync<TEntity> : ServiceHandleError where TEntity : VideoGameEntity
    {
        protected IRepositoryAsync<TEntity> Repository { get; }
        protected IRepositoryAsyncAggregate RepositoryAggregate { get; }

        /// <exception cref="ArgumentNullException">Condition.</exception>
        protected BaseServiceRequestAsync(IRepositoryAsync<TEntity> repository, IRepositoryAsyncAggregate repositoryAggregate)
        {
            Repository = repository ?? throw new ArgumentNullException(nameof(repository));
            RepositoryAggregate = repositoryAggregate ?? throw new ArgumentNullException(nameof(repositoryAggregate));
        }
    }
}