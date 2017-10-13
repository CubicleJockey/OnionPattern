using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.Entities;
using OnionPattern.Domain.Services.Requests.Game;
using OnionPattern.Service.Requests.Game;

namespace OnionPattern.Service.Tests.Requests.Games
{
    public class DeleteGameByIdRequestTests
    {
        [TestClass]
        public class ConstructorTests : TestBase<Game>
        {
            [TestInitialize]
            public void TestInitialize()
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
                var request = new DeleteGameByIdRequest(FakeRepository, FakeRepositoryAggregate, FakeLogger);

                request.Should().NotBeNull();
                request.Should().BeAssignableTo<IDeleteGameByIdRequest>();
                request.Should().BeAssignableTo<BaseServiceRequest<Game>>();
                request.Should().BeOfType<DeleteGameByIdRequest>();
            }
        }
    }
}
