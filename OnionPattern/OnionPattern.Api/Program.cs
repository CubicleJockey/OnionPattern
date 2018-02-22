using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OnionPattern.Api.Configuration.Program;
using System;
using System.IO;

namespace OnionPattern.Api
{
    /// <summary>
    /// Program DependencyInjectorHost
    /// </summary>
    public class Program
    {
        private static WebHostBuilderContext webHostBuilderContext;

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
                .ConfigureAppConfiguration(SetupAppConfig)
                .UseKestrel(SetupKestrel)
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureLogging(ConfigureLogging)
                .UseStartup<Startup>()
                .Build();
        }

        #region Program Configurations

        private static void SetupAppConfig(WebHostBuilderContext hostBuilderContext, IConfigurationBuilder config)
        {
            config
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{hostBuilderContext.HostingEnvironment.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables();

            webHostBuilderContext = hostBuilderContext;
        }

        private static void SetupKestrel(KestrelServerOptions options)
        {
            KestrelConfiguration.Configure(options, webHostBuilderContext.HostingEnvironment, webHostBuilderContext.Configuration, 52532);
        }

        private static void ConfigureLogging(WebHostBuilderContext context, ILoggingBuilder logging)
        {
            SerilogConfiguration.Configure(context.HostingEnvironment, context.Configuration, logging, "OnionPattern.Api");
        }


        #endregion Program Configurations
    }
}
