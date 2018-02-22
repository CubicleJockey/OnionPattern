using System;
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
            [TestInitialize]
            public void TestInitalize()
            {
                InitializeFakes();
            }

            [TestCleanup]
            public void TestCleaanup()
            {
                ClearFakes();
            }

            [TestMethod]
            public void Inheritence()
            {
                var requestAggreggate = new GameRequestAsyncAggregate(FakeRepositoryAsync, FakeRepositoryAsyncAggregate);

                requestAggreggate.Should().NotBeNull();
                requestAggreggate.Should().BeAssignableTo<BaseRequestAsyncAggregate<Game>>();
                requestAggreggate.Should().BeAssignableTo<IGameRequestAggregateAsync>();
                requestAggreggate.Should().BeAssignableTo<GameRequestAsyncAggregate>();
            }
        }
    }
}
