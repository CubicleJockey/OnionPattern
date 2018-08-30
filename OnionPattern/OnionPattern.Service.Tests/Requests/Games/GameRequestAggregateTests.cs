using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.Game.Entities;
using OnionPattern.Domain.Services.Requests.Game;
using OnionPattern.Service.Requests;
using OnionPattern.Service.Requests.Game;

namespace OnionPattern.Service.Tests.Requests.Games
{
    public class GameRequestAggregateTests
    {
        [TestClass]
        public class ConstructorTests : TestBase<Game>
        {
            private GameRequestAggregate requestAggregate;

            [TestInitialize]
            public void TestInitalize()
            {
                InitializeFakes();
                requestAggregate = new GameRequestAggregate(FakeRepository, FakeRepositoryAggregate);
            }

            [TestCleanup]
            public void TestCleanup()
            {
                ClearFakes();
                requestAggregate = null;
            }

            [TestMethod]
            public void InheritsFromIGameRequestAggregate()
            {
                requestAggregate.Should().BeAssignableTo<IGameRequestAggregate>();
            }

            [TestMethod]
            public void InheritsFromBaseRequestAggregate()
            {
                requestAggregate.Should().BeAssignableTo<BaseRequestAggregate<Game>>();
            }
        }
    }
}
