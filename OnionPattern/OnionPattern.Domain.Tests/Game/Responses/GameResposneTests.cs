using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.Errors;
using OnionPattern.Domain.Game;
using OnionPattern.Domain.Game.Responses;

namespace OnionPattern.Domain.Tests.Game.Responses
{
    public class GameResposneTests
    {
        [TestClass]
        public class ConstructorTests : TestBase<GameResponse>
        {
            [TestMethod]
            public void InheritsFromIGame()
            {
                Entity.Should().BeAssignableTo<IGame>();
            }

            [TestMethod]
            public void InheritsFromIError()
            {
                Entity.Should().BeAssignableTo<IError>();
            }
        }
    }
}
