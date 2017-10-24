using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OnionPattern.Api.StartupConfigurations;
using OnionPattern.DataAccess.EF;
using OnionPattern.DependencyInjection;
using OnionPattern.DependencyInjection.Data;
using OnionPattern.Domain.Constants;

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
            // Add the versioned api explorer, which also adds IApiVersionDescriptionProvider service
            // Note: the specified format code will format the version as "'v'major[.minor][-status]"
            // Note: Requires package: Microsoft.AspNetCore.Mvc.Versioning.ApiExplorer
            services.AddMvcCore().AddVersionedApiExplorer(o => o.GroupNameFormat = "'v'VVV");

            // Add framework services.
            services.AddApiVersioning(apiVersioningOptions => { apiVersioningOptions.ReportApiVersions = true; });

            services.AddMvc();

            LoadAppSettings.IntoInjector(services, Configuration);

            DependencyInjectorHost.Configure(services);

            // Swagger
            SwaggerStartupConfiguration.ConfigureService(services, environment);
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="loggerFactory"></param>
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory, IApiVersionDescriptionProvider apiVersionDescriptionProvider)
        {
            loggerFactory.AddConsole(Configuration.GetSection(AppSettingsSections.Logging));
            loggerFactory.AddDebug();

            if (environment.IsEnvironment(EnvironmentTypes.Local))
            {
                app.UseDeveloperExceptionPage();

                app.UseStaticFiles();

               SwaggerStartupConfiguration.Configure(app, apiVersionDescriptionProvider);
            }

            
            if (EnvironmentVariables.GetInMemoryDbValue())
            {
                var context = app.ApplicationServices.GetService<VideoGameContext>();
                DependencyDataInjector.Inject(context);
            }
            app.UseMvc();
        }
    }
}
