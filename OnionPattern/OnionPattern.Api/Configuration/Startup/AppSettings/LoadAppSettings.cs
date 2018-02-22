using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnionPattern.Domain.Configurations;
using OnionPattern.Domain.Constants;

namespace OnionPattern.Api.Configuration.Startup.AppSettings
{
    /// <summary>
    /// Loads the Appsettings file configurations into the dependency injector.
    /// </summary>
    public static class LoadAppSettings
    {
        /// <summary>
        /// Load configuration into the injector.
        /// </summary>
        /// <param name="services">Injector service</param>
        /// <param name="configuration">Configurations object.</param>
        public static void IntoInjector(IServiceCollection services, IConfigurationRoot configuration)
        {
            //Inject configuration setting. 
            services.Configure<ConnectionStringsConfiguration>(configuration.GetSection(AppSettingsSections.ConnectionStrings));
            services.Configure<LogLocationConfiguration>(configuration.GetSection(AppSettingsSections.LogLocations));
        }
    }
}
