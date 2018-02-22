using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OnionPattern.Domain.Tests.GamePlatform.Entities
{
    public class GamePlatformsTests
    {
        [TestClass]
        public class ConstructorTests
        {
            private Domain.GamePlatform.Entities.GamePlatform entity;

            [TestInitialize]
            public void TestIntialize()
            {
                entity = new Domain.GamePlatform.Entities.GamePlatform();
            }

            [TestMethod]
            public void ShouldInheritFromVideoGameEntity()
            {
                entity.Should().BeAssignableTo<VideoGameEntity>();
            }

            [TestMethod]
            public void ShouldBeOfTypeGamePlatform()
            {
                entity.Should().BeOfType<Domain.GamePlatform.Entities.GamePlatform>();
            }
        }
    }
}
