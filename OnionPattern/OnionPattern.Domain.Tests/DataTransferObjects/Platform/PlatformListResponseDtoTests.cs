using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.DataTransferObjects;
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
                response.Should().BeAssignableTo<ErrorDetail>();
                response.Should().BeAssignableTo<IListResponseDto>();
                response.Should().BeOfType<PlatformListResponseDto>();
            }
        }
    }
}
