using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OnionPattern.Domain.Tests.Platform.Entities
{
    public class PlatformTests
    {
        [TestClass]
        public class ConstructorTests : TestBase<Domain.Platform.Entities.Platform>
        {
            [TestInitialize]
            public void TestInitailize()
            {
                Entity = new Domain.Platform.Entities.Platform();
            }

            [TestMethod]
            public void ShouldInheritFromVideoGameEntity()
            {
                Entity.Should().BeAssignableTo<VideoGameEntity>();
            }
        }
    }
}
