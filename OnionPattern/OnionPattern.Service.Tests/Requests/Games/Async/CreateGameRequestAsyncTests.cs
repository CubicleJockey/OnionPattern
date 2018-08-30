using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.Game.Entities;
using OnionPattern.Domain.Services.Requests.Game.Async;
using OnionPattern.Service.Requests.Game.Async;

namespace OnionPattern.Service.Tests.Requests.Games.Async
{
    public class CreateGameRequestAsyncTests
    {
        [TestClass]
        public class ConstructorTests : TestBaseAsync<Game>
        {
            private CreateGameRequestAsync request;

            [TestInitialize]
            public void TestInitalize()
            {
                InitializeFakes();
                request = new CreateGameRequestAsync(FakeRepositoryAsync, FakeRepositoryAsyncAggregate);
            }

            [TestCleanup]
            public void TestCleanup()
            {
                ClearFakes();
                request = null;
            }

            [TestMethod]
            public void InheritsFromICreateGameRequestAsync()
            {
                request.Should().BeAssignableTo<ICreateGameRequestAsync>();
            }

            [TestMethod]
            public void InheritsFromBaseServiceRequestAsync()
            {
                request.Should().BeAssignableTo<BaseServiceRequestAsync<Game>>();
            }
        }
    }
}

