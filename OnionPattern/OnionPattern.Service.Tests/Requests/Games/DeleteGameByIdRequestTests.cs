using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.Game.Entities;
using OnionPattern.Domain.Services.Requests.Game;
using OnionPattern.Service.Requests.Game;

namespace OnionPattern.Service.Tests.Requests.Games
{
    public class DeleteGameByIdRequestTests
    {
        [TestClass]
        public class ConstructorTests : TestBase<Game>
        {
            private DeleteGameByIdRequest request;

            [TestInitialize]
            public void TestInitialize()
            {
                InitializeFakes();
                request = new DeleteGameByIdRequest(FakeRepository, FakeRepositoryAggregate);
            }

            [TestCleanup]
            public void TestCleanup()
            {
                ClearFakes();
                request = null;
            }

            [TestMethod]
            public void InheritsFromIDeleteGameByIdRequest()
            {
                request.Should().BeAssignableTo<IDeleteGameByIdRequest>();
            }

            [TestMethod]
            public void InheritsFromBaseServiceRequest()
            {
                request.Should().BeAssignableTo<BaseServiceRequest<Game>>();
            }
        }
    }
}
