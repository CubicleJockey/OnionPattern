using System;
using FakeItEasy;
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
            [TestInitialize]
            public void TestInitalize()
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
                var requestAggregate = new GameRequestAggregate(FakeRepository, FakeRepositoryAggregate);

                requestAggregate.Should().NotBeNull();
                requestAggregate.Should().BeAssignableTo<BaseRequestAggregate<Game>>();
                requestAggregate.Should().BeAssignableTo<IGameRequestAggregate>();
                requestAggregate.Should().BeAssignableTo<GameRequestAggregate>();
            }
        }
    }
}
