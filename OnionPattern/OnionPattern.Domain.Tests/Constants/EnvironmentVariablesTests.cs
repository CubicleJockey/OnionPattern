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
            EnvironmentVariables.InMemoryDb.Should().Be("InMemoryDb");
            EnvironmentVariables.ASPNETCORE_ENVIRONMENT.Should().Be("ASPNETCORE_ENVIRONMENT");
        }

        [TestMethod]
        public void GetInMemoryDbValueIsFalse()
        {
            Environment.SetEnvironmentVariable(EnvironmentVariables.InMemoryDb, bool.FalseString.ToLower());
            var result = EnvironmentVariables.GetInMemoryDbValue();
            result.Should().BeFalse();
        }

        [TestMethod]
        public void GetInMemoryDbValuesIsTrue()
        {
            Environment.SetEnvironmentVariable(EnvironmentVariables.InMemoryDb, bool.TrueString.ToLower());
            var result = EnvironmentVariables.GetInMemoryDbValue();
            result.Should().BeTrue();
        }
    }
}
