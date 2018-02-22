using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.Configurations;
using OnionPattern.Domain.Constants;

namespace OnionPattern.Domain.Tests.Configurations
{
    [TestClass]
    public class LogLocationsConfigurationTests : ConfigurationTestBase
    {
        [TestMethod]
        public void Valid()
        {
            var connectionStringsConfiguration = Configuration.GetSection(AppSettingsSections.ConnectionStrings).Get<LogLocationConfiguration>();

            connectionStringsConfiguration.Should().NotBeNull();

            connectionStringsConfiguration.FileName.Should().NotBeNullOrWhiteSpace();
            connectionStringsConfiguration.FileName.Should().Be(Configuration[MockAppSettings.ConnectionStringsKeys.VideoGamesConnection]);
        }
    }
}
