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
            private GamePlatform entity;

            [TestInitialize]
            public void TestIntialize()
            {
                entity = new GamePlatform();
            }

            [TestMethod]
            public void ShouldInheritFromVideoGameEntity()
            {
                entity.Should().BeAssignableTo<VideoGameEntity>();
            }

            [TestMethod]
            public void ShouldBeOfTypeGamePlatform()
            {
                entity.Should().BeOfType<GamePlatform>();
            }
        }
    }
}
