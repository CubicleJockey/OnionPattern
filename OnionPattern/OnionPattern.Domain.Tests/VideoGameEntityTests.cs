using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OnionPattern.Domain.Tests
{
    [TestClass]
    public class VideoGameEntityTests
    {
        private VideoGameEntity videoGameEntity;

        [TestInitialize]
        public void TestInitialize()
        {
            videoGameEntity = A.Fake<VideoGameEntity>();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            videoGameEntity = null;
        }

        [TestMethod]
        public void ValidationErrorsDefaultValueIsNotNull()
        {
            videoGameEntity.ValidationErrors.Should().NotBeNull();
            videoGameEntity.ValidationErrors.Should().BeEmpty();
        }
    }
}
