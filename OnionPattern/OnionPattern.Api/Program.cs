using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OnionPattern.Domain.Constants;
using System.IO;
using System.Net;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Compact;

namespace OnionPattern.Api
{
    /// <summary>
    /// Program DependencyInjectorHost
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main entry into the program.
        /// </summary>
        /// <param name="args"></param>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
        /// <exception cref="NotSupportedException">The operating system is Windows CE, which does not have current directory functionality.   This method is available in the .NET Compact Framework, but is not currently supported.</exception>
        public static void Main(string[] args)
        {
            //get the environment and appsettings
            BuildWebHost(args).Run();
        }

        /// <summary>
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
        /// <exception cref="NotSupportedException">The operating system is Windows CE, which does not have current directory functionality.   This method is available in the .NET Compact Framework, but is not currently supported.</exception>
        public static IWebHost BuildWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(AppConfiguration)
                .UseKestrel(ConfigureKestrel)
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureLogging(ConfigureLogging)
                .UseStartup<Startup>()
                .Build();
        }

        #region Program Configurations

        private static Action<WebHostBuilderContext, IConfigurationBuilder> AppConfiguration =>
            (hostingContext, config) =>
            {
                var env = hostingContext.HostingEnvironment;
                config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
                config.AddEnvironmentVariables();
            };

        private static Action<KestrelServerOptions> ConfigureKestrel =>
            options =>
            {
                options.Listen(IPAddress.Loopback, 52532, listenOptions =>
                {
                    listenOptions.NoDelay = true;
                });
            };

        private static Action<WebHostBuilderContext, ILoggingBuilder> ConfigureLogging =>
            (hostingContext, logging) =>
            {
                var loggerConfig = new LoggerConfiguration();

                loggerConfig
                    .MinimumLevel.Verbose()
                    .MinimumLevel.Override(nameof(Microsoft), LogEventLevel.Verbose)
                    .WriteTo.ColoredConsole()
                    .Enrich.FromLogContext()
                    .Enrich.WithProperty("Application", "OnionPattern.Api")
                    .WriteTo.RollingFile(new CompactJsonFormatter(), "logs/onionpattern-api.log");

                //Enable Seq [Non-Production uses get a Single User License]
                loggerConfig.WriteTo.Seq("http://localhost:5341");

                logging.AddConfiguration(hostingContext.Configuration.GetSection(AppSettingsSections.Logging));
                logging.AddConsole();
                logging.AddDebug();
            };

        #endregion Program Configurations
    }
}
