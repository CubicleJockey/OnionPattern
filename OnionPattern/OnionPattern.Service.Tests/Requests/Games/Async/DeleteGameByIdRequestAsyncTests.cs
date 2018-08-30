using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.Game.Entities;
using OnionPattern.Domain.Services.Requests.Game.Async;
using OnionPattern.Service.Requests.Game.Async;

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
    }
}
