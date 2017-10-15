using System;
using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.Entities;
using OnionPattern.Domain.Services.Requests.Game;
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
            public void RepositoryIsNull()
            {
                Action ctor = () => new GameRequestAggregate(null, FakeRepositoryAggregate);

                ctor.ShouldThrow<ArgumentNullException>()
                    .WithMessage($"Value cannot be null.{Environment.NewLine}Parameter name: repository cannot be null.");
            }

            [TestMethod]
            public void ReposiotyrAggregateIsNull()
            {
                Action ctor = () => new GameRequestAggregate(FakeRepository, null);

                ctor.ShouldThrow<ArgumentNullException>()
                    .WithMessage($"Value cannot be null.{Environment.NewLine}Parameter name: repositoryAggregate cannot be null.");
            }

            [TestMethod]
            public void Inheritence()
            {
                var controller = new GameRequestAggregate(FakeRepository, FakeRepositoryAggregate);

                controller.Should().NotBeNull();
                controller.Should().BeAssignableTo<IGameRequestAggregate>();
                controller.Should().BeAssignableTo<GameRequestAggregate>();
            }
        }
    }
}
