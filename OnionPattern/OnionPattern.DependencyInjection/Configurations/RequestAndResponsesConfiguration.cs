using Microsoft.Extensions.DependencyInjection;
using OnionPattern.Domain.Entities;
using OnionPattern.Domain.Repository;
using OnionPattern.Domain.Services.Requests.Game;
using OnionPattern.Domain.Services.Requests.Game.Async;
using OnionPattern.Domain.Services.Requests.Platform;
using OnionPattern.Domain.Services.Requests.Platform.Async;
using OnionPattern.Service.Requests.Game;
using OnionPattern.Service.Requests.Game.Async;
using OnionPattern.Service.Requests.Platform;
using OnionPattern.Service.Requests.Platform.Async;
using System;
using OnionPattern.Domain.Game.Entities;
using OnionPattern.Domain.Platform.Entities;

namespace OnionPattern.DependencyInjection.Configurations
{
    public static class RequestAndResponsesConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            ConfigureGameRequestAggregates(services);
            ConfigurePlatformAggregate(services);
        }

        private static void ConfigureGameRequestAggregates(IServiceCollection services)
        {
            services.AddTransient<IGameRequestAggregate>(context =>
            {
                var dependencies = GetRequestDependencies<Game>(context);
                return new GameRequestAggregate(dependencies.Repository, dependencies.RepositoryAggregate);
            });

            services.AddTransient<IGameRequestAggregateAsync>(context =>
            {
                var dependencies = GetRequestAsyncDependencies<Game>(context);
                return new GameRequestAsyncAggregate(dependencies.Repository, dependencies.RepositoryAggregate);
            });
        }

        private static void ConfigurePlatformAggregate(IServiceCollection services)
        {
            #region Non-Async
            services.AddTransient<IPlatformRequestAggregate>(context =>
            {
                var dependencies = GetRequestDependencies<Platform>(context);
                return new PlatformRequestAggregate(dependencies.Repository, dependencies.RepositoryAggregate);
            });
            #endregion Non-Async

            #region Async
            services.AddTransient<IPlatformRequestAsyncAggregate>(context =>
            {
                var asyncDependencies = GetRequestAsyncDependencies<Platform>(context);
                return new PlatformRequestAsyncAggregate(asyncDependencies.Repository, asyncDependencies.RepositoryAggregate);
            });
            #endregion Async
        }

        #region Get Dependency Methods

        private static (IRepository<TEntity> Repository, IRepositoryAggregate RepositoryAggregate) GetRequestDependencies<TEntity>(IServiceProvider context) where TEntity : VideoGameEntity
        {
            var repository = context.GetService<IRepository<TEntity>>();
            var repositoryAggregate = context.GetService<IRepositoryAggregate>();

            return (repository, repositoryAggregate);
        }

        private static (IRepositoryAsync<TEntity> Repository, IRepositoryAsyncAggregate RepositoryAggregate) GetRequestAsyncDependencies<TEntity>(IServiceProvider context) where TEntity : VideoGameEntity
        {
            var repository = context.GetService<IRepositoryAsync<TEntity>>();
            var repositoryAggregate = context.GetService<IRepositoryAsyncAggregate>();

            return (repository, repositoryAggregate);
        }

        #endregion Get Dependency Methods
    }
}
