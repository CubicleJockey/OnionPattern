using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.Entities;
using OnionPattern.Domain.Repository;
using OnionPattern.Domain.Services;
using OnionPattern.Domain.Services.Requests.Game;
using OnionPattern.Service.Requests.Game;
using OnionPattern.Service.Responses;

namespace OnionPattern.Service.Tests.Requests.Games
{
    public class GetAllGamesRequestTests
    {
        private static IRepository<Game> fakeRepository;
        private static IRepositoryAggregate fakeRepositoryAggregate;

        [TestClass]
        public class ConstructorTests
        {
            [TestInitialize]
            public void TestInitialize()
            {
                fakeRepository = A.Fake<IRepository<Game>>();
                fakeRepositoryAggregate = A.Fake<IRepositoryAggregate>();
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
                var request = new GetAllGamesRequest(fakeRepository, fakeRepositoryAggregate);

                request.Should().NotBeNull();
                request.Should().BeAssignableTo<IGetAllGamesRequest>();
                request.Should().BeAssignableTo<BaseServiceRequest<Game>>();
                request.Should().BeOfType<GetAllGamesRequest>();
            }
        }

        [TestClass]
        public class MethodTests
        {
            [TestInitialize]
            public void TestInitialize()
            {
                fakeRepository = A.Fake<IRepository<Game>>();
                fakeRepositoryAggregate = A.Fake<IRepositoryAggregate>();
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
