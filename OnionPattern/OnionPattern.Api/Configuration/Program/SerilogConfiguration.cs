using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OnionPattern.Domain.Constants;
using Serilog;
using Serilog.Events;

namespace OnionPattern.Api.Configuration.Program
{
    /// <summary>
    /// Configurations for Serilog
    /// </summary>
    public class SerilogConfiguration
    {
        /// <summary>
        /// Setup Serilog
        /// Minimum Level: Verbose
        /// Minimum Level Override: Microsoft Verbose
        /// Enrich: FromLogContext
        /// File: Rolling
        /// </summary>
        /// <param name="hostingEnvironment">Hosting Environment Information</param>
        /// <param name="configuration">Configuration Information</param>
        /// <param name="logging">Logging Information</param>
        /// <param name="applicationName">Name of Application. I.E: Sentinel.Web, Sentinel.Registration.Api</param>
        /// <exception cref="ArgumentNullException"><paramref name="hostingEnvironment"/> is <see langword="null"/></exception>
        /// <exception cref="ArgumentException">Condition.</exception>
        public static void Configure(IHostingEnvironment hostingEnvironment,
                                     IConfiguration configuration,
                                     ILoggingBuilder logging,
                                     string applicationName)
        {
            if (hostingEnvironment == null) { throw new ArgumentNullException(nameof(hostingEnvironment)); }
            if (configuration == null) { throw new ArgumentNullException(nameof(configuration)); }
            if (logging == null) { throw new ArgumentNullException(nameof(logging)); }
            if (string.IsNullOrWhiteSpace(applicationName)) { throw new ArgumentException($"{nameof(applicationName)} cannot be empty."); }

            var logDirectory = hostingEnvironment.IsEnvironment(EnvironmentTypes.Local)
                ? $"log/onion-{applicationName}.log" //local debug (windows)
                : $"/var/log/app/onion-{applicationName}.log"; // Docker

            var loggerConfig = new LoggerConfiguration();

            loggerConfig
                .MinimumLevel.Debug()
                .MinimumLevel.Override(nameof(Microsoft), LogEventLevel.Information)
                .MinimumLevel.Override(nameof(System), LogEventLevel.Information)
                .Enrich.FromLogContext()
                .Enrich.WithProperty("Application", applicationName)
                .WriteTo.File(
                    logDirectory,
                    rollingInterval: RollingInterval.Day,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{u3}] {Message:lj} {Properties}{NewLine}{Exception}");

            //only add Seq for local file reading.
            //see: https://docs.getseq.net/v4/docs/using-serilog
            //for loading Seq locally see: https://docs.getseq.net/v4/docs/getting-started
            if (hostingEnvironment.IsEnvironment(EnvironmentTypes.Local))
            {
                loggerConfig.WriteTo.Console();
                loggerConfig.WriteTo.Seq("http://localhost:5341");
            }

            //Set Serilog
            Log.Logger = loggerConfig.CreateLogger();

            Log.Information("Updating Logging");

            logging
                .AddConfiguration(configuration.GetSection(AppSettingsSections.Logging))
                .AddConsole()
                .AddEventSourceLogger()
                .AddDebug();
        }
    }
}
