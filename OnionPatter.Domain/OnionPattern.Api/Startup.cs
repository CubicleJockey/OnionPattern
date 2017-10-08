using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OnionPattern.Api.AppConstants;
using OnionPattern.Api.StartupConfigurations;
using OnionPattern.DependencyInjection;
using OnionPattern.Domain.AppConfigurations;
using Serilog;

namespace OnionPattern.Api
{
    /// <summary>
    /// Application Startup Configuration
    /// </summary>
    public class Startup
    {
        private readonly IHostingEnvironment environment;

        /// <summary>
        /// Configuration Root
        /// </summary>
        public IConfigurationRoot Configuration { get; }

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="env">Hosting Environment</param>
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

            environment = env;
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            //Inject configuration setting. 
            services.Configure<ConnectionStringsConfiguration>(Configuration.GetSection(AppSettingsSections.ConnectionStrings));

            Host.Configure(services);

            // Swagger
            SwaggerStartupConfiguration.Create(services, environment);
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="loggerFactory"></param>
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection(AppSettingsSections.Logging));
            loggerFactory.AddDebug();
            loggerFactory.AddSerilog();

            if (environment.IsEnvironment(EnvironmentTypes.Local))
            {
                app.UseDeveloperExceptionPage();

                app.UseStaticFiles();

                // Enable middleware to serve generated Swagger as a JSON endpoint
                app.UseSwagger();

                // Enable middleware to serve swagger-ui assets (HTML, JS, CSS etc.)
                app.UseSwaggerUI(config =>
                {
                    config.SwaggerEndpoint("/swagger/v1/swagger.json", "Onion Pattern V1");
                });
            }

            app.UseMvc();
        }
    }
}
