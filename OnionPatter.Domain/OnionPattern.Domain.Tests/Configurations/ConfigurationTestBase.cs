using Microsoft.Extensions.Configuration;

namespace OnionPattern.Domain.Tests.Configurations
{
    public abstract class ConfigurationTestBase
    {
        protected IConfigurationRoot Configuration;

        protected ConfigurationTestBase()
        {
            var builder = new ConfigurationBuilder();
            builder.AddInMemoryCollection(MockAppSettings.DevConfiguration);
            Configuration = builder.Build();
        }
    }
}
