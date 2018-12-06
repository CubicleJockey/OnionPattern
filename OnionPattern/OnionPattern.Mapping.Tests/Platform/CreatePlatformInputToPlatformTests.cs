using AutoMapper;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.Platform.Requests;
using System;

namespace OnionPattern.Mapping.Tests.Platform
{
    [TestClass]
    public class CreatePlatformInputToPlatformTests : TestBase
    {
        [TestMethod]
        public void Valid()
        {
            var createPlatformInput = new CreatePlatformInput
            {
                Name = "Platformy",
                ReleaseDate = DateTime.Now.AddDays(-20)
            };

            var platform = Mapper.Map<Domain.Platform.Entities.Platform>(createPlatformInput);

            platform.Should().NotBeNull();
            platform.Name.Should().Be(createPlatformInput.Name);
            platform.ReleaseDate.Should().Be(createPlatformInput.ReleaseDate);
        }
    }
}
