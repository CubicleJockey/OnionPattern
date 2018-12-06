using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OnionPattern.Domain.Configurations;
using Serilog;
using System.IO;

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
                var basicLoggingConfiguration = new LoggerConfiguration().MinimumLevel.Verbose().CreateLogger();

                var fileName = logLocationConfig?.Value?.FileName;
                if (string.IsNullOrWhiteSpace(fileName)) { return basicLoggingConfiguration; }

                var file = new FileInfo(fileName);

                var directoryCheck = file.Directory;

                //Plain Logging
                if (directoryCheck == null) { return basicLoggingConfiguration; }

                directoryCheck.Refresh();
                if (!directoryCheck.Exists)
                {
                    directoryCheck.Create();
                }

                return new LoggerConfiguration()
                    .MinimumLevel.Verbose()
                    .WriteTo.RollingFile(logLocationConfig.Value.FileName)
                    .CreateLogger();
            });
        }
    }
}
