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
            private Game entity;

            [TestInitialize]
            public void TestInitialize()
            {
                entity = new Game();
            }

            [TestMethod]
            public void ShouldInheritFromVideoGameEntity()
            {
                entity.Should().BeAssignableTo<VideoGameEntity>();
            }

            [TestMethod]
            public void ShouldBeOfTypeGame()
            {
                entity.Should().BeOfType<Game>();
            }
        }
    }
}
