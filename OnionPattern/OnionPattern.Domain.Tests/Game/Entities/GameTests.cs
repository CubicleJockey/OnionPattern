using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OnionPattern.Domain.Tests.Game.Entities
{
    public class GameTests
    {
        [TestClass]
        public class ConstructorTests : TestBase<Domain.Game.Entities.Game>
        {
            [TestInitialize]
            public void TestInitialize()
            {
                Entity = new Domain.Game.Entities.Game();
            }

            [TestMethod]
            public void ShouldInheritFromVideoGameEntity()
            {
                Entity.Should().BeAssignableTo<VideoGameEntity>();
            }

            [TestMethod]
            public void ShouldBeOfTypeGame()
            {
                Entity.Should().BeOfType<Domain.Game.Entities.Game>();
            }
        }
    }
}
