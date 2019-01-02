using Microsoft.Extensions.DependencyInjection;

namespace OnionPattern.Api.Configuration.Startup.ApiVersioning
{
    /// <summary>
    /// Api Versioning Configurations
    /// </summary>
    public static class ApiVersioningConfiguration
    {
        /// <summary>
        /// Turn on and configuration the Api MVC Versioning with the services.
        /// 
        /// Api Explorer is turned on so that Swagger can understand the versioning routing.
        /// </summary>
        /// <param name="services">Services Collection</param>
        public static void ConfigureService(IServiceCollection services)
        {
            // Add the versioned api explorer, which also adds IApiVersionDescriptionProvider service
            // Note: the specified format code will format the version as "'v'major[.minor][-status]"
            // Note: Requires package: Microsoft.AspNetCore.Mvc.Versioning.ApiExplorer
            services.AddMvcCore();
            services.AddVersionedApiExplorer(o => o.GroupNameFormat = "'v'VVV");

            // Add framework services.
            services.AddApiVersioning(apiVersioningOptions => { apiVersioningOptions.ReportApiVersions = true; });
        }
    }
}
