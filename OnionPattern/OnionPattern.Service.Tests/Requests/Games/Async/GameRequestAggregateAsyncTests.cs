using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.Game.Entities;
using OnionPattern.Domain.Services.Requests.Game.Async;
using OnionPattern.Service.Requests;
using OnionPattern.Service.Requests.Game.Async;

namespace OnionPattern.Service.Tests.Requests.Games.Async
{
    public class GameRequestAggregateAsyncTests
    {
        [TestClass]
        public class ConstructorTests : TestBaseAsync<Game>
        {
            private GameRequestAsyncAggregate requestAggreggate;

            [TestInitialize]
            public void TestInitalize()
            {
                InitializeFakes();

                requestAggreggate = new GameRequestAsyncAggregate(FakeRepositoryAsync, FakeRepositoryAsyncAggregate);
            }

            [TestCleanup]
            public void TestCleaanup()
            {
                ClearFakes();
                requestAggreggate = null;
            }

            [TestMethod]
            public void InheritsFromBaseRequestAsyncAggregate()
            {
                requestAggreggate.Should().BeAssignableTo<BaseRequestAsyncAggregate<Game>>();
            }

            [TestMethod]
            public void InheritsFromIGameRequestAggregateAsync()
            {
                requestAggreggate.Should().BeAssignableTo<IGameRequestAggregateAsync>();
            }
        }
    }
}
