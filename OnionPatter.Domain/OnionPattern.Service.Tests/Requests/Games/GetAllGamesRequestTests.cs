using System;
using System.Collections.Generic;
using System.Text;
using FakeItEasy;
using FluentAssertions;
using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.Entities;
using OnionPattern.Domain.Repository;
using OnionPattern.Service.Requests;
using OnionPattern.Service.Requests.Games;
using OnionPattern.Service.Responses;

namespace OnionPattern.Service.Tests.Requests.Games
{
    public class GetAllGamesRequestTests
    {
        private static IRepository<Game> fakeRepository;

        [TestClass]
        public class ConstructorTests
        {
            [TestInitialize]
            public void TestInitialize()
            {
                fakeRepository = A.Fake<IRepository<Game>>();
            }

            [TestCleanup]
            public void TestCleanup()
            {
                Fake.ClearConfiguration(fakeRepository);
            }

            [TestMethod]
            public void Inheritence()
            {
                var request = new GetAllGamesRequest(fakeRepository);

                request.Should().NotBeNull();
                request.Should().BeAssignableTo<IRequest<GetAllGamesResponse>>();
                request.Should().BeAssignableTo<BaseRequest<Game, GetAllGamesResponse>>();
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
            }

            [TestCleanup]
            public void TestCleanup()
            {
                Fake.ClearConfiguration(fakeRepository);
            }
        }
    }
}
