using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OnionPattern.DataAccess.EF;
using OnionPattern.DataAccess.EF.Repository;
using OnionPattern.Domain.AppConfigurations;
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

            services.AddDbContext<VideoGameContext>(options => options.UseSqlServer(connectionStrings.Value.VideoGamesConnection));
            services.AddScoped<DbContext>(provider => provider.GetService<VideoGameContext>());

            ConfigureNonAsync(services);
            ConfigureAsync(services);
        }

        private static void ConfigureNonAsync(IServiceCollection services)
        {
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

        private static void ConfigureAsync(IServiceCollection services)
        {
            services.AddTransient<IRepositoryAsync<Game>, RepositoryAsync<Game>>(context =>
            {
                DbContext dbContext = context.GetService<VideoGameContext>();
                return new RepositoryAsync<Game>(dbContext);
            });

            services.AddTransient<IRepositoryAsync<Platform>, RepositoryAsync<Platform>>(context =>
            {
                DbContext dbContext = context.GetService<VideoGameContext>();
                return new RepositoryAsync<Platform>(dbContext);
            });

            services.AddTransient<IRepositoryAsync<GamePlatform>, RepositoryAsync<GamePlatform>>(context =>
            {
                DbContext dbContext = context.GetService<VideoGameContext>();
                return new RepositoryAsync<GamePlatform>(dbContext);
            });
        }
    }
}
