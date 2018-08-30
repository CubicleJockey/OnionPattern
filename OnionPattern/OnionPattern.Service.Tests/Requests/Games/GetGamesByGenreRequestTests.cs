using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.Game.Entities;
using OnionPattern.Domain.Services.Requests.Game;
using OnionPattern.Service.Requests.Game;

namespace OnionPattern.Service.Tests.Requests.Games
{
    public class GetGamesByGenreRequestTests
    {
        [TestClass]
        public class ConstructorTests : TestBase<Game>
        {
            private GetGamesByGenreRequest request;

            [TestInitialize]
            public void TestInitailize()
            {
                InitializeFakes();
                request = new GetGamesByGenreRequest(FakeRepository, FakeRepositoryAggregate);
            }

            [TestCleanup]
            public void TestCleanup()
            {
                ClearFakes();
                request = null;
            }

            [TestMethod]
            public void InheritsFromIGetGamesByGenreRequest()
            {
                request.Should().BeAssignableTo<IGetGamesByGenreRequest>();
            }

            [TestMethod]
            public void InheritsFromBaseServiceRequest()
            {
                request.Should().BeAssignableTo<BaseServiceRequest<Game>>();
            }
        }
    }
}
