using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OnionPattern.DataAccess.EF;
using OnionPattern.DataAccess.EF.Repository;
using OnionPattern.Domain.AppConfigurations;
using OnionPattern.Domain.Entities;
using OnionPattern.Domain.Repository;
using OnionPattern.Domain.Services.Requests.Game;
using OnionPattern.Domain.Services.Requests.Platform;
using OnionPattern.Service.Requests.Game;
using OnionPattern.Service.Requests.Platform;
using System;

namespace OnionPattern.DependencyInjection
{
    public static class Host
    {
        public static void Configure(IServiceCollection services)
        {
            ConfigureRepositories(services);
            ConfigureRequestAndResponses(services);
        }

        private static void ConfigureRepositories(IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var connectionStrings = serviceProvider.GetService<IOptions<ConnectionStringsConfiguration>>();

            services.AddDbContext<VideoGameContext>(options => options.UseSqlServer(connectionStrings.Value.VideoGamesConnection));
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
