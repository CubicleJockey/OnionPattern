using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.Constants;

namespace OnionPattern.Domain.Tests.Constants
{
    [TestClass]
    public class EnvironmentVariablesTests
    {
        [TestMethod]
        public void ValidValues()
        {
            EnvironmentVariables.InMemoryDb.Should().BeEquivalentTo("InMemoryDb");
            EnvironmentVariables.ASPNETCORE_ENVIRONMENT.ShouldAllBeEquivalentTo("ASPNETCORE_ENVIRONMENT");
        }
    }
}
