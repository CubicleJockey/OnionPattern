using Microsoft.Extensions.DependencyInjection;

namespace OnionPattern.Api.Configuration.Startup.Cors
{
    /// <summary>
    /// CORS Configurations
    /// </summary>
    public static class CorsStartupConfiguration
    {
        /// <summary>
        /// Configure CORS services.
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllHeaders", builder =>
                {
                    builder.AllowAnyHeader();
                    builder.AllowAnyOrigin();
                    builder.AllowAnyMethod();
                    builder.AllowCredentials();
                    builder.Build();
                });
            });
        }
    }
}
