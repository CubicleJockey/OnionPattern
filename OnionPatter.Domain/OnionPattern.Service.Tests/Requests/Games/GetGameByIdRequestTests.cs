using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.Entities;
using OnionPattern.Domain.Repository;
using OnionPattern.Domain.Services.Requests.Game;
using OnionPattern.Service.Requests.Game;

namespace OnionPattern.Service.Tests.Requests.Games
{
    public class GetGameByIdRequestTests
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
                var request = new GetGameByIdRequest(FakeRepository, FakeRepositoryAggregate, FakeLogger);

                request.Should().NotBeNull();
                request.Should().BeAssignableTo<IGetGameByIdRequest>();
                request.Should().BeAssignableTo<BaseServiceRequest<Game>>();
                request.Should().BeOfType<GetGameByIdRequest>();
            }
        }
    }
}

