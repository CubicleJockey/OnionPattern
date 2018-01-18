using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.Entities;

namespace OnionPattern.Domain.Tests.Entities
{
    public class PlatformTests
    {
        [TestClass]
        public class ConstructorTests
        {
            private Platform entity;

            [TestInitialize]
            public void TestInitailize()
            {
                entity = new Platform();
            }

            [TestMethod]
            public void ShouldInheritFromVideoGameEntity()
            {
                entity.Should().BeAssignableTo<VideoGameEntity>();
            }
        }
    }
}
