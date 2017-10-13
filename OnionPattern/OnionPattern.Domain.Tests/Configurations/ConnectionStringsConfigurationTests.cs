using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.Configurations;
using OnionPattern.Domain.Constants;

namespace OnionPattern.Domain.Tests.Configurations
{
    [TestClass]
    public class ConnectionStringsConfigurationTests : ConfigurationTestBase
    {
        [TestMethod]
        public void Valid()
        {
            var connectionStringsConfiguration = Configuration.GetSection(AppSettingsSections.ConnectionStrings).Get<ConnectionStringsConfiguration>();

            connectionStringsConfiguration.Should().NotBeNull();

            connectionStringsConfiguration.VideoGamesConnection.Should().NotBeNullOrWhiteSpace();
            connectionStringsConfiguration.VideoGamesConnection.Should().BeEquivalentTo(Configuration[MockAppSettings.ConnectionStringsKeys.VideoGamesConnection]);
        }
    }
}
