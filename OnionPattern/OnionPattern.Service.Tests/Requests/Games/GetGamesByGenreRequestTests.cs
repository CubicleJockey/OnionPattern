using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.Entities;
using OnionPattern.Domain.Services.Requests.Game;
using OnionPattern.Service.Requests.Game;

namespace OnionPattern.Service.Tests.Requests.Games
{
    public class GetGamesByGenreRequestTests
    {
        [TestClass]
        public class ConstructorTests : TestBase<Game>
        {
            [TestInitialize]
            public void TestInitailize()
            {
                InitializeFakes();
            }

            [TestCleanup]
            public void TestCleanup()
            {
                ClearFakes();
            }

            [TestMethod]
            public void Inheritence()
            {
                var request = new GetGamesByGenreRequest(FakeRepository, FakeRepositoryAggregate);

                request.Should().NotBeNull();
                request.Should().BeAssignableTo<BaseServiceRequest<Game>>();
                request.Should().BeAssignableTo<IGetGamesByGenreRequest>();
                request.Should().BeOfType<GetGamesByGenreRequest>();
            }
        }
    }
}
