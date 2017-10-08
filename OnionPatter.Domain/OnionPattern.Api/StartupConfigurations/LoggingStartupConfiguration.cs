using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Serilog;
using OnionPattern.Api.AppConstants;
using OnionPattern.Domain.AppConfigurations;

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

            var directoryCheck = (new FileInfo(logLocations.FileName)).Directory;
            directoryCheck.Refresh();
            if(!directoryCheck.Exists) { directoryCheck.Create(); }

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.RollingFile(logLocations.FileName)
                .CreateLogger();
        }
    }
}
