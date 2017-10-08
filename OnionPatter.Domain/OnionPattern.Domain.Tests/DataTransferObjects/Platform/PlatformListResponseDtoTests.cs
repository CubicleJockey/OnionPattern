using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.DataTransferObjects.Platform;
using OnionPattern.Domain.Errors;

namespace OnionPattern.Domain.Tests.DataTransferObjects.Platform
{
    public class PlatformListResponseDtoTests
    {
        [TestClass]
        public class ConstructorTests
        {
            [TestMethod]
            public void Inheritence()
            {
                var response = new PlatformListResponseDto();

                response.Should().NotBeNull();
                response.Should().BeAssignableTo<ErrorDetails>();
                response.Should().BeOfType<PlatformListResponseDto>();
            }
        }
    }
}
