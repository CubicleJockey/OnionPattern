using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.Entities;

namespace OnionPattern.Domain.Tests.Entities
{
    public class GamePlatformsTests
    {
        [TestClass]
        public class ConstructorTests
        {
            [TestMethod]
            public void Inheritence()
            {
                var gamePlatform = new GamePlatform();

                gamePlatform.Should().NotBeNull();
                gamePlatform.Should().BeAssignableTo<VideoGameEntity>();
                gamePlatform.Should().BeOfType<GamePlatform>();
            }
        }
    }
}
