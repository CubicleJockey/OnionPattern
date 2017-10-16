using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.DataTransferObjects.Platform;
using OnionPattern.Domain.Interfaces;

namespace OnionPattern.Domain.Tests.DataTransferObjects.Platform
{
    public class PlatformResponseDtoTests
    {
        [TestClass]
        public class ConstructorTests
        {
            [TestMethod]
            public void Inheritence()
            {
                var reponse = new PlatformResponseDto();

                reponse.Should().NotBeNull();
                reponse.Should().BeAssignableTo<IPlatform>();
                reponse.Should().BeOfType<PlatformResponseDto>();
            }
        }
    }
}
