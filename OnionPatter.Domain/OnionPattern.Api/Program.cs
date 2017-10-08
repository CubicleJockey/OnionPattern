using System.IO;
using System.Net;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OnionPattern.Api.AppConstants;
using OnionPattern.Api.StartupConfigurations;

namespace OnionPattern.Api
{
    /// <summary>
    /// Program Host
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            //get the environment and appsettings
            BuildWebHost(args).Run();
        }

        /// <summary>
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IWebHost BuildWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var env = hostingContext.HostingEnvironment;
                    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
                    config.AddEnvironmentVariables();
                })
                .UseKestrel(options =>
                {
                    options.Listen(IPAddress.Loopback, 52532, listenOptions =>
                    {
                        listenOptions.NoDelay = true;
                    });
                })
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging.AddConfiguration(hostingContext.Configuration.GetSection(AppSettingsSections.Logging));
                    logging.AddConsole();
                    logging.AddDebug();

                    LoggingStartupConfiguration.Create(hostingContext);
                })
                .UseApplicationInsights()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .Build();
        }
    }
}
