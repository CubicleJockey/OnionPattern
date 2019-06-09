using Microsoft.Extensions.DependencyInjection;
using OnionPattern.DependencyInjection.Configurations;
using OnionPattern.Mapping;

namespace OnionPattern.DependencyInjection
{
    public static class DependencyInjectorHost
    {
        public static void Configure(IServiceCollection services)
        {
            RepositoriesConfiguration.Configure(services);
            RequestAndResponsesConfiguration.Configure(services);
            MappingProfileInitializer.ConfigureMappings();
            LoggingConfiguration.Configure(services);
        }
    }
}
