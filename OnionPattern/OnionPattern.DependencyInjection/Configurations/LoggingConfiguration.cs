using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System.IO;
using Microsoft.Extensions.Options;
using OnionPattern.Domain.Configurations;

namespace OnionPattern.DependencyInjection.Configurations
{
    public static class LoggingConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var logLocationConfig = serviceProvider.GetService<IOptions<LogLocationConfiguration>>();

            services.AddSingleton<ILogger>(context =>
            {
                var directoryCheck = (new FileInfo(logLocationConfig.Value.FileName)).Directory;
                directoryCheck.Refresh();
                if (!directoryCheck.Exists) { directoryCheck.Create(); }

                return new LoggerConfiguration()
                    .MinimumLevel.Verbose()
                    .WriteTo.RollingFile(logLocationConfig.Value.FileName)
                    .CreateLogger();
            });
        }
    }
}
