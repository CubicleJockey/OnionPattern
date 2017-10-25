using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OnionPattern.DataAccess.EF;
using OnionPattern.DataAccess.EF.Repository;
using OnionPattern.Domain.Configurations;
using OnionPattern.Domain.Constants;
using OnionPattern.Domain.Entities;
using OnionPattern.Domain.Repository;

namespace OnionPattern.DependencyInjection.Configurations
{
    public static class RepositoriesConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var connectionStrings = serviceProvider.GetService<IOptions<ConnectionStringsConfiguration>>();

            services.AddDbContext<VideoGameContext>(options =>
            {
                if (EnvironmentVariables.GetInMemoryDbValue()) { options.UseInMemoryDatabase("Onion.Pattern"); }
                else { options.UseSqlServer(connectionStrings.Value.VideoGamesConnection); }
            });
            services.AddScoped<DbContext>(provider => provider.GetService<VideoGameContext>());

            ConfigureNonAsync(services);
            ConfigureAsync(services);
        }

        private static void ConfigureNonAsync(IServiceCollection services)
        {
            services.AddTransient<IRepository<Game>, Repository<Game>>(InitializeReposiotry<Game>());
            services.AddTransient<IRepository<Platform>, Repository<Platform>>(InitializeReposiotry<Platform>());
            services.AddTransient<IRepository<GamePlatform>, Repository<GamePlatform>>(InitializeReposiotry<GamePlatform>());
            services.AddTransient<IRepositoryAggregate, RepositoryAggregate>();
        }
        
        private static void ConfigureAsync(IServiceCollection services)
        {
            services.AddTransient<IRepositoryAsync<Game>, RepositoryAsync<Game>>(InitializeReposiotryAsync<Game>());
            services.AddTransient<IRepositoryAsync<Platform>, RepositoryAsync<Platform>>(InitializeReposiotryAsync<Platform>());
            services.AddTransient<IRepositoryAsync<GamePlatform>, RepositoryAsync<GamePlatform>>(InitializeReposiotryAsync<GamePlatform>());
            services.AddTransient<IRepositoryAsyncAggregate, RepositoryAsyncAggregate>();
        }

        private static Func<IServiceProvider, Repository<TEntity>> InitializeReposiotry<TEntity>() where TEntity : VideoGameEntity
        {
            return context =>
            {
                DbContext dbContext = context.GetService<VideoGameContext>();
                return new Repository<TEntity>(dbContext);
            };
        }

        private static Func<IServiceProvider, RepositoryAsync<TEntity>> InitializeReposiotryAsync<TEntity>() where TEntity : VideoGameEntity
        {
            return context =>
            {
                DbContext dbContext = context.GetService<VideoGameContext>();
                return new RepositoryAsync<TEntity>(dbContext);
            };
        }
    }
}
