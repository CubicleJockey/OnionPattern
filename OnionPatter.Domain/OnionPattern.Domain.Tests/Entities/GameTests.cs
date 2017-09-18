using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.Entities;

namespace OnionPattern.Domain.Tests.Entities
{
    public class GameTests
    {
        [TestClass]
        public class ConstructorTests
        {
            [TestMethod]
            public void Inheritence()
            {
                var game = new Game();

                game.Should().NotBeNull();
                game.Should().BeAssignableTo<VideoGameEntity>();
                game.Should().BeOfType<Game>();
            }
        }
    }
}
