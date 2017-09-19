using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnionPattern.DataAccess.EF;
using OnionPattern.DataAccess.EF.Repository;
using OnionPattern.Domain.Entities;
using OnionPattern.Domain.Repository;
using OnionPattern.Domain.Services;
using OnionPattern.Service.Requests.Games;
using OnionPattern.Service.Requests.Platform;
using OnionPattern.Service.Responses;

namespace OnionPattern.DependencyInjection
{
    public static class Host
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            ConfigureRepositories(services, connectionString);
            ConfigureRequestAndResponses(services);
        }

        private static void ConfigureRepositories(IServiceCollection services, string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentException($"{nameof(connectionString)} cannot be empty.");
            }

            services.AddDbContext<VideoGameContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<DbContext>(provider => provider.GetService<VideoGameContext>());

            services.AddTransient<IRepository<Game>, Repository<Game>>(context =>
            {
                DbContext dbContext = context.GetService<VideoGameContext>();
                return new Repository<Game>(dbContext);
            });

            services.AddTransient<IRepository<Platform>, Repository<Platform>>(context =>
            {
                DbContext dbContext = context.GetService<VideoGameContext>();
                return new Repository<Platform>(dbContext);
            });

            services.AddTransient<IRepository<GamePlatform>, Repository<GamePlatform>>(context =>
            {
                DbContext dbContext = context.GetService<VideoGameContext>();
                return new Repository<GamePlatform>(dbContext);
            });
        }

        private static void ConfigureRequestAndResponses(IServiceCollection services)
        {
            services.AddTransient<IServiceRequest<Game, GetAllGamesResponse>>(context =>
            {
                var repositories = GetRepositories<Game>(context);

                return new GetAllGamesRequest(repositories.Repository, repositories.RepositoryAggregate);
            });

            services.AddTransient<IServiceRequest<Platform, GetAllPlatformsResponse>>(context =>
            {
                var repositories = GetRepositories<Platform>(context);
                return new GetAllPlatformsRequest(repositories.Repository, repositories.RepositoryAggregate);
            });
        }

        private static (IRepository<TEntity> Repository, IRepositoryAggregate RepositoryAggregate) GetRepositories<TEntity>(IServiceProvider context) where TEntity : VideoGameEntity
        {
            var repository = context.GetService<IRepository<TEntity>>();
            var repositoryAggregate = context.GetService<IRepositoryAggregate>();

            return (repository, repositoryAggregate);
        }

    }
}
