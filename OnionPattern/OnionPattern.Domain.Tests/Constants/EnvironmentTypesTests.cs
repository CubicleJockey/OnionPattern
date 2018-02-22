using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.Constants;

namespace OnionPattern.Domain.Tests.Constants
{
    [TestClass]
    public class EnvironmentTypesTests
    {
        [TestMethod]
        public void ValidValues()
        {
            EnvironmentTypes.Local.Should().Be("Local");
        }
    }
}
