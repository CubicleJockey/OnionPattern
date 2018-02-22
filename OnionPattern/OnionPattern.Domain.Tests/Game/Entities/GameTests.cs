using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OnionPattern.Domain.Tests.Game.Entities
{
    public class GameTests
    {
        [TestClass]
        public class ConstructorTests
        {
            private Domain.Game.Entities.Game entity;

            [TestInitialize]
            public void TestInitialize()
            {
                entity = new Domain.Game.Entities.Game();
            }

            [TestMethod]
            public void ShouldInheritFromVideoGameEntity()
            {
                entity.Should().BeAssignableTo<VideoGameEntity>();
            }

            [TestMethod]
            public void ShouldBeOfTypeGame()
            {
                entity.Should().BeOfType<Domain.Game.Entities.Game>();
            }
        }
    }
}
