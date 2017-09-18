using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Serilog;
using OnionPattern.Api.AppConfigurations;
using OnionPattern.Api.AppConstants;

namespace OnionPattern.Api.StartupConfigurations
{
    /// <summary>
    /// Logging Startup Configuration Settings
    /// </summary>
    public static class LoggingStartupConfiguration
    {
        /// <summary>
        /// Sets up the logging.
        /// </summary>
        /// <param name="webHostBuilderContext"></param>
        public static void Create(WebHostBuilderContext webHostBuilderContext)
        {
            var logLocations = webHostBuilderContext
                .Configuration
                .GetSection(AppSettingsSections.LogLocations)
                .Get<LogLocationsConfiguration>();

            //Setup Serilog
            var logDirectory = webHostBuilderContext.HostingEnvironment.EnvironmentName == EnvironmentTypes.Local
                ? logLocations.Local
                : null;

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.RollingFile(logDirectory)
                .CreateLogger();
        }
    }
}
