using Microsoft.Extensions.DependencyInjection;
using OnionPattern.Domain.Entities;
using OnionPattern.Domain.Repository;
using OnionPattern.Domain.Services.Requests.Game;
using OnionPattern.Domain.Services.Requests.Platform;
using OnionPattern.Domain.Services.Requests.Platform.Async;
using OnionPattern.Service.Requests.Game;
using OnionPattern.Service.Requests.Platform;
using OnionPattern.Service.Requests.Platform.Async;
using Serilog;
using System;
using OnionPattern.Domain.Services.Requests.Game.Async;
using OnionPattern.Service.Requests.Game.Async;

namespace OnionPattern.DependencyInjection.Configurations
{
    public static class RequestAndResponsesConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            ConfigureGameRequestAggregates(services);
            ConfigurePlatform(services);
        }

        private static void ConfigureGameRequestAggregates(IServiceCollection services)
        {
            services.AddTransient<IGameRequestAggregate>(context =>
            {
                var dependencies = GetRequestDependencies<Game>(context);
                return new GameRequestAggregate(dependencies.Repository, dependencies.RepositoryAggregate, dependencies.logger);
            });

            services.AddTransient<IGameRequestAggregateAsync>(context =>
            {
                var dependencies = GetRequestAsyncDependencies<Game>(context);
                return new GameRequestAggregateAsync(dependencies.Repository, dependencies.RepositoryAggregate, dependencies.logger);
            });
        }

        private static void ConfigurePlatform(IServiceCollection services)
        {
            #region Non-Async
            services.AddTransient<IGetAllPlatformsRequest>(context =>
            {
                var dependencies = GetRequestDependencies<Platform>(context);
                return new GetAllPlatformsRequest(dependencies.Repository, dependencies.RepositoryAggregate, dependencies.logger);
            });
            #endregion Non-Async

            #region Async
            services.AddTransient<IGetAllPlatformsRequestAsync>(context =>
            {
                var asyncDependencies = GetRequestAsyncDependencies<Platform>(context);
                return new GetAllPlatformsRequestAsync(asyncDependencies.Repository, asyncDependencies.RepositoryAggregate, asyncDependencies.logger);
            });
            #endregion Async
        }

        #region Get Dependency Methods

        private static (IRepository<TEntity> Repository, IRepositoryAggregate RepositoryAggregate, ILogger logger) GetRequestDependencies<TEntity>(IServiceProvider context) where TEntity : VideoGameEntity
        {
            var repository = context.GetService<IRepository<TEntity>>();
            var repositoryAggregate = context.GetService<IRepositoryAggregate>();
            var logger = context.GetService<ILogger>();

            return (repository, repositoryAggregate, logger);
        }

        private static (IRepositoryAsync<TEntity> Repository, IRepositoryAsyncAggregate RepositoryAggregate, ILogger logger) GetRequestAsyncDependencies<TEntity>(IServiceProvider context) where TEntity : VideoGameEntity
        {
            var repository = context.GetService<IRepositoryAsync<TEntity>>();
            var repositoryAggregate = context.GetService<IRepositoryAsyncAggregate>();
            var logger = context.GetService<ILogger>();

            return (repository, repositoryAggregate, logger);
        }

        #endregion Get Dependency Methods
    }
}
