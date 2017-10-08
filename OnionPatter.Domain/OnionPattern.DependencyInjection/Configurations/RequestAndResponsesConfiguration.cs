using System;
using Microsoft.Extensions.DependencyInjection;
using OnionPattern.Domain.Entities;
using OnionPattern.Domain.Repository;
using OnionPattern.Domain.Services.Requests.Game;
using OnionPattern.Domain.Services.Requests.Platform;
using OnionPattern.Service.Requests.Game;
using OnionPattern.Service.Requests.Platform;

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
            services.AddTransient<IGetAllGamesRequest>(context =>
            {
                var repositories = GetRepositories<Game>(context);
                return new GetAllGamesRequest(repositories.Repository, repositories.RepositoryAggregate);
            });

            services.AddTransient<IGetAllGamesRequestAsync>(context =>
            {
                var repositories = GetAsyncRepositories<Game>(context);
                return new GetAllGamesRequestAsync(repositories.Repository, repositories.RepositoryAggregate);
            });

            services.AddTransient<IGetGameByIdRequest>(context =>
            {
                var repositories = GetRepositories<Game>(context);
                return new GetGameByIdRequest(repositories.Repository, repositories.RepositoryAggregate);
            });
        }

        private static void ConfigurePlatform(IServiceCollection services)
        {
            services.AddTransient<IGetAllPlatformsRequest>(context =>
            {
                var repositories = GetRepositories<Platform>(context);
                return new GetAllPlatformsRequest(repositories.Repository, repositories.RepositoryAggregate);
            });

            services.AddTransient<IGetAllPlatformsRequestAsync>(context =>
            {
                var repositories = GetAsyncRepositories<Platform>(context);
                return new GetAllPlatformsRequestAsync(repositories.Repository, repositories.RepositoryAggregate);
            });
        }

        private static (IRepository<TEntity> Repository, IRepositoryAggregate RepositoryAggregate) GetRepositories<TEntity>(IServiceProvider context) where TEntity : VideoGameEntity
        {
            var repository = context.GetService<IRepository<TEntity>>();
            var repositoryAggregate = context.GetService<IRepositoryAggregate>();

            return (repository, repositoryAggregate);
        }

        private static (IRepositoryAsync<TEntity> Repository, IRepositoryAsyncAggregate RepositoryAggregate) GetAsyncRepositories<TEntity>(IServiceProvider context) where TEntity : VideoGameEntity
        {
            var repository = context.GetService<IRepositoryAsync<TEntity>>();
            var repositoryAggregate = context.GetService<IRepositoryAsyncAggregate>();

            return (repository, repositoryAggregate);
        }
    }
}
