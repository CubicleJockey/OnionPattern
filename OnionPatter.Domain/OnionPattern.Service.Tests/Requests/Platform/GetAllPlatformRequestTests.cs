using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FakeItEasy;
using FluentAssertions;
using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.Repository;
using OnionPattern.Service.Requests;
using OnionPattern.Service.Requests.Platform;
using OnionPattern.Service.Responses;

namespace OnionPattern.Service.Tests.Requests.Platform
{
    public class GetAllPlatformRequestTests
    {
        private static IRepository<Domain.Entities.Platform> fakeRepository;

        [TestClass]
        public class ConstructorTests
        {
            [TestInitialize]
            public void TestInitialize()
            {
                fakeRepository = A.Fake<IRepository<Domain.Entities.Platform>>();
            }

            [TestCleanup]
            public void TestCleanup()
            {
                Fake.ClearConfiguration(fakeRepository);
            }

            [TestMethod]
            public void Inheritence()
            {
                var request = new GetAllPlatformsRequest(fakeRepository);

                request.Should().NotBeNull();
                request.Should().BeAssignableTo<IRequest<GetAllPlatformsResponse>>();
                request.Should().BeAssignableTo<BaseRequest<Domain.Entities.Platform, GetAllPlatformsResponse>>();
                request.Should().BeOfType<GetAllPlatformsRequest>();
            }
        }

        [TestClass]
        public class MethodTests
        {
            [TestMethod]
            public void Execute()
            {
                var nintendo = new Domain.Entities.Platform
                {
                    Id = 1,
                    Name = "Nintendo",
                    ReleaseDate = new DateTime(1983, 07, 15)
                };

                var superNintendo = new Domain.Entities.Platform
                {
                    Id = 2,
                    Name = "Super Nintendo",
                    ReleaseDate = new DateTime(1990, 11, 21)
                };

                Expression<Func<IEnumerable<Domain.Entities.Platform>>> GetAll = () => fakeRepository.GetAll();

                A.CallTo(GetAll).Returns(new[] { nintendo, superNintendo });

                var request = new GetAllPlatformsRequest(fakeRepository);
                request.Should().NotBeNull();    
                
                var response = request.Execute();
                response.Should().NotBeNull();
                response.Should().BeOfType<GetAllPlatformsResponse>();

                response.Platforms.Should().NotBeNullOrEmpty();

                //platform 1 result
                var nes = response.Platforms.ElementAt(0);
                CheckValues(nes, nintendo);

                //platform 2 result
                var snes = response.Platforms.ElementAt(1);
                CheckValues(snes, superNintendo);

                void CheckValues(Domain.Entities.Platform platform, Domain.Entities.Platform expected)
                {
                    platform.Should().NotBeNull();
                    platform.Id.ShouldBeEquivalentTo(expected.Id);
                    platform.Name.Should().BeEquivalentTo(expected.Name);
                    platform.ReleaseDate.ShouldBeEquivalentTo(expected.ReleaseDate);
                }

                A.CallTo(GetAll).MustHaveHappened(Repeated.Exactly.Once);
            }
        }
    }
}
