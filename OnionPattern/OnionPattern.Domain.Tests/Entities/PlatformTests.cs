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
            [TestMethod]
            public void Inheritence()
            {
                var platform = new Platform();

                platform.Should().NotBeNull();
                platform.Should().BeAssignableTo<VideoGameEntity>();
                platform.Should().BeOfType<Platform>();
            }
        }
    }
}
