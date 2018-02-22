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
            AppSettingsSections.ConnectionStrings.Should().Be("ConnectionStrings");
            AppSettingsSections.Logging.Should().Be("Logging");
            AppSettingsSections.LogLocations.Should().Be("LogLocations");
        }
    }
}
