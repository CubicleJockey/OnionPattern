using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.Entities;

namespace OnionPattern.Domain.Tests.Platform.Entities
{
    public class PlatformTests
    {
        [TestClass]
        public class ConstructorTests
        {
            private Domain.Platform.Entities.Platform entity;

            [TestInitialize]
            public void TestInitailize()
            {
                entity = new Domain.Platform.Entities.Platform();
            }

            [TestMethod]
            public void ShouldInheritFromVideoGameEntity()
            {
                entity.Should().BeAssignableTo<VideoGameEntity>();
            }
        }
    }
}
