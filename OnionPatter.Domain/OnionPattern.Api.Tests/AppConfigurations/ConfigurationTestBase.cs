using Microsoft.Extensions.Configuration;

namespace OnionPattern.Api.Tests.AppConfigurations
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
