using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Net;

namespace OnionPattern.Api.Configuration.Program
{
    /// <summary>
    /// Kestrel Configuration Class
    /// </summary>
    public static class KestrelConfiguration
    {
        /// <summary>
        /// Configure Kestrel to run consistantly across the Sentinel
        /// Web and Api projects.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="hostingEnvironment">Hosting Environment Properites</param>
        /// <param name="configuration">Configuration Properties</param>
        /// <param name="localPort">Choose the port for this service to function on</param>
        public static void Configure(KestrelServerOptions options,
            IHostingEnvironment hostingEnvironment,
            IConfiguration configuration,
            int localPort)
        {
            try
            {
                Log.Information("Setting Kestrel Server Options");

                // var sslCertificate = SOME CONFIGURATION TO GET CERTIFICATES FOR HTTPS

                //var port = hostingEnvironment.IsEnvironment(EnvironmentTypes.Local)
                //    ? localPort
                //    : 443;

                options.Listen(IPAddress.Any, localPort, listenOptions =>
                {
                    listenOptions.NoDelay = true;
                    //listenOptions.UseHttps(sslCertificate);
                });
            }
            catch (Exception exception)
            {
                Log.Fatal(exception, "Host terminated unexpectedly! -- {Message}", exception.Message);
            }
        }
    }
}
