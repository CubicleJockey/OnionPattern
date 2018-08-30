using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OnionPattern.Domain.Tests.GamePlatform.Entities
{
    public class GamePlatformsTests
    {
        [TestClass]
        public class ConstructorTests : TestBase<Domain.GamePlatform.Entities.GamePlatform>
        {
            [TestInitialize]
            public void TestIntialize()
            {
                Entity = new Domain.GamePlatform.Entities.GamePlatform();
            }

            [TestMethod]
            public void ShouldInheritFromVideoGameEntity()
            {
                Entity.Should().BeAssignableTo<VideoGameEntity>();
            }

            [TestMethod]
            public void ShouldBeOfTypeGamePlatform()
            {
                Entity.Should().BeOfType<Domain.GamePlatform.Entities.GamePlatform>();
            }
        }
    }
}
