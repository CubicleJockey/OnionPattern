using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.DataTransferObjects.Platform;
using OnionPattern.Domain.Errors;
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
                var response = new PlatformResponseDto();

                response.Should().NotBeNull();
                response.Should().BeAssignableTo<ErrorDetail>();
                response.Should().BeAssignableTo<IPlatform>();
                response.Should().BeOfType<PlatformResponseDto>();
            }
        }
    }
}
