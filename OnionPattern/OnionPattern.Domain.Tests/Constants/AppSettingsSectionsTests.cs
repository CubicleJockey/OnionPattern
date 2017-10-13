using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.Constants;

namespace OnionPattern.Domain.Tests.Constants
{
    [TestClass]
    public class AppSettingsSectionsTests
    {
        [TestMethod]
        public void ValidValues()
        {
            AppSettingsSections.ConnectionStrings.Should().BeEquivalentTo("ConnectionStrings");
            AppSettingsSections.Logging.Should().BeEquivalentTo("Logging");
            AppSettingsSections.LogLocations.Should().BeEquivalentTo("LogLocations");
        }
    }
}
