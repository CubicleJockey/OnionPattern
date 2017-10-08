using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Api.AppConstants;

namespace OnionPattern.Api.Tests.AppConstants
{
    [TestClass]
    public class EnvironmentTypesTests
    {
        [TestMethod]
        public void ValidValues()
        {
            EnvironmentTypes.Local.Should().BeEquivalentTo("FileName");
        }
    }
}
