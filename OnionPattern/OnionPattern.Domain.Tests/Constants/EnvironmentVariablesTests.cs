using System;
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

        [TestMethod]
        public void GetInMemoryDbValueIsFalse()
        {
            Environment.SetEnvironmentVariable(EnvironmentVariables.InMemoryDb, "false");
            var result = EnvironmentVariables.GetInMemoryDbValue();
            result.Should().BeFalse();
        }

        [TestMethod]
        public void GetInMemoryDbValuesIsTrue()
        {
            Environment.SetEnvironmentVariable(EnvironmentVariables.InMemoryDb, "true");
            var result = EnvironmentVariables.GetInMemoryDbValue();
            result.Should().BeTrue();
        }
    }
}
