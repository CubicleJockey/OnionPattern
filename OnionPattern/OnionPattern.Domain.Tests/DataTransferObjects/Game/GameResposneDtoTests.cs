using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.DataTransferObjects.Game;
using OnionPattern.Domain.Errors;
using OnionPattern.Domain.Interfaces;

namespace OnionPattern.Domain.Tests.DataTransferObjects.Game
{
    public class GameResposneDtoTests
    {
        [TestClass]
        public class ConstructorTests
        {
            [TestMethod]
            public void Inheritence()
            {
                var response = new GameResponseDto();

                response.Should().NotBeNull();
                response.Should().BeAssignableTo<IGame>();
                response.Should().BeAssignableTo<ErrorDetail>();
                response.Should().BeOfType<GameResponseDto>();
            }
        }
    }
}
