using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.Entities;
using OnionPattern.Domain.Repository;
using OnionPattern.Domain.Services.Requests.Game;
using OnionPattern.Service.Requests.Game;

namespace OnionPattern.Service.Tests.Requests.Games
{
    public class GetAllGamesRequestAsyncTests
    {
        private static IRepositoryAsync<Game> fakeRepository;
        private static IRepositoryAsyncAggregate fakeRepositoryAggregate;

        [TestClass]
        public class ConstructorTests
        {
            [TestInitialize]
            public void TestInitialize()
            {
                fakeRepository = A.Fake<IRepositoryAsync<Game>>();
                fakeRepositoryAggregate = A.Fake<IRepositoryAsyncAggregate>();
            }

            [TestCleanup]
            public void TestCleanup()
            {
                Fake.ClearConfiguration(fakeRepository);
                Fake.ClearConfiguration(fakeRepositoryAggregate);
            }

            [TestMethod]
            public void Inheritence()
            {
                var request = new GetAllGamesRequestAsync(fakeRepository, fakeRepositoryAggregate);

                request.Should().NotBeNull();
                request.Should().BeAssignableTo<IGetAllGamesRequestAsync>();
                request.Should().BeAssignableTo<BaseServiceRequestAsync<Game>>();
                request.Should().BeOfType<GetAllGamesRequestAsync>();
            }
        }

        [TestClass]
        public class MethodTests
        {
            [TestInitialize]
            public void TestInitialize()
            {
                fakeRepository = A.Fake<IRepositoryAsync<Game>>();
                fakeRepositoryAggregate = A.Fake<IRepositoryAsyncAggregate>();
            }

            [TestCleanup]
            public void TestCleanup()
            {
                Fake.ClearConfiguration(fakeRepository);
                Fake.ClearConfiguration(fakeRepositoryAggregate);
            }
        }
    }
}
