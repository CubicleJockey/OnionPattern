using System;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnionPattern.DataAccess.EF;
using OnionPattern.DataAccess.EF.Repository;
using OnionPattern.Domain.Entities;
using OnionPattern.Domain.Repository;
using OnionPattern.Service.RequestHandlers.Platform;

namespace OnionPattern.DependencyInjection
{
    public static class Host
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString)) { throw new ArgumentException($"{nameof(connectionString)} cannot be empty."); }

            services.AddDbContext<VideoVideoGameContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IDbContext>(provider => provider.GetService<VideoVideoGameContext>());

            services.AddTransient<IRepository<Game>, Repository<Game>>(context =>
            {
                IDbContext dbContext = context.GetService<VideoVideoGameContext>();
                return new Repository<Game>(dbContext);
            });

            services.AddMediatR(typeof(GetAllPlatformRequestHandlerAsync));
        }
    }
}
