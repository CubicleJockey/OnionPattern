using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.Entities;
using OnionPattern.Domain.Services.Requests.Game.Async;
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
            public void RepositoryIsNull()
            {
                Action ctor = () => new GameRequestAggregateAsync(null, FakeRepositoryAsyncAggregate);

                ctor.ShouldThrow<ArgumentNullException>()
                    .WithMessage($"Value cannot be null.{Environment.NewLine}Parameter name: repositoryAsync cannot be null.");
            }

            [TestMethod]
            public void ReposiotyrAggregateIsNull()
            {
                Action ctor = () => new GameRequestAggregateAsync(FakeRepositoryAsync, null);

                ctor.ShouldThrow<ArgumentNullException>()
                    .WithMessage($"Value cannot be null.{Environment.NewLine}Parameter name: repositoryAsyncAggregate cannot be null.");
            }

            [TestMethod]
            public void Inheritence()
            {
                var controller = new GameRequestAggregateAsync(FakeRepositoryAsync, FakeRepositoryAsyncAggregate);

                controller.Should().NotBeNull();
                controller.Should().BeAssignableTo<IGameRequestAggregateAsync>();
                controller.Should().BeAssignableTo<GameRequestAggregateAsync>();
            }
        }
    }
}
