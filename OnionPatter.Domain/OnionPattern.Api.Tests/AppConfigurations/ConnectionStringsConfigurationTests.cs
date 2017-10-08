using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Api.AppConstants;
using OnionPattern.Domain.AppConfigurations;

namespace OnionPattern.Api.Tests.AppConfigurations
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
