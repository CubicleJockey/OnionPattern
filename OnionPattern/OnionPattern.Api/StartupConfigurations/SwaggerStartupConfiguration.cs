using System.IO;
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
        public static void Create(IServiceCollection services, IHostingEnvironment hostingEnvironment)
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
    }
}
