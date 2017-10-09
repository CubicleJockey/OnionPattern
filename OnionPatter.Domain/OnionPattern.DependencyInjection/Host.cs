using Microsoft.Extensions.DependencyInjection;
using OnionPattern.DependencyInjection.Configurations;

namespace OnionPattern.DependencyInjection
{
    public static class Host
    {
        public static void Configure(IServiceCollection services)
        {
            RepositoriesConfiguration.Configure(services);
            RequestAndResponsesConfiguration.Configure(services);
            AutomapperConfiguration.Configure();
        }
    }
}
