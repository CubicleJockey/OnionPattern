using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.DataTransferObjects.Game;
using OnionPattern.Domain.Errors;

namespace OnionPattern.Domain.Tests.DataTransferObjects.Game
{
    public class GameListResponseDtoTests
    {
        [TestClass]
        public class ConstructorTests
        {
            [TestMethod]
            public void Inheritence()
            {
                var response = new GameListResponseDto();

                response.Should().NotBeNull();
                response.Should().BeAssignableTo<ErrorDetails>();
                response.Should().BeOfType<GameListResponseDto>();
            }
        }
    }
}
