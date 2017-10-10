using System;
using Microsoft.Extensions.DependencyInjection;
using OnionPattern.Domain.Entities;
using OnionPattern.Domain.Repository;
using OnionPattern.Domain.Services.Requests.Game;
using OnionPattern.Domain.Services.Requests.Platform;
using OnionPattern.Service.Requests.Game;
using OnionPattern.Service.Requests.Platform;
using Serilog;

namespace OnionPattern.DependencyInjection.Configurations
{
    public static class RequestAndResponsesConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            ConfigureGame(services);
            ConfigurePlatform(services);
        }

        private static void ConfigureGame(IServiceCollection services)
        {
            #region Non-Async
            services.AddTransient<IGetAllGamesRequest>(context =>
            {
                var dependencies = GetRequestDependencies<Game>(context);
                return new GetAllGamesRequest(dependencies.Repository, dependencies.RepositoryAggregate, dependencies.logger);
            });
            
            services.AddTransient<IGetGameByIdRequest>(context =>
            {
                var dependencies = GetRequestDependencies<Game>(context);
                return new GetGameByIdRequest(dependencies.Repository, dependencies.RepositoryAggregate, dependencies.logger);
            });
            
            services.AddTransient<IDeleteGameByIdRequest>(context =>
            {
                var dependencies = GetRequestDependencies<Game>(context);
                return new DeleteGameByIdRequest(dependencies.Repository, dependencies.RepositoryAggregate, dependencies.logger);
            });

            services.AddTransient<ICreateGameRequest>(context =>
            {
                var dependencies = GetRequestDependencies<Game>(context);
                return new CreateGameRequest(dependencies.Repository, dependencies.RepositoryAggregate, dependencies.logger);
            });
            #endregion Non-Async

            #region Async
            services.AddTransient<IGetGameByIdRequestAsync>(context =>
            {
                var asyncDependencies = GetAsyncDependencies<Game>(context);
                return new GetGameByIdRequestAsync(asyncDependencies.Repository, asyncDependencies.RepositoryAggregate, asyncDependencies.logger);
            });

            services.AddTransient<IGetAllGamesRequestAsync>(context =>
            {
                var asyncDependencies = GetAsyncDependencies<Game>(context);
                return new GetAllGamesRequestAsync(asyncDependencies.Repository, asyncDependencies.RepositoryAggregate, asyncDependencies.logger);
            });
            #endregion Async
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
                var asyncDependencies = GetAsyncDependencies<Platform>(context);
                return new GetAllPlatformsRequestAsync(asyncDependencies.Repository, asyncDependencies.RepositoryAggregate, asyncDependencies.logger);
            });
            #endregion Async
        }

        private static (IRepository<TEntity> Repository, IRepositoryAggregate RepositoryAggregate, ILogger logger) GetRequestDependencies<TEntity>(IServiceProvider context) where TEntity : VideoGameEntity
        {
            var repository = context.GetService<IRepository<TEntity>>();
            var repositoryAggregate = context.GetService<IRepositoryAggregate>();
            var logger = context.GetService<ILogger>();

            return (repository, repositoryAggregate, logger);
        }

        private static (IRepositoryAsync<TEntity> Repository, IRepositoryAsyncAggregate RepositoryAggregate, ILogger logger) GetAsyncDependencies<TEntity>(IServiceProvider context) where TEntity : VideoGameEntity
        {
            var repository = context.GetService<IRepositoryAsync<TEntity>>();
            var repositoryAggregate = context.GetService<IRepositoryAsyncAggregate>();
            var logger = context.GetService<ILogger>();

            return (repository, repositoryAggregate, logger);
        }
    }
}
