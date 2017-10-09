using System;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Api.Controllers;
using OnionPattern.Domain.Services.Requests.Game;

namespace OnionPattern.Api.Tests.Controllers
{
    public class GamesAsyncControllerTests
    {
        [TestClass]
        public class ConstructorTests
        {
            private IGetAllGamesRequestAsync fakeGetAllGamesRequestAsync;
            private IGetGameByIdRequestAsync fakeGetGameByIdRequestAsync;

            [TestInitialize]
            public void TestInitialize()
            {
                fakeGetAllGamesRequestAsync = A.Fake<IGetAllGamesRequestAsync>();
                fakeGetGameByIdRequestAsync = A.Fake<IGetGameByIdRequestAsync>();
            }

            [TestCleanup]
            public void TestCleanup()
            {
                Fake.ClearConfiguration(fakeGetAllGamesRequestAsync);
                Fake.ClearConfiguration(fakeGetGameByIdRequestAsync);
            }

            [TestMethod]
            public void GetAllGamesRequestAsyncIsNull()
            {
                Action ctor = () => new GamesAsyncController(null, fakeGetGameByIdRequestAsync);

                ctor.ShouldThrow<ArgumentNullException>()
                    .WithMessage($"Value cannot be null.{Environment.NewLine}Parameter name: getAllGamesRequest cannot be null.");
            }

            [TestMethod]
            public void GetGamesByIdRequestAsyncIsNull()
            {
                Action ctor = () => new GamesAsyncController(fakeGetAllGamesRequestAsync, null);

                ctor.ShouldThrow<ArgumentNullException>()
                    .WithMessage($"Value cannot be null.{Environment.NewLine}Parameter name: getGameByIdRequest cannot be null.");
            }

            [TestMethod]
            public void Inheritence()
            {
                var controller = new GamesAsyncController(fakeGetAllGamesRequestAsync, fakeGetGameByIdRequestAsync);

                controller.Should().NotBeNull();
                controller.Should().BeAssignableTo<Controller>();
                controller.Should().BeOfType<GamesAsyncController>();
            }
        }
    }
}
