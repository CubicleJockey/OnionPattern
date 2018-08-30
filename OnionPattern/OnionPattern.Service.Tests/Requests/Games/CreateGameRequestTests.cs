using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.Game.Entities;
using OnionPattern.Domain.Services.Requests.Game;
using OnionPattern.Service.Requests.Game;

namespace OnionPattern.Service.Tests.Requests.Games
{
    public class CreateGameRequestTests
    {
        [TestClass]
        public class ConstructorTests : TestBase<Game>
        {
            private CreateGameRequest request;

            [TestInitialize]
            public void TestInitialize()
            {
                InitializeFakes();
                request = new CreateGameRequest(FakeRepository, FakeRepositoryAggregate);
            }

            [TestCleanup]
            public void Cleanup()
            {
                ClearFakes();
                request = null;
            }

            [TestMethod]
            public void InheritsFromICreateGameRequest()
            {
                request.Should().BeAssignableTo<ICreateGameRequest>();
            }

            [TestMethod]
            public void InheritsFromBaseServiceRequest()
            {
                request.Should().BeAssignableTo<BaseServiceRequest<Game>>();
            }
        }
    }
}
