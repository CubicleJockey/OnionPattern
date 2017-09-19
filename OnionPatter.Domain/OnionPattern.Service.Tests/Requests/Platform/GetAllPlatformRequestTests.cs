using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.Repository;
using OnionPattern.Domain.Services;
using OnionPattern.Service.Requests.Platform;
using OnionPattern.Service.Responses;

namespace OnionPattern.Service.Tests.Requests.Platform
{
    public class GetAllPlatformRequestTests
    {
        private static IRepository<Domain.Entities.Platform> fakeRepository;
        private static IRepositoryAggregate fakeRepositoryAggregate;

        [TestClass]
        public class ConstructorTests
        {
            [TestInitialize]
            public void TestInitialize()
            {
                fakeRepository = A.Fake<IRepository<Domain.Entities.Platform>>();
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
                var request = new GetAllPlatformsRequest(fakeRepository, fakeRepositoryAggregate);

                request.Should().NotBeNull();
                request.Should().BeAssignableTo<IServiceRequest<Domain.Entities.Platform, GetAllPlatformsResponse>>();
                request.Should().BeAssignableTo<BaseServiceRequest<Domain.Entities.Platform, GetAllPlatformsResponse>>();
                request.Should().BeOfType<GetAllPlatformsRequest>();
            }
        }

        [TestClass]
        public class MethodTests
        {
            [TestMethod]
            public async Task Execute()
            {
               Expression<Func<IEnumerable<Domain.Entities.Platform>>> getAll = () => fakeRepository.GetAll();

                var platforms = TestData.GetPlatforms().ToArray();

                A.CallTo(getAll).Returns(platforms);

                var request = new GetAllPlatformsRequest(fakeRepository, fakeRepositoryAggregate);
                request.Should().NotBeNull();    
                
                var response = await request.Execute();
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
