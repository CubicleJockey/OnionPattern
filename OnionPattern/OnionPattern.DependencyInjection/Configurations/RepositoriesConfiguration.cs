using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OnionPattern.DataAccess.EF;
using OnionPattern.DataAccess.EF.Repository;
using OnionPattern.Domain;
using OnionPattern.Domain.Configurations;
using OnionPattern.Domain.Constants;
using OnionPattern.Domain.Game.Entities;
using OnionPattern.Domain.GamePlatform.Entities;
using OnionPattern.Domain.Platform.Entities;
using OnionPattern.Domain.Repository;
using System;

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
            services.AddTransient<IRepository<Game>, Repository<Game>>(InitializeRepository<Game>());
            services.AddTransient<IRepository<Platform>, Repository<Platform>>(InitializeRepository<Platform>());
            services.AddTransient<IRepository<GamePlatform>, Repository<GamePlatform>>(InitializeRepository<GamePlatform>());
            services.AddTransient<IRepositoryAggregate, RepositoryAggregate>();
        }

        private static void ConfigureAsync(IServiceCollection services)
        {
            services.AddTransient<IRepositoryAsync<Game>, RepositoryAsync<Game>>(InitializeRepositoryAsync<Game>());
            services.AddTransient<IRepositoryAsync<Platform>, RepositoryAsync<Platform>>(InitializeRepositoryAsync<Platform>());
            services.AddTransient<IRepositoryAsync<GamePlatform>, RepositoryAsync<GamePlatform>>(InitializeRepositoryAsync<GamePlatform>());
            services.AddTransient<IRepositoryAsyncAggregate, RepositoryAsyncAggregate>();
        }

        private static Func<IServiceProvider, Repository<TEntity>> InitializeRepository<TEntity>() where TEntity : VideoGameEntity
        {
            return context =>
            {
                DbContext dbContext = context.GetService<VideoGameContext>();
                return new Repository<TEntity>(dbContext);
            };
        }

        private static Func<IServiceProvider, RepositoryAsync<TEntity>> InitializeRepositoryAsync<TEntity>() where TEntity : VideoGameEntity
        {
            return context =>
            {
                DbContext dbContext = context.GetService<VideoGameContext>();
                return new RepositoryAsync<TEntity>(dbContext);
            };
        }
    }
}
