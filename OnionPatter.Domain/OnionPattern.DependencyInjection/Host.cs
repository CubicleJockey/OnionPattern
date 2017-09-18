using System;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnionPattern.DataAccess.EF;
using OnionPattern.DataAccess.EF.Repository;
using OnionPattern.Domain.Repository;

namespace OnionPattern.DependencyInjection
{
    public static class Host
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString)) { throw new ArgumentException($"{nameof(connectionString)} cannot be empty."); }

            services.AddDbContext<GameContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IDbContext>(provider => provider.GetService<GameContext>());

            //services.AddTransient<IRepository<Agency>, Repository<Agency>>(context =>
            //{
            //    IDbContext dbContext = context.GetService<AccountContext>();
            //    return new Repository<Agency>(dbContext);
            //});

            //services.AddMediatR(typeof(ProfileRequestHandlerAsync));
        }
    }
}
