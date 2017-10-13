using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.DotNet.PlatformAbstractions;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace OnionPattern.Api.StartupConfigurations
{
    /// <summary>
    /// Swagger Startup Configuration
    /// </summary>
    public static class SwaggerStartupConfiguration
    {
        /// <summary>
        ///     Setup configuration for Swagger
        /// </summary>
        /// <param name="services"></param>
        /// <param name="hostingEnvironment"></param>
        public static void ConfigureService(IServiceCollection services, IHostingEnvironment hostingEnvironment)
        {
            var path = Path.Combine(ApplicationEnvironment.ApplicationBasePath, "OnionPattern.Api.xml");

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info
                {
                    Title = "Video Games Api (Onion Pattern)",
                    Description = "Example for Onion Pattern"
                });
                options.IncludeXmlComments(path);
                options.DescribeAllEnumsAsStrings();
            });
        }

        /// <summary>
        /// Configure the Swagger Endpoints and Middleware
        /// </summary>
        /// <param name="application"></param>
        public static void Configure(IApplicationBuilder application)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint
            application.UseSwagger();

            // Enable middleware to serve swagger-ui assets (HTML, JS, CSS etc.)
            application.UseSwaggerUI(config =>
            {
                config.SwaggerEndpoint("/swagger/v1/swagger.json", "Onion Pattern V1");
            });
        }
    }
}
