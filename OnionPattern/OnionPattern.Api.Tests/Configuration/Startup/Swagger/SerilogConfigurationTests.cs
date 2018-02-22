using System;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Api.Configuration.Program;

namespace OnionPattern.Api.Tests.Configuration.Startup.Swagger
{
    [TestClass]
    public class SerilogConfigurationTests
    {
        private readonly IHostingEnvironment fakeHostingEnvironment;
        private readonly IConfiguration fakeConfiguration;
        private readonly ILoggingBuilder fakeLoggingBuilder;

        public SerilogConfigurationTests()
        {
            fakeHostingEnvironment = A.Fake<IHostingEnvironment>();
            fakeConfiguration = A.Fake<IConfiguration>();
            fakeLoggingBuilder = A.Fake<ILoggingBuilder>();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Fake.ClearConfiguration(fakeHostingEnvironment);
            Fake.ClearConfiguration(fakeConfiguration);
            Fake.ClearConfiguration(fakeLoggingBuilder);
        }

        [TestMethod]
        public void HostingEnvironmentCannotBeNull()
        {
            Action method = () => SerilogConfiguration.Configure(null, fakeConfiguration, fakeLoggingBuilder, A.Dummy<string>());

            method.Should()
                  .Throw<ArgumentNullException>()
                  .WithMessage($"Value cannot be null.{Environment.NewLine}Parameter name: hostingEnvironment");
        }

        [TestMethod]
        public void ConfigurationCannotBeNull()
        {
            Action method = () => SerilogConfiguration.Configure(fakeHostingEnvironment, null, fakeLoggingBuilder, A.Dummy<string>());

            method.Should()
                .Throw<ArgumentNullException>()
                .WithMessage($"Value cannot be null.{Environment.NewLine}Parameter name: configuration");
        }

        [TestMethod]
        public void LoggingBuilderCannotBeNull()
        {
            Action method = () => SerilogConfiguration.Configure(fakeHostingEnvironment, fakeConfiguration, null, A.Dummy<string>());

            method.Should()
                .Throw<ArgumentNullException>()
                .WithMessage($"Value cannot be null.{Environment.NewLine}Parameter name: logging");
        }

        [DataRow(default(string))]
        [DataRow("")]
        [DataRow("           ")]
        [DataTestMethod]
        public void ApplicationNameCannotBeEmpty(string applicationName)
        {
            Action method = () => SerilogConfiguration.Configure(fakeHostingEnvironment, fakeConfiguration, fakeLoggingBuilder, applicationName);

            method.Should()
                .Throw<ArgumentException>()
                .WithMessage("applicationName cannot be empty.");
        }
    }
}
