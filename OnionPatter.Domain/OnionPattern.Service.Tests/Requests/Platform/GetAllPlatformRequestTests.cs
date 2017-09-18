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
               Expression<Func<IEnumerable<Domain.Entities.Platform>>> getAll = () => fakeRepository.GetAll();

                var platforms = TestData.GetPlatforms().ToArray();

                A.CallTo(getAll).Returns(platforms);

                var request = new GetAllPlatformsRequest(fakeRepository);
                request.Should().NotBeNull();    
                
                var response = request.Execute();
                response.Should().NotBeNull();
                response.Should().BeOfType<GetAllPlatformsResponse>();

                response.Platforms.Should().NotBeNullOrEmpty();

                //platform 1 result
                var nes = response.Platforms.ElementAt(0);
                CheckValues(nes, platforms.Single(p => p.Id == 1));

                //platform 2 result
                var snes = response.Platforms.ElementAt(1);
                CheckValues(snes, platforms.Single(p => p.Id == 2));

                void CheckValues(Domain.Entities.Platform platform, Domain.Entities.Platform expected)
                {
                    platform.Should().NotBeNull();
                    platform.Id.ShouldBeEquivalentTo(expected.Id);
                    platform.Name.Should().BeEquivalentTo(expected.Name);
                    platform.ReleaseDate.ShouldBeEquivalentTo(expected.ReleaseDate);
                }

                A.CallTo(getAll).MustHaveHappened(Repeated.Exactly.Once);
            }
        }
    }
}
