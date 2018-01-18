using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.DataTransferObjects.Platform;
using OnionPattern.Domain.Services.Requests.Platform;
using OnionPattern.Service.Requests.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using OnionPattern.Domain.Interfaces;

namespace OnionPattern.Service.Tests.Requests.Platform
{
    public class GetAllPlatformRequestTests
    {

        [TestClass]
        public class ConstructorTests : TestBase<Domain.Entities.Platform>
        {
            [TestInitialize]
            public void TestInitialize()
            {
               InitializeFakes();
            }

            [TestCleanup]
            public void TestCleanup()
            {
                ClearFakes();
            }

            [TestMethod]
            public void Inheritence()
            {
                var request = new GetAllPlatformsRequest(FakeRepository, FakeRepositoryAggregate);

                request.Should().NotBeNull();
                request.Should().BeAssignableTo<IGetAllPlatformsRequest>();
                request.Should().BeAssignableTo<BaseServiceRequest<Domain.Entities.Platform>>();
                request.Should().BeOfType<GetAllPlatformsRequest>();
            }
        }

        [TestClass]
        public class MethodTests : TestBase<Domain.Entities.Platform>
        {
            [TestInitialize]
            public void TestInitalize()
            {
                InitializeFakes();
            }

            [TestCleanup]
            public void TestCleanup()
            {
                ClearFakes();
            }

            [TestMethod]
            public void Execute()
            {
               Expression<Func<IEnumerable<Domain.Entities.Platform>>> getAll = () => FakeRepository.GetAll();

                var platforms = TestData.GetPlatforms().ToArray();

                A.CallTo(getAll).Returns(platforms);

                var request = new GetAllPlatformsRequest(FakeRepository, FakeRepositoryAggregate);
                request.Should().NotBeNull();    
                
                var response = request.Execute();
                response.Should().NotBeNull();
                response.Should().BeOfType<PlatformListResponseDto>();

                response.Platforms.Should().NotBeNullOrEmpty();

                //platform 1 result
                var nes = response.Platforms.ElementAt(0);
                CheckValues(nes, platforms.Single(p => p.Id == 1));

                //platform 2 result
                var snes = response.Platforms.ElementAt(1);
                CheckValues(snes, platforms.Single(p => p.Id == 2));

                void CheckValues(IPlatform platform, IPlatform expected)
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
