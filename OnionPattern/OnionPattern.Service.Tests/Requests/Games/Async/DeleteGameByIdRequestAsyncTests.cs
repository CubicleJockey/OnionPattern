using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.Game.Entities;
using OnionPattern.Domain.GamePlatform.Entities;
using OnionPattern.Domain.Services.Requests.Game.Async;
using OnionPattern.Service.Requests.Game.Async;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OnionPattern.Service.Tests.Requests.Games.Async
{
    public class DeleteGameByIdRequestAsyncTests
    {
        [TestClass]
        public class ConstructorTests : TestBaseAsync<Game>
        {
            private DeleteGameByIdRequestAsync request;

            [TestInitialize]
            public void TestInitalize()
            {
                InitializeFakes();
                request = new DeleteGameByIdRequestAsync(FakeRepositoryAsync, FakeRepositoryAsyncAggregate);
            }

            [TestCleanup]
            public void TestCleanup()
            {
                ClearFakes();
                request = null;
            }

            [TestMethod]
            public void InheritsFromIDeleteGameByIdRequestAsync()
            {
                request.Should().BeAssignableTo<IDeleteGameByIdRequestAsync>();
            }

            [TestMethod]
            public void InheritsFromBaseServiceRequestAsync()
            {
                request.Should().BeAssignableTo<BaseServiceRequestAsync<Game>>();
            }
        }

        [TestClass]
        public class MethodsTests : TestBaseAsync<Game>
        {
            private DeleteGameByIdRequestAsync request;

            #region Game Requests
            private Expression<Func<Task<Game>>> gameSingleOrDefaultAsync;
            private Expression<Func<Task<Game>>> gameDeleteAsync;
            #endregion Game Requests

            #region GamePlatform Requests
            private Expression<Func<Task<IEnumerable<Game>>>> gamePlatformFindAsync;
            private Expression<Func<Task<GamePlatform>>> gamePlatformDeleteAsync;
            #endregion GamePlatform Request


            [TestInitialize]
            public void TestInitialize()
            {
                InitializeFakes();
                request = new DeleteGameByIdRequestAsync(FakeRepositoryAsync, FakeRepositoryAsyncAggregate);

                //gameSingleOrDefaultAsync =
                //    FakeRepositoryAsync.SingleOrDefaultAsync(A<Expression<Func<Game, bool>>>.Ignored);
            }

            [TestCleanup]
            public void TestCleanup()
            {
                ClearFakes();
                request = null;
            }


        }
    }
}
